import { useRoutes } from "react-router-dom";

import Auth from "../pages/auth/auth.jsx";
import NotFound from "../pages/404-notfound.jsx";
import MainLayout from "layout/main-layout";

import ProtectedRoute from "./ProtectedRoute";
import StudentRoutes from "./role-based-routers/StudentRoutes.js";
import ProfessorRoutes from "./role-based-routers/ProfessorRoutes.js";

import { useSelector } from "react-redux";
import { selectCurrentUser } from "store/user/user.selector";

export const Router = () => {
  const currentUser = useSelector(selectCurrentUser);
  const isStudent = currentUser?.role === "Student";
  const isProfessor = currentUser?.role === "Professor";

  return useRoutes([
    {
      path: "/",
      element: <Auth />,
      index: true,
    },
    {
      path: "home",
      element: (
        <ProtectedRoute>
          <MainLayout />
        </ProtectedRoute>
      ),
      children: isStudent
        ? StudentRoutes
        : isProfessor
        ? ProfessorRoutes
        : null,
    },
    {
      path: "*",
      element: <NotFound />,
    },
  ]);
};
