import {Level} from "../../providers/user-provider.tsx";

export async function getRandomObjective(questId: number) {
  const response = await fetch(`/api/v1/objectives/random/${questId}`);

  return await response.json();
}

export async function getQuests() {
  const response = await fetch('/api/v1/quests');

  const result = await response.json();

  return result as Quest[];
}

export interface Quest {
  id: number;
  name: string;
}

export interface GainExperienceResult {
  gainedExperience: number;
  newLevel: boolean;
}

interface CompleteObjectiveResult {
  success: boolean;
  correctAnswer: string;
}

export interface CompleteObjectiveResponse {
  completeObjectiveResult: CompleteObjectiveResult;
  gainExperienceResult: GainExperienceResult | null;
  level: Level | null
}

export async function completeObjective(exericesId: number, questId: number, answer: string) {
  const response = await fetch(`/api/v1/objectives/${exericesId}/complete?` + new URLSearchParams({questId, answer} as any).toString());

  const data = await response.json();

  return data as CompleteObjectiveResponse;
}