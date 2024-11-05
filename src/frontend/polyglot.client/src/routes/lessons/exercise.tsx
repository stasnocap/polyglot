import {Button, ButtonGroup, Divider, Skeleton} from "@nextui-org/react";
import React, {useState} from "react";
import {BackspaceIcon} from "../../icons/backspace-icon.tsx";
import {ExerciseStarIcon} from "../../icons/exercise-star-icon.tsx";
import {CheckIcon} from "../../icons/check-icon.tsx";
import {CloseIcon} from "../../icons/close-icon.tsx";

interface Exercise {
  exerciseId: string,
  lessonNumber: number,
  rusPhrase: string,
  wordGroups: WordGroup[],
  scoreRating: Rating,
}

interface WordGroup {
  words: string[],
  type: number,

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

const clickHistory: ClickHistory[] = [];
export default function Exercise() {
  const maxShowGroupCount: number = 4;

  const exercise: Exercise = {
    exerciseId: "17379086-4f20-429f-9d11-963ff274c6c4",
    lessonNumber: 1,
    rusPhrase: "Ты не увидишь.",
    wordGroups: [
      {
        words: ['1', '1', '1', '1', '1', '1'],
        type: 1,

        index: 0,
        disabled: false,
      },
      {
        words: ['2', '2', '2', '2', '2', '2'],
        type: 2,

        index: 0,
        disabled: false,
      },
      {
        words: ['3', '3', '3', '3', '3', '3'],
        type: 3,

        index: 0,
        disabled: false,
      },
      {
        words: ['4', '4', '4', '4', '4', '4'],
        type: 1,

        index: 0,
        disabled: false,
      },
      {
        words: ['5', '5', '5', '5', '5', '5'],
        type: 2,

        index: 0,
        disabled: false,
      },
      {
        words: ['6', '6', '6', '6', '6', '6'],
        type: 3,

        index: 0,
        disabled: false,
      },
    ],
    scoreRating: {
      correctNumber: 2,
      wrongNumber: 3,
      rate: 1.0
    }
  };

  exercise.wordGroups.forEach((wordGroup, index) => {
    wordGroup.index = index;
  });

  const emptyEngPhrase = ['Переведите предложение'];
  const [engPhrase, setEngPhrase] = useState(emptyEngPhrase)
  const [shownGroups, setShownGroups] = useState(exercise.wordGroups.slice(0, maxShowGroupCount));
  const [isBackspaceDisabled, setIsBackspaceDisabled] = useState(true);
  const [loading, setLoading] = useState(false);

  function handleButtonClick(event: React.MouseEvent<HTMLButtonElement>) {
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
    const nextWordGroup = exercise.wordGroups.find(wordGroup => wordGroup.index === maxShownWordGroupIndex + 1);
    if (nextWordGroup) {
      shownGroups[clickedGroupIndex] = nextWordGroup;
    } else {
      shownGroups[clickedGroupIndex].disabled = true;
    }

    if (newEngPhrase.length == exercise.wordGroups.length) {
      shownGroups.forEach(group => group.disabled = false);
      setLoading(true);
    }

    setIsBackspaceDisabled(false);
    setShownGroups(shownGroups);
    setEngPhrase(newEngPhrase);
  }

  function handleBackspaceClick() {
    const lastClick = clickHistory.pop();

    if (lastClick) {
      shownGroups[lastClick.groupIndex] = exercise.wordGroups[lastClick.wordGroupIndex]
      shownGroups[lastClick.groupIndex].disabled = false;
    }

    engPhrase.pop();

    setShownGroups([...shownGroups]);
    setIsBackspaceDisabled(clickHistory.length <= 0);
    setEngPhrase(engPhrase.length == 0 ? emptyEngPhrase : engPhrase);
  }

  return (
    <div>
      <div className="flex justify-between text-3xl">
        <div className="flex-1">
          {loading
            ? (<Skeleton className="h-9 w-3/6 rounded-lg bg-default-200"/>)
            : (<div className="text-gray-700">{exercise.rusPhrase}</div>)}
        </div>
        <div>
          <div className="flex items-center">
            <div className="flex items-center me-2">
              <ExerciseStarIcon height={40} width={40}/>
              {loading
                ? (<Skeleton className="h-9 w-8 rounded-lg bg-default-200"/>)
                : (<span className="text-gray-700">{exercise.scoreRating.rate.toFixed(1)}</span>)}
            </div>
            <div className="flex items-center me-2">
              <CheckIcon height={40} width={40}/>
              {loading
                ? (<Skeleton className="h-9 w-8 rounded-lg bg-default-200"/>)
                : (<span className="text-success">{exercise.scoreRating.correctNumber}</span>)}
            </div>
            <div className="flex items-center">
              <CloseIcon height={40} width={40}/>
              {loading
                ? (<Skeleton className="h-9 w-8 rounded-lg bg-default-200"/>)
                : (<span className="text-danger">{exercise.scoreRating.wrongNumber}</span>)}
            </div>
          </div>
        </div>
      </div>
      <Divider className="my-4"/>
      <div className="flex justify-between">
        {loading
          ? (<Skeleton className="h-9 w-2/6 rounded-lg bg-default-200"/>)
          : (<div className="text-3xl text-gray-400">{engPhrase.join(' ')}</div>)}
        <Button variant="light" className="text-xl text-gray-500" isLoading={loading} isDisabled={isBackspaceDisabled} onClick={handleBackspaceClick}>
          BACKSPACE
          <BackspaceIcon width={32} height={32}/>
        </Button>
      </div>
      <Divider className="my-4"/>
      <div className="grid grid-cols-2 gap-5">
        {shownGroups.map((wordGroup, i) => (
          <ButtonGroup className={"grid grid-cols-2"} key={i} radius="none" data-word-group-index={wordGroup.index} data-group-index={i}>
            {wordGroup.words.map((word, j) => (
              <Button color="secondary" variant="light" key={j} className="text-2xl p-6" onClick={handleButtonClick} isLoading={loading} isDisabled={wordGroup.disabled}>
                {loading
                  ? (<Skeleton className="h-9 w-3/6 rounded-lg bg-default-200"/>)
                  : (<>{wordGroup.disabled ? "" : word}</>)}
              </Button>
            ))}
          </ButtonGroup>
        ))}
      </div>
    </div>
  );
}