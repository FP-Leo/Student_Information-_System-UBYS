import { Outlet } from "react-router-dom";
import { Router } from "router/router";
const App = () => {
  return (
    <>
      <Router />
      <Outlet />
    </>
  );
};

export default App;
