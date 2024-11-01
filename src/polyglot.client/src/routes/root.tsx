import {Outlet} from "react-router-dom";
import Header from "./header.tsx";

export default function Root() {
  return (
    <>
      <Header/>
      <div className="max-w-screen-2xl mx-auto p-5">
        <Outlet/>
      </div>
    </>
  )
} 