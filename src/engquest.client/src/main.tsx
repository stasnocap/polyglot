import {StrictMode} from 'react'
import {createRoot} from 'react-dom/client'
import {NextUIProvider} from '@nextui-org/react'
import './index.css'
import {createBrowserRouter, RouterProvider,} from "react-router-dom";
import ContactRoot, {loader as rootLoader, action as rootAction} from "./routes/contacts/contacts-root.tsx";
import Contact, {loader as contactLoader, action as contactAction,} from "./routes/contacts/contact";
import EditContact, {action as editAction,} from "./routes/contacts/edit";
import {action as destroyAction} from "./routes/contacts/destroy";

import ErrorPage from "./error-page.tsx";
import Index from "./routes/contacts/index";
import Root from "./routes/root.tsx";
import Weather from "./components/weather.tsx";
import Home from "./routes/home.tsx";
import Quests from "./routes/quests/quests.tsx";
import Objective from "./routes/quests/objective.tsx";
import LogIn, {action as logInAction} from "./routes/login.tsx";
import SignUp, {action as signUpAction} from "./routes/signup.tsx";
import {UserProvider} from "./providers/user-provider.tsx";
import {ThemeProvider} from "./providers/theme-provider.tsx";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Root/>,
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
    ]
  },
]);

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <NextUIProvider className="min-h-screen">
      <ThemeProvider>
        <UserProvider>
          <RouterProvider router={router}/>
        </UserProvider>
      </ThemeProvider>
    </NextUIProvider>
  </StrictMode>,
);