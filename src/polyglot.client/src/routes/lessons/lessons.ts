export async function getRandomExercise(lessonId: number) {
  const response = await fetch(`/api/v1/exercises/random/${lessonId}`);

  const result = await response.json();

  await new Promise((resolve) => {
    setTimeout(() => resolve(), 1000);
  })
  
  return result;
}

export async function getExercise(exerciseId: number, lessonId: number) {
  const response = await fetch(`/api/v1/exercises/${exerciseId}?` + new URLSearchParams({ lessonId } as any).toString());

  const result = await response.json();

  await new Promise((resolve) => {
    setTimeout(() => resolve(), 1000);
  })
  
  return result;
}

export interface CompleteExerciseResult {
  success: boolean,
  correctAnswer: string,
}

export async function completeExercise(exericesId:number, lessonId: number, answer: string) : Promise<CompleteExerciseResult> {
    const response = await fetch(`/api/v1/exercises/${exericesId}/complete?` + new URLSearchParams({ lessonId, answer } as any).toString());
    
    const result = await response.json();

    await new Promise((resolve) => {
      setTimeout(() => resolve(), 1000);
    });

    return result;
}