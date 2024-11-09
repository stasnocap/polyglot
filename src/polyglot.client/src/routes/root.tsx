import {Outlet} from "react-router-dom";
import Header from "./header.tsx";
import {useState} from "react";

export default function Root() {
  const savedTheme = localStorage.getItem("theme") ?? "purple";
  const [theme, setTheme] = useState(savedTheme);
  return (
    <div className={`${theme} text-foreground bg-background h-full w-full`}>
      <Header theme={theme} setTheme={setTheme} />
      <main className="max-w-screen-2xl mx-auto p-5">
        <Outlet/>
      </main>
    </div>
  )
} 