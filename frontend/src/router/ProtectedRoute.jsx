import { useEffect } from "react";
import { selectUserToken } from "store/user/user.selector";
import { useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";

const ProtectedRoute = ({ children }) => {
  const navigate = useNavigate();
  const currentUser = useSelector(selectUserToken);

  useEffect(() => {
    if (currentUser === null) navigate("/", { replace: true });
  }, [currentUser, navigate]);

  return children;
};

export default ProtectedRoute;
