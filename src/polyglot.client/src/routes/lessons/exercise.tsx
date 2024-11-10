import {Button, ButtonGroup, Divider} from "@nextui-org/react";
import React, {useEffect, useState} from "react";
import {BackspaceIcon} from "../../icons/backspace-icon.tsx";
import {ExerciseStarIcon} from "../../icons/exercise-star-icon.tsx";
import {CheckIcon} from "../../icons/check-icon.tsx";
import {CloseIcon} from "../../icons/close-icon.tsx";
import {getRandomExercise, completeExercise, CompleteExerciseResult} from "./lessons.ts";
import { useParams } from "react-router-dom";
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

const compliments = [
  "Молодец!",
  "Отлично!",
  "Хорошо!",
  "Гораздо лучше, чем я ожидал!",
  "Ты меня приятно удивил!",
  "Великолепно!",
  "Прекрасно!",
  "Ты меня очень обрадовал!",
  "Именно этого я давно ждал от тебя!",
  "Сказано здорово – просто и ясно!",
  "Ты, как всегда, точен!",
  "Очень хороший ответ!",
  "Талантливо!",
  "Ты сегодня прыгнул выше головы!",
  "Я поражен!",
  "Уже существенно лучше!",
  "Потрясающе!",
  "Замечательно!",
  "Прекрасное начало!",
  "Так держать!",
  "Ты на верном пути!",
  "Здорово!",
  "Это как раз то, что нужно!",
  "Я тобой горжусь!",
  "С каждым разом у тебя получается всё лучше!",
  "Мы с тобой не зря поработали!",
  "Я вижу, как ты стараешься!",
  "Ты растешь над собой!",
  "Ты многое сделал, я это вижу!",
  "Теперь у тебя точно все получится!",
];

function getRandomCompliment() {
  return compliments[Math.floor(Math.random() * compliments.length)];
}

let clickHistory: ClickHistory[] = [];
let exercise: Exercise = null!;
export default function Exercise() {
  const maxShowGroupCount: number = 4;
  const emptyEngPhrase = ['Переведите предложение'];

  const { lessonId } = useParams();
  const [loading, setLoading] = useState(true);
  const [rusPhrase, setRusPhrase] = useState("");
  const [rating, setRating] = useState<Rating | null>();
  const [engPhrase, setEngPhrase] = useState<string[]>([]);
  const [shownGroups, setShownGroups] = useState<WordGroup[]>([]);
  const [isBackspaceDisabled, setIsBackspaceDisabled] = useState(true);
  const [completeExerciseResult, setCompleteExerciseResult] = useState<CompleteExerciseResult | null>(null);
  const [revalidateCounter, setRevalidateCounter] = useState(0);

  useEffect(() => {
    setLoading(true);
    
    getRandomExercise(Number(lessonId))
      .then(x => {
        exercise = mapExercise(x);
        clickHistory = [];

        setRusPhrase(exercise.rusPhrase);
        setRating(exercise.rating);
        setShownGroups(exercise.wordGroups.slice(0, maxShowGroupCount));
        setEngPhrase(emptyEngPhrase);
        setIsBackspaceDisabled(true);
        setLoading(false);
      });
  }, [revalidateCounter]);

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
      setLoading(true);

      completeExercise(exercise.exerciseId, exercise.lessonId, newEngPhrase.join(' '))
        .then(completeResult => {
          setCompleteExerciseResult(completeResult);
          
          if (completeResult.success) {
            setRevalidateCounter(x => x + 1);
          } else {
            clickHistory = [];
            shownGroups.forEach(x => x.disabled = false);
            setShownGroups(exercise.wordGroups.slice(0, maxShowGroupCount));
            setEngPhrase(emptyEngPhrase);
            setIsBackspaceDisabled(true);
            setLoading(false);
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

  return loading ? (<ExerciseSkeleton/>) : (
    <>
      <div className="flex justify-between text-3xl">
        <div className="flex-1">
          <div className="text-primary">{rusPhrase}</div>
        </div>
        <div>
          {rating ?
            <div className="flex items-center">
              <div className="flex items-center me-2">
                <ExerciseStarIcon height={40} width={40}/>
                <span className="text-primary">{rating.rate.toFixed(1)}</span>
              </div>
              <div className="flex items-center me-2">
                <CheckIcon height={40} width={40}/>
                <span className="text-success">{rating.correctNumber}</span>
              </div>
              <div className="flex items-center">
                <CloseIcon height={40} width={40}/>
                <span className="text-danger">{rating.wrongNumber}</span>
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
      <div className="relative">
        {completeExerciseResult?.success === true ? (
          <div className="flex justify-center items-center h-[308px] text-5xl bg-success-200 text-success animate-fade absolute w-full opacity-0">
            {getRandomCompliment()}
          </div>
        ) : (<></>) }
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
      </div>
    </>
  );
}