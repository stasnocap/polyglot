import {Button, Image} from "@nextui-org/react";
import {Link} from "react-router-dom";

export default function Home() {
  return (
    <div className="flex justify-center items-center">
      <Image
        width={800}
        alt="NextUI Fruit Image with Zoom"
        src="/home.jpg"
      />
      <div className="flex flex-col items-center">
        <div className="text-3xl text-secondary-400 mb-2">
          The free, fun, and effective way to learn a language!
        </div>
        <div>
          <Button radius="lg" className="bg-gradient-to-tr from-pink-500 to-secondary-500 text-white text-2xl shadow-xl p-7">
            <Link to="/lessons" className="after:absolute after:inset-0">
              GET STARTED
            </Link>
          </Button>
        </div>
      </div>
    </div>
  );
}