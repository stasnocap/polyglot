import {StrictMode} from 'react'
import {createRoot} from 'react-dom/client'
import {NextUIProvider} from '@nextui-org/react'
import './index.css'
import {createBrowserRouter, RouterProvider,} from "react-router-dom";
import ContactRoot, {loader as rootLoader, action as rootAction} from "./routes/contacts/contacts-root.tsx";
import Contact, {loader as contactLoader, action as contactAction,} from "./routes/contacts/contact";
import EditContact, {action as editAction,} from "./routes/contacts/edit";
import {action as destroyAction} from "./routes/contacts/destroy";
import {loader as exerciseLoader} from "./routes/lessons/exercise.tsx";

import ErrorPage from "./error-page.tsx";
import Index from "./routes/contacts/index";
import Root from "./routes/root.tsx";
import Weather from "./components/weather.tsx";
import Home from "./routes/home.tsx";
import Lessons from "./routes/lessons/lessons.tsx";
import Exercise from "./routes/lessons/exercise.tsx";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Root/>,
    children: [
      {
        path: "",
        element: <Home />,
      },
      {
        path: "lessons",
        element: <Lessons />
      },
      {
        path: "lessons/:lessonId",
        element: <Exercise />,
        loader: exerciseLoader,
      },
      {
        path: "weather",
        element: <Weather/>
      },
      {
        path: "contacts",
        element: <ContactRoot/>,
        errorElement: <ErrorPage/>,
        loader: rootLoader,
        action: rootAction,
        children: [
          {
            errorElement: <ErrorPage/>,
            children: [
              {index: true, element: <Index/>},
              {
                path: ":contactId",
                element: <Contact/>,
                loader: contactLoader,
                action: contactAction,
              },
              {
                path: ":contactId/edit",
                element: <EditContact/>,
                loader: contactLoader,
                action: editAction,
              },
              {
                path: ":contactId/destroy",
                action: destroyAction,
                errorElement: <div>Oops! There was an error.</div>,
              },
            ]
          }
        ],
      },
    ]
  },
]);

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <NextUIProvider className="h-full w-full">
      <RouterProvider router={router} />
    </NextUIProvider>
  </StrictMode>,
)
