import { lazy } from "react";

import { useSelector } from "react-redux";

import { useRoutes } from "react-router-dom";

import { selectUserData } from "store/user/user.selector";

import StudentRoutes from "./role-based-routers/StudentRoutes.js";
import LecturerRoutes from "./role-based-routers/LecturerRoutes.js";

import AdvisorRoutes from "./role-based-routers/AdvisorRoutes.js";
import AdministratorRoutes from "./role-based-routers/AdministratorRoutes.js";

import { ROLE_TYPES } from "./role.types.js";

import Loadable from "components/Loadable.jsx";

const ProtectedRoute = Loadable(
  lazy(() => import("router/ProtectedRoute.jsx"))
);
const Auth = Loadable(lazy(() => import("pages/auth/auth.jsx")));
const NotFound = Loadable(lazy(() => import("pages/404-notfound.jsx")));
const MainLayout = Loadable(lazy(() => import("layout/main-layout.jsx")));

export const Router = () => {
  const currentUser = useSelector(selectUserData);

  const isAdvisor = currentUser?.role === ROLE_TYPES.ADVISOR;
  const isStudent = currentUser?.role === ROLE_TYPES.STUDENT;
  const isLecturer = currentUser?.role === ROLE_TYPES.LECTURER;
  const isAdmin = currentUser?.role === ROLE_TYPES.ADMINISTRATOR;

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
        : isLecturer
        ? LecturerRoutes
        : isAdvisor
        ? AdvisorRoutes
        : isAdmin
        ? AdministratorRoutes
        : null,
    },
    {
      path: "*",
      element: <NotFound />,
    },
  ]);
};
