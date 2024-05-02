import { useRoutes } from "react-router-dom";

import AuthPage from "./pages/auth/auth";

export default function Router() {
  const routes = useRoutes([
    {
      path: "/",
      element: <AuthPage />,
    },
  ]);

  return routes;
}
