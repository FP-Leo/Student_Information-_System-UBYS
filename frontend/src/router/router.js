import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import Auth from "../pages/auth/auth.jsx";
<<<<<<< HEAD
import NotFound from "../pages/404-notfound.jsx";
import Subjects from "pages/subjects/subjects";
import MainLayout from "layout/main-layout";
import MainScreenCategories from "pages/main-screen/MainScreenCategories";
import SubjectsSelection from "pages/subjects-selection/SubjectsSelection";
=======
import MainScreen from "../pages/main-screen/main-screen.jsx";
import NotFound from "../pages/404-notfound.jsx";
import Derslerim from "pages/subjects/Derslerim";
>>>>>>> frontend-main

export const router = createBrowserRouter([
  {
    path: "/",
    Component: App,
    children: [
      {
        // Auth Page
        path: "/", // path info
        Component: Auth, // which component related with this path
        index: true, // This means this path is root's default url
      },
      {
        // Main Page
<<<<<<< HEAD
        path: "home",
        Component: MainLayout,
        children: [
          {
            path: "",
            Component: MainScreenCategories,
          },
          {
            path: "derslerim",
            Component: Subjects,
          },
          {
            path: "ders-secimi",
            Component: SubjectsSelection,
          },
        ],
=======
        path: "/home",
        Component: MainScreen,
>>>>>>> frontend-main
      },
      {
        path: "*",
        Component: NotFound,
      },
      {
        path: "/404",
        Component: NotFound,
      },
<<<<<<< HEAD
=======
      {
        path: "/derslerim",
        Component: Derslerim,
      },
>>>>>>> frontend-main
    ],
  },
]);
