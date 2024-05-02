import { Outlet } from "react-router-dom";
import Router from "./routes";
import ThemeCustomization from "./themes";

const App = () => {
  return (
    <ThemeCustomization>
      <Router />
      <Outlet />
    </ThemeCustomization>
  );
};

export default App;
