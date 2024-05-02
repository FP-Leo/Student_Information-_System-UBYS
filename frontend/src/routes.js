import { Navigate, useRoutes } from "react-router-dom";

import AuthPage from "./pages/auth/auth";
import MainScreen from "./pages/main-screen/main-screen";

import NotFoundPage from "./pages/404-notfound";

export default function Router() {
  const routes = useRoutes([
    {
      path: "/",
      element: <AuthPage />,
    },
    {
      path: "/mainScreen",
      element: <MainScreen />,
    },

    {
      path: "*",
      element: <Navigate to="/404" replace />,
    },
    {
      path: "/404",
      element: <NotFoundPage />,
    },
  ]);

  return routes;
}
