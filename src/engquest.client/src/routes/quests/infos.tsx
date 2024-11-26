import {MDXProvider} from '@mdx-js/react';
import Info1 from './info/info1.mdx';
import Info2 from './info/info2.mdx';
import Info3 from './info/info3.mdx';
import {BreadcrumbItem, Breadcrumbs} from "@nextui-org/react";
import './info/info.css';
import { useLocation } from 'react-router-dom';
import {Quest} from "./quests.ts";

export default function Infos() {
  const location = useLocation();
  const { quest }: { quest: Quest } = location.state;
  const Info = getComponentByQuestId(Number(quest.id));

  const components = {
    em(properties: any) {
      return <i {...properties} />
    }
  }

  return (
    <>
      <Breadcrumbs itemClasses={{item: "text-lg"}} underline="hover" className="mb-3" color="primary">
        <BreadcrumbItem href="/quests">Квеcты</BreadcrumbItem>
        <BreadcrumbItem href={`/quests/${quest.id}/info`}>Квест {quest.id}: {quest.name}</BreadcrumbItem>
      </Breadcrumbs>
      <div className="info text-lg">
        <MDXProvider components={components}>
          <Info/>
        </MDXProvider>
      </div>
    </>
  );
}

const getComponentByQuestId = (questId: number) => {
  const components: { [key: number]: React.FC } = {1: Info1, 2:Info2, 3:Info3};
  return components[questId] || NotFound;
};

const NotFound: React.FC = () => <div>Урок не найден :(</div>;