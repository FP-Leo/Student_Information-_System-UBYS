import { useRoutes } from "react-router-dom";

import Auth from "../pages/auth/auth.jsx";
import NotFound from "../pages/404-notfound.jsx";
import MainLayout from "layout/main-layout";

import ProtectedRoute from "./ProtectedRoute";
import StudentRoutes from "./role-based-routers/StudentRoutes.js";
import LecturerRoutes from "./role-based-routers/LecturerRoutes.js";

import { useSelector } from "react-redux";
import { selectCurrentUser } from "store/user/user.selector";

import { ROLE_TYPES } from "./role.types.js";

export const Router = () => {
  const currentUser = useSelector(selectCurrentUser);
  const isStudent = currentUser?.role === ROLE_TYPES.STUDENT;
  const isLecturer = currentUser?.role === ROLE_TYPES.LECTURER;

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
      children: isStudent ? StudentRoutes : isLecturer ? LecturerRoutes : null,
    },
    {
      path: "*",
      element: <NotFound />,
    },
  ]);
};
