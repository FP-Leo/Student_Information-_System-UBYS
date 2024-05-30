import { Outlet } from "react-router-dom";

import Navbar from "layout/Navbar";

import { Box } from "@mui/material";

const MainLayout = () => {
  return (
    <Box sx={{ backgroundColor: "background.custom" }}>
      <Navbar />
      <Outlet />
    </Box>
  );
};

export default MainLayout;
