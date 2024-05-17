import { Box } from "@mui/material";
import { AuthBackground } from "./auth.styles";

import Image from "../../assets/background-image.png";
import Login from "./log-in.jsx/log-in";

const AuthPage = () => {
  return (
    <Box
      display="flex"
      justifyContent="center"
      alignItems="center"
      sx={{
        backgroundImage: `url(${Image})`,
        backgroundRepeat: "no-repeat",
        backgroundSize: "cover",
        width: 1,
        height: "100vh",
      }}
    >
      <AuthBackground>
        <Box width={1}>
          <Login />
        </Box>
      </AuthBackground>
    </Box>
  );
};

export default AuthPage;
