import {Outlet} from "react-router-dom";
import Header from "./header.tsx";
import {useTheme} from "../providers/theme-provider.tsx";

export default function Root() {
  const {theme} = useTheme();
  document.body.className = theme;
  return (
    <div className="text-foreground bg-background min-h-screen flex flex-col">
      <Header/>
      <main className="max-w-screen-2xl w-full mx-auto p-5 flex-grow flex flex-col">
        <Outlet/>
      </main>
    </div>
  )
}