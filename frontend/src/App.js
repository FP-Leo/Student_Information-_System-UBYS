import { Outlet } from "react-router-dom";
import { Router } from "router/router";
import { useDispatch } from "react-redux";
import { setUserToken, setUserData } from "store/user/user.action";
import { useEffect } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import axios from "axios";
import { setProgram } from "store/program/program.action";

const App = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const location = useLocation();

  useEffect(() => {
    const user = JSON.parse(localStorage.getItem("userData"));
    const token = localStorage.getItem("token");
    const program = localStorage.getItem("program");
    if (token) {
      dispatch(setUserToken(token));
      dispatch(setUserData(user));
      dispatch(setProgram(program));
      const fetchUserData = async () => {
        try {
          const response = await axios.get(
            "http://localhost:5158/api/User/Student/Account/Details",
            {
              headers: {
                Authorization: `Bearer ${token}`,
              },
            }
          );
          console.log(response.data);
          dispatch(setUserData(response.data));
        } catch (err) {
          alert(err);
        }
      };
      //fetchUserData();

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
