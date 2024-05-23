import { useRoutes } from "react-router-dom";

import Loadable from "components/Loadable.jsx";
import { lazy } from "react";

import StudentRoutes from "./role-based-routers/StudentRoutes.js";
import LecturerRoutes from "./role-based-routers/LecturerRoutes.js";

import { useSelector } from "react-redux";
import { selectCurrentUser } from "store/user/user.selector";

import { ROLE_TYPES } from "./role.types.js";
import AdvisorRoutes from "./role-based-routers/AdvisorRoutes.js";

const ProtectedRoute = Loadable(
  lazy(() => import("router/ProtectedRoute.jsx"))
);
const MainLayout = Loadable(lazy(() => import("layout/main-layout.jsx")));
const NotFound = Loadable(lazy(() => import("pages/404-notfound.jsx")));
const Auth = Loadable(lazy(() => import("pages/auth/auth.jsx")));

export const Router = () => {
  const currentUser = useSelector(selectCurrentUser);
  const isStudent = currentUser?.role === ROLE_TYPES.STUDENT;
  const isLecturer = currentUser?.role === ROLE_TYPES.LECTURER;
  const isAdvisor = currentUser?.role === ROLE_TYPES.ADVISOR;

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
        : null,
    },
    {
      path: "*",
      element: <NotFound />,
    },
  ]);
};
