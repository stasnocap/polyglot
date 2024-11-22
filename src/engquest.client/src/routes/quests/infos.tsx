import {useParams} from "react-router-dom";
import Info1 from "./info/1.tsx";

export default function Infos() {
  const {questId} = useParams<{ questId: string }>();
  const Info = getComponentByQuestId(Number(questId));
  return <Info/>;
}

const getComponentByQuestId = (questId: number) => {
  const components: { [key: number]: React.FC } = {1: Info1};
  return components[questId] || NotFound;
};

const NotFound: React.FC = () => <div>Урок не найден :(</div>;