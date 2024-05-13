import { Box } from "@mui/material";
import Navbar from "layout/Navbar";
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
