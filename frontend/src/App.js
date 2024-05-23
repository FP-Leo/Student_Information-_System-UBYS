import { Outlet } from "react-router-dom";
import { Router } from "router/router";
import { useDispatch } from "react-redux";
import { setCurrentUser } from "store/user/user.action";
import { useEffect } from "react";
import { useLocation, useNavigate } from "react-router-dom";

const App = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const location = useLocation();

  useEffect(() => {
    const user = localStorage.getItem("user");
    if (user) {
      dispatch(setCurrentUser(JSON.parse(user)));
      if (location.pathname === "/") navigate("/home");
    } else navigate("/");
  }, []);
  return (
    <>
      <Router />
      <Outlet />
    </>
  );
};

export default App;
