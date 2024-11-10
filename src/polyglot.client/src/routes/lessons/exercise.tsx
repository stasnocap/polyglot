import {Button, ButtonGroup, Divider} from "@nextui-org/react";
import React, {Suspense, useEffect, useState} from "react";
import {BackspaceIcon} from "../../icons/backspace-icon.tsx";
import {ExerciseStarIcon} from "../../icons/exercise-star-icon.tsx";
import {CheckIcon} from "../../icons/check-icon.tsx";
import {CloseIcon} from "../../icons/close-icon.tsx";
import {getRandomExercise, completeExercise, CompleteExerciseResult} from "./lessons.ts";
import {Await, defer, useLoaderData, useRevalidator } from "react-router-dom";
import ExerciseSkeleton from "./exercise-skeleton.tsx";

interface Exercise {
  exerciseId: number,
  lessonId: number,
  rusPhrase: string,
  wordGroups: WordGroup[],
  rating: Rating | null,
}

interface WordGroup {
  words: string[],

  // added for frontend purposes
  index: number,
  disabled: boolean,
}

interface Rating {
  correctNumber: number,
  wrongNumber: number,
  rate: number,
}

interface ClickHistory {
  groupIndex: number,
  wordGroupIndex: number,
}

let clickHistory: ClickHistory[] = [];

function mapExercise(exercise: any) : Exercise {
  if (!exercise) {
    throw new Response("", {
      status: 404,
      statusText: "Not Found",
    });
  }

  const model = {
    exerciseId: exercise.exerciseId,
    lessonId: exercise.lessonId,
    rusPhrase: exercise.rusPhrase,
    wordGroups: Array(exercise.wordGroups.length),
    rating: null as Rating | null,
  };

  if (exercise.ratingRate) {
    model.rating = {
      correctNumber: exercise.ratingCorrectNumber,
      wrongNumber: exercise.ratingWrongNumber,
      rate: exercise.ratingRate,
    }
  }

  for (let i = 0; i < exercise.wordGroups.length; i++) {
    model.wordGroups[i] = {};
    model.wordGroups[i].words = exercise.wordGroups[i];
    model.wordGroups[i].index = i;
    model.wordGroups[i].disabled = false;
  }

  return model;
}

export async function loader({params}: { params: any, request: any }) {
  const exercisePromise = getRandomExercise(params.lessonId);

  return defer({
    exercise: exercisePromise.then(exercise => mapExercise(exercise))
  })
}

