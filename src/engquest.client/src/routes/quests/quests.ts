export async function getRandomObjective(questId: number) {
  const response = await fetch(`/api/v1/objectives/random/${questId}`);

  return await response.json();
}

export async function getObjective(objectiveId: number, questId: number) {
  const response = await fetch(`/api/v1/objectives/${objectiveId}?` + new URLSearchParams({ questId } as any).toString());

  return await response.json();
}

export interface CompleteObjectiveResult {
  success: boolean,
  correctAnswer: string,
}

export async function completeObjective(exericesId:number, questId: number, answer: string) : Promise<CompleteObjectiveResult> {
    const response = await fetch(`/api/v1/objectives/${exericesId}/complete?` + new URLSearchParams({ questId, answer } as any).toString());

  return await response.json();
}