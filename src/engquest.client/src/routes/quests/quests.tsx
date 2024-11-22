import {Card, CardHeader, CardBody, Divider, CardFooter, Button, Progress, Tooltip} from "@nextui-org/react";
import {Link} from "react-router-dom";
import {useEffect, useState} from "react";
import {useUser} from "../../providers/user-provider.tsx";
import {CheckIcon} from "../../icons/check-icon.tsx";
import {getQuests, Quest} from "./quests.ts";

const loadingQuests: Quest[] = [];

for (let i = 1; i <= 31; i++) {
  loadingQuests.push({id: i, name: ""})
}

export default function Quests() {
  const [quests, setQuests] = useState<Quest[]>(loadingQuests);
  const [loading, setLoading] = useState(true);
  const {user, level} = useUser();

  useEffect(() => {
    getQuests()
      .then(quests => {
        setQuests(quests);
        setLoading(false);
      });
  }, []);

  return loading ? (<></>) : (
    <div className="grid sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 2xl:grid-cols-5 gap-3">
      {quests.map((x) => {
          const isQuestDisabled = user ? level.value < x.id : x.id !== 1;
          
          const card = (<Card className="max-w-[400px] bg-primary-50" key={x.id} isDisabled={isQuestDisabled}>
            <CardHeader className="flex gap-3">
              <div className="flex w-full justify-between items-center text-lg font-medium">
                Квест {x.id}
                {level.value <= x.id
                  ? (level.value === x.id && (user || level.value === 1)
                      ? (<Progress aria-label="Loading..." value={level.experience} minValue={level.levelRequiredXp} maxValue={level.nextLevelRequiredXp} className="w-48"/>)
                      : (<></>)
                  ) : (<CheckIcon height={30} width={30}/>)}
              </div>
            </CardHeader>
            <Divider/>
            <CardBody>
              <p>
                {x.name}
              </p>
            </CardBody>
            <Divider/>
            <CardFooter className="flex justify-between">
              <Button className="bg-primary-100" isLoading={loading} isDisabled={isQuestDisabled}>
                <Link to={`${x.id}/info`} className="after:absolute after:inset-0">
                  Подробнее
                </Link>
              </Button>
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