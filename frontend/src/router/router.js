import { useRoutes } from "react-router-dom";

import Loadable from "components/Loadable.jsx";
import { lazy } from "react";

import MainLayout from "layout/main-layout";

import StudentRoutes from "./role-based-routers/StudentRoutes.js";
import LecturerRoutes from "./role-based-routers/LecturerRoutes.js";

import { useSelector } from "react-redux";
import { selectCurrentUser } from "store/user/user.selector";

import { ROLE_TYPES } from "./role.types.js";

const ProtectedRoute = Loadable(
  lazy(() => import("router/ProtectedRoute.jsx"))
);
const NotFound = Loadable(lazy(() => import("pages/404-notfound.jsx")));
const Auth = Loadable(lazy(() => import("pages/auth/auth.jsx")));

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
