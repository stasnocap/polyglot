import {Button, ButtonGroup, Divider} from "@nextui-org/react";
import React, {useState} from "react";

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
  visible: boolean,
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

export default function Exercise() {
  const maxShowGroupCount: number = 4;

  const exercise: Exercise = {
    exerciseId: "17379086-4f20-429f-9d11-963ff274c6c4",
    lessonNumber: 1,
    rusPhrase: "Ты не увидишь.",
    wordGroups: [
      {
        words: ['I', 'You', 'He', 'She', 'It', 'We'],
        type: 1,

        index: 0,
        visible: false,
      },
      {
        words: ['can not', 'could not', 'may not', 'might not', 'will not', 'shall not'],
        type: 2,

        index: 0,
        visible: false,
      },
      {
        words: ['see.', 'abide.', 'arise.', 'awake.', 'bear.', 'beat.'],
        type: 3,

        index: 0,
        visible: false,
      },
      {
        words: ['I', 'You', 'He', 'She', 'It', 'We'],
        type: 1,

        index: 0,
        visible: false,
      },
      {
        words: ['can not', 'could not', 'may not', 'might not', 'will not', 'shall not'],
        type: 2,

        index: 0,
        visible: false,
      },
      {
        words: ['see.', 'abide.', 'arise.', 'awake.', 'bear.', 'beat.'],
        type: 3,

        index: 0,
        visible: false,
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
    wordGroup.visible = true;
  });

  const emptyEngPhrase = 'Переведите предложение';
  const [engPhrase, setEngPhrase] = useState(emptyEngPhrase)
  const [shownGroups, setShownGroups] = useState(exercise.wordGroups.slice(0, maxShowGroupCount));
  const clickHistory : ClickHistory[] = [];

  function handleButtonClick(event: React.MouseEvent<HTMLButtonElement>) {
    const button = event.target as HTMLInputElement;
    const word = button.textContent!;

    const newEngPhrase: string = engPhrase === emptyEngPhrase
      ? word
      : engPhrase + ' ' + word;
    
    const groupIndex = Number(button.parentElement!.dataset['groupIndex']);
    const wordGroupIndex = Number(button.parentElement!.dataset['wordGroupIndex']);
    clickHistory.push({ groupIndex, wordGroupIndex });

    const clickedGroupIndex = shownGroups.findIndex(group => group.index === wordGroupIndex);

    if (clickedGroupIndex < 0) {
      throw new Error('Clicked group index was not found in shown groups');
    }

    const maxShownWordGroupIndex = Math.max(...shownGroups.map(shownGroup => shownGroup.index));
    const nextWordGroup = exercise.wordGroups.find(wordGroup => wordGroup.index === maxShownWordGroupIndex + 1);
    if (nextWordGroup) {
      shownGroups[clickedGroupIndex] = nextWordGroup;
    } else {
      shownGroups[clickedGroupIndex].visible = false;
    }

    setShownGroups(shownGroups);
    setEngPhrase(newEngPhrase);
  }

  return (
    <div>
      <div className="text-3xl">
        {exercise.rusPhrase}
      </div>
      <Divider className="my-4"/>
      <div className="text-3xl text-gray-400">
        {engPhrase}
      </div>
      <Divider className="my-4"/>
      <div className="grid grid-cols-2 gap-5">
        {shownGroups.map((wordGroup, i) => (
          <ButtonGroup className={wordGroup.visible ? "grid grid-cols-2" : "grid grid-cols-2 invisible"} key={i} radius="none" data-word-group-index={wordGroup.index} data-group-index={i}>
            {wordGroup.words.map((word, j) => (
              <Button color="primary" variant="light" key={j} className="text-2xl p-6" onClick={handleButtonClick}>
                {word}
              </Button>
            ))}
          </ButtonGroup>
        ))}
      </div>
    </div>
  );
}