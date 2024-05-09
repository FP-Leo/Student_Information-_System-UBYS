import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import Auth from "../pages/auth/auth.jsx";
import NotFound from "../pages/404-notfound.jsx";
import Subjects from "pages/subjects/subjects";
import MainLayout from "layout/main-layout";
import MainScreenCategories from "pages/main-screen/MainScreenCategories";
import SubjectsSelection from "pages/subjects-selection/SubjectsSelection";

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
      },
      {
        path: "*",
        Component: NotFound,
      },
      {
        path: "/404",
        Component: NotFound,
      },
    ],
  },
]);
