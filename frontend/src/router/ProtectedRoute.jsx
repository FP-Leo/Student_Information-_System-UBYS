import { useEffect } from "react";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { selectUserToken } from "store/user/user.selector";

const ProtectedRoute = ({ children }) => {
  const navigate = useNavigate();
  const currentUser = useSelector(selectUserToken);

  useEffect(() => {
    if (currentUser === null) navigate("/", { replace: true });
  }, [currentUser, navigate]);

  return children;
};

export default ProtectedRoute;
