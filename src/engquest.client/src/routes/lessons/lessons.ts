export async function getRandomExercise(lessonId: number) {
  const response = await fetch(`/api/v1/exercises/random/${lessonId}`);

  return await response.json();
}

export async function getExercise(exerciseId: number, lessonId: number) {
  const response = await fetch(`/api/v1/exercises/${exerciseId}?` + new URLSearchParams({ lessonId } as any).toString());

  return await response.json();
}

export interface CompleteExerciseResult {
  success: boolean,
  correctAnswer: string,
}

export async function completeExercise(exericesId:number, lessonId: number, answer: string) : Promise<CompleteExerciseResult> {
    const response = await fetch(`/api/v1/exercises/${exericesId}/complete?` + new URLSearchParams({ lessonId, answer } as any).toString());

  return await response.json();
}