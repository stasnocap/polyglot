import {StrictMode} from 'react'
import {createRoot} from 'react-dom/client'
import './index.css'
import {createBrowserRouter, RouterProvider, useNavigate,} from "react-router-dom";
import Home from "./routes/home.tsx";
import Quests from "./routes/quests/quests.tsx";
import Objective from "./routes/quests/objective.tsx";
import LogIn, {action as logInAction} from "./routes/login.tsx";
import SignUp, {action as signUpAction} from "./routes/signup.tsx";
import Infos from "./routes/quests/infos.tsx";
import {NextUIProvider} from "@nextui-org/react";
import {ThemeProvider} from "./providers/theme-provider.tsx";
import {UserProvider} from "./providers/user-provider.tsx";
import Root from "./routes/root.tsx";

const router = createBrowserRouter([
  {
    path: "/",
    element: <App/>,
    children: [
      {
        path: "",
        element: <Home/>,
      },
      {
        path: "login",
        element: <LogIn/>,
        action: logInAction
      },
      {
        path: "signup",
        element: <SignUp/>,
        action: signUpAction
      },
      {
        path: "quests",
        element: <Quests/>
      },
      {
        path: "quests/:questId",
        element: <Objective/>,
      },
      {
        path: "quests/:questId/info",
        element: < Infos/>,
      },
    ]
  },
]);

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <RouterProvider router={router}/>
  </StrictMode>
);


function App() {
  const navigate = useNavigate();
  return (
    <NextUIProvider className="min-h-screen" navigate={navigate}>
      <ThemeProvider>
        <UserProvider>
          <Root/>
        </UserProvider>
      </ThemeProvider>
    </NextUIProvider>
  )
} 