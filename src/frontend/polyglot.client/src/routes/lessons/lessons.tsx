import {Card, CardHeader, CardBody, Divider, CardFooter, Button, Skeleton} from "@nextui-org/react";
import {Link} from "react-router-dom";
import {useState} from "react";

interface Lesson {
  id: string,
  number: number,
  name: string,
  rate: number | null,
}

export default function Lessons() {
  const array: Lesson[] = Array(5);
  const [loading, setLoading] = useState(false);

  for (let i = 0; i < array.length; i++) {
    const number = i + 1;
    array[i] = {id: '1499a52b-fb5f-4eda-a846-015835579f87', number: number, name: `Наименование урока ${number}`, rate: 1.2};
  }

  return (
    <div className="grid sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 2xl:grid-cols-5 gap-3">
      {array.map((x) =>
        <Card className="max-w-[400px]" key={x.number}>
          <CardHeader className="flex gap-3">
            <div className="flex flex-col">
              <p className="text-lg font-medium text-gray-800">
                {loading
                  ? (<Skeleton className="h-7 w-20 rounded-lg bg-default-200"/>)
                  : (<>Урок {x.number}</>)}
              </p>
            </div>
          </CardHeader>
          <Divider/>
          <CardBody>
            {loading
              ? (<Skeleton className="h-7 w-44 rounded-lg bg-default-200"/>)
              : (<p>{x.name}</p>)}
          </CardBody>
          <Divider/>
          <CardFooter className="flex justify-between">
            <Button className="bg-gradient-to-tr from-primary-300 to-primary-500 text-white shadow-lg" isLoading={loading}>Подробнее</Button>
            <Button className="bg-gradient-to-tr from-pink-500 to-yellow-500 text-white shadow-lg" isLoading={loading}>
              <Link to={x.number.toString()} className="after:absolute after:inset-0">
                Let's go
              </Link>
            </Button>
          </CardFooter>
        </Card>
      )}
    </div>
  );
}