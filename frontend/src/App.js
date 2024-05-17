import { Outlet } from "react-router-dom";
import ThemeCustomization from "./themes";
import { Router } from "router/router";
const App = () => {
  return (
    <ThemeCustomization>
      <Router />
      <Outlet />
    </ThemeCustomization>
  );
};

export default App;
