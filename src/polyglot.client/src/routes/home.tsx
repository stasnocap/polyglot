import {Button} from "@nextui-org/react";
import {Link} from "react-router-dom";
import HomeImage from "../icons/home-image.tsx";

export default function Home() {
  return (
    <div className="grid grid-cols-1 sm:grid-cols-2 place-items-center w-full h-full">
      <HomeImage />
      <div className="flex flex-col items-center">
        <div className="text-3xl text-primary mb-2 text-center">
          The free, fun, and effective way to learn a language!
        </div>
        <Button radius="lg" className="bg-gradient-to-tr from-blue-500 to-pink-500 text-white text-2xl shadow-xl p-7">
          <Link to="/lessons" className="after:absolute after:inset-0 text-background">
            GET STARTED
          </Link>
        </Button>
      </div>
    </div>
  );
}