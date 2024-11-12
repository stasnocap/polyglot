import {Outlet} from "react-router-dom";
import Header from "./header.tsx";
import {useState} from "react";

export default function Root() {
  const savedTheme = localStorage.getItem("theme") ?? "purple";
  const [theme, setTheme] = useState(savedTheme);
  return (
    <div className={`${theme} text-foreground bg-background min-h-screen flex flex-col`}>
      <Header theme={theme} setTheme={setTheme}/>
      <main className="max-w-screen-2xl w-full mx-auto p-5 flex-grow flex flex-col">
        <Outlet/>
      </main>
    </div>
  )
} 