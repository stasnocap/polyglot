import {Outlet} from "react-router-dom";
import Header from "./header.tsx";

export default function Root() {
  return (
    <>
      <Header/>
      <Outlet/>
    </>
  )
} 