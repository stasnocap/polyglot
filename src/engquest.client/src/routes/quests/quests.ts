import {Level} from "../../providers/user-provider.tsx";

export async function getRandomObjective(questId: number) {
  const response = await fetch(`/api/v1/objectives/random/${questId}`);

  return await response.json();
}

export interface CompleteObjectiveResult {
  success: boolean,
  correctAnswer: string,
  level: Level | null
}

export async function completeObjective(exericesId:number, questId: number, answer: string) : Promise<CompleteObjectiveResult> {
    const response = await fetch(`/api/v1/objectives/${exericesId}/complete?` + new URLSearchParams({ questId, answer } as any).toString());

  return await response.json();
}