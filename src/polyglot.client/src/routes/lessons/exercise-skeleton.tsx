import {BackspaceIcon} from "../../icons/backspace-icon.tsx";
import {Button, ButtonGroup, Divider, Skeleton } from "@nextui-org/react";

export default function ExerciseSkeleton() {
  return (
    <>
      <div className="flex justify-between text-3xl">
        <div className="flex-1">
          <Skeleton className="h-9 w-3/6 rounded-lg bg-default-200"/>
        </div>
      </div>
      <Divider className="my-4"/>
      <div className="flex justify-between">
        <Skeleton className="h-9 w-2/6 rounded-lg bg-default-200"/>
        <Button variant="light" color="primary" className="text-xl" isLoading isDisabled>
          BACKSPACE
          <BackspaceIcon width={32} height={32}/>
        </Button>
      </div>
      <Divider className="my-4"/>
      <div className="grid grid-cols-2 gap-5">
        {Array(4).fill(0).map((_, i) => (
          <ButtonGroup className={"grid grid-cols-2"} key={i} radius="none">
            {Array(6).fill(0).map((_, j) => (
              <Button color="primary" variant="light" key={j} className="text-2xl p-6" isLoading isDisabled>
                <Skeleton className="h-9 w-3/6 rounded-lg bg-default-200"/>
              </Button>
            ))}
          </ButtonGroup>
        ))}
      </div>
    </>
  )
}