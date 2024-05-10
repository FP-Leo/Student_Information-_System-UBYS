import { Box } from "@mui/material";
import Navbar from "pages/main-screen/Navbar";
import { Outlet } from "react-router-dom";
const MainLayout = () => {
  return (
    <Box sx={{ backgroundColor: "background.custom" }}>
      <Navbar />
      <Outlet />
    </Box>
  );
};

export default MainLayout;
