import { Outlet } from "react-router-dom";
import ThemeCustomization from "./themes";

const App = () => {
  return (
    <ThemeCustomization>
      <Outlet />
    </ThemeCustomization>
  );
};

export default App;