export default function Exercise() {
  const data = useLoaderData() as { exercise: Exercise };

  return (
    <div>
      <Suspense fallback={<ExerciseSkeleton/>}>
        <Await resolve={data.exercise}>
          {(exercise: Exercise) => {
            const maxShowGroupCount: number = 4;
            const emptyEngPhrase = ['Переведите предложение'];

            const [engPhrase, setEngPhrase] = useState(emptyEngPhrase);
            const [shownGroups, setShownGroups] = useState(exercise.wordGroups.slice(0, maxShowGroupCount));
            const [isBackspaceDisabled, setIsBackspaceDisabled] = useState(true);
            const [completeExerciseResult, setCompleteExerciseResult] = useState<CompleteExerciseResult | null>(null);
            const { revalidate, state } = useRevalidator();
            const [isRevalidating, setIsRevalidating] = useState(false);

            useEffect(() => {
              if (state === "loading") {
                setIsRevalidating(true);
              } else if (state === "idle" && isRevalidating) {
                setShownGroups(exercise.wordGroups.slice(0, maxShowGroupCount));
                setEngPhrase(emptyEngPhrase);
                clickHistory = [];
                setIsRevalidating(false);
              }
            }, [state]);
            
            function handleButtonClick(event: React.MouseEvent<HTMLButtonElement>) {
              setCompleteExerciseResult(null);
              
              const button = event.target as HTMLInputElement;
              const word = button.textContent!;

              const newEngPhrase = engPhrase[engPhrase.length - 1] === emptyEngPhrase[0]
                ? [word]
                : [...engPhrase, word];

              const groupIndex = Number(button.parentElement!.dataset['groupIndex']);
              const wordGroupIndex = Number(button.parentElement!.dataset['wordGroupIndex']);
              clickHistory.push({groupIndex, wordGroupIndex});

              const clickedGroupIndex = shownGroups.findIndex(group => group.index === wordGroupIndex);

              if (clickedGroupIndex < 0) {
                throw new Error('Clicked group index was not found in shown groups');
              }

              const maxShownWordGroupIndex = Math.max(...shownGroups.map(shownGroup => shownGroup.index));
              const nextWordGroup = exercise!.wordGroups.find(wordGroup => wordGroup.index === maxShownWordGroupIndex + 1);
              if (nextWordGroup) {
                shownGroups[clickedGroupIndex] = nextWordGroup;
              } else {
                shownGroups[clickedGroupIndex].disabled = true;
              }

              setIsBackspaceDisabled(false);
              setShownGroups(shownGroups);
              setEngPhrase(newEngPhrase);

              if (newEngPhrase.length == exercise!.wordGroups.length) {
                setIsRevalidating(true);

                completeExercise(exercise.exerciseId, exercise.lessonId, newEngPhrase.join(' '))
                  .then(completeResult => {
                    setCompleteExerciseResult(completeResult);
                    
                    if (completeResult.success) {
                      revalidate();
                    } else {
                      shownGroups.forEach(x => x.disabled = false);
                      setShownGroups(exercise.wordGroups.slice(0, maxShowGroupCount));
                      clickHistory = [];
                      setEngPhrase(emptyEngPhrase);
                      setIsBackspaceDisabled(true);
                      setIsRevalidating(false);
                    }
                  });
              }
            }

            function handleBackspaceClick() {
              const lastClick = clickHistory.pop();

              if (lastClick) {
                shownGroups[lastClick.groupIndex] = exercise!.wordGroups[lastClick.wordGroupIndex]
                shownGroups[lastClick.groupIndex].disabled = false;
              }

              engPhrase.pop();

              setShownGroups([...shownGroups]);
              setIsBackspaceDisabled(clickHistory.length <= 0);
              setEngPhrase(engPhrase.length == 0 ? emptyEngPhrase : engPhrase);
            }

            return isRevalidating ? (<ExerciseSkeleton/>) : (
              <>
                <div className="flex justify-between text-3xl">
                  <div className="flex-1">
                    <div className="text-primary">{exercise.rusPhrase}</div>
                  </div>
                  <div>
                    {exercise?.rating ?
                      <div className="flex items-center">
                        <div className="flex items-center me-2">
                          <ExerciseStarIcon height={40} width={40}/>
                          <span className="text-primary">{exercise.rating.rate.toFixed(1)}</span>
                        </div>
                        <div className="flex items-center me-2">
                          <CheckIcon height={40} width={40}/>
                          <span className="text-success">{exercise.rating.correctNumber}</span>
                        </div>
                        <div className="flex items-center">
                          <CloseIcon height={40} width={40}/>
                          <span className="text-danger">{exercise.rating.wrongNumber}</span>
                        </div>
                      </div>
                      : (<></>)}
                  </div>
                </div>
                <Divider className="my-4"/>
                <div className="flex justify-between">
                  <div className={`text-3xl ${completeExerciseResult?.success === false ? "text-danger" : "text-primary-100"}`}>{completeExerciseResult?.success === false ? completeExerciseResult.correctAnswer : engPhrase.join(' ')}</div>
                  <Button variant="light" color="primary" className="text-xl" isDisabled={isBackspaceDisabled} onClick={handleBackspaceClick}>
                    BACKSPACE
                    <BackspaceIcon width={32} height={32}/>
                  </Button>
                </div>
                <Divider className="my-4"/>
                <div className="grid grid-cols-2 gap-5">
                  {shownGroups.map((wordGroup, i) => (
                    <ButtonGroup className={"grid grid-cols-2"} key={i} radius="none" data-word-group-index={wordGroup.index} data-group-index={i}>
                      {wordGroup.words.map((word, j) => (
                        <Button color="primary" variant="light" key={j} className="text-2xl p-6" onClick={handleButtonClick} isDisabled={wordGroup.disabled}>
                          {wordGroup.disabled ? "" : word}
                        </Button>
                      ))}
                    </ButtonGroup>
                  ))}
                </div>
              </>
            )
          }}
        </Await>
      </Suspense>
    </div>
  );
}