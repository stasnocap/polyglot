import {Card, CardHeader, CardBody, Divider, CardFooter, Button, Skeleton, Progress, Tooltip} from "@nextui-org/react";
import {Link} from "react-router-dom";
import {useEffect, useState} from "react";
import {useUser} from "../../providers/user-provider.tsx";
import {CheckIcon} from "../../icons/check-icon.tsx";
import {getQuests, Quest} from "./quests.ts";

export default function Quests() {
  const [quests, setQuests] = useState<Quest[]>([]);
  const [loading, setLoading] = useState(true);
  const {user, level} = useUser();

  useEffect(() => {
    getQuests()
      .then(quests => {
        setQuests(quests);
        setLoading(false);
      });
  }, []);

  return (
    <div className="grid sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 2xl:grid-cols-5 gap-3">
      {quests.map((x) => {
          const isQuestDisabled = user ? level.value < x.id : x.id !== 1;

          const card = (<Card className="max-w-[400px] bg-primary-50" key={x.id} isDisabled={isQuestDisabled}>
            <CardHeader className="flex gap-3">
              <div className="flex flex-col w-full">
                <div className="text-lg font-medium">
                  {loading
                    ? (<Skeleton className="h-7 w-20 rounded-lg bg-default-200"/>)
                    : (<div className="flex justify-between items-center">
                      Квест {x.id}
                      {level.value <= x.id
                        ? (level.value === x.id && (user || level.value === 1)
                            ? (<Progress aria-label="Loading..." value={level.experience} minValue={level.levelRequiredXp} maxValue={level.nextLevelRequiredXp} className="w-48"/>)
                            : (<></>)
                        ) : (<CheckIcon height={30} width={30}/>)}
                    </div>)}
                </div>
              </div>
            </CardHeader>
            <Divider/>
            <CardBody>
              {loading
                ? (<Skeleton className="h-7 w-44 rounded-lg bg-default-200"/>)
                : (
                  <>
                    <p className="mb-2">
                      {x.name}
                    </p>
                  </>
                )}
            </CardBody>
            <Divider/>
            <CardFooter className="flex justify-between">
              <Button className="bg-primary-100" isLoading={loading} isDisabled={isQuestDisabled}>Подробнее</Button>
              <Button color="primary" isLoading={loading} isDisabled={isQuestDisabled}>
                <Link to={x.id.toString()} className="after:absolute after:inset-0 text-primary-50">
                  Старт!
                </Link>
              </Button>
            </CardFooter>
          </Card>);

          return isQuestDisabled ? (
              <Tooltip className="text-primary-50" color="primary" key={x.id} placement="bottom" content={user ? 'Ты ещё не достиг нужного уровня. Заверши предыдущий квест!' : 'Время зарегистрироваться, герой! Этот квест доступен только для зарегистрированных пользователей'}>
                {card}
              </Tooltip>
            )
            : card;
        }
      )}
    </div>
  );
}