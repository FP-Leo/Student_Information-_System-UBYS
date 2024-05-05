import { Box } from "@mui/material";
import MainScreenCategories from "./MainScreenCategories";
import Navbar from "./Navbar";

const MainScreen = () => {
  return (
    <Box sx={{ backgroundColor: "background.custom" }}>
      <Navbar />
      <Box>
        <MainScreenCategories />
      </Box>
    </Box>
  );
};

export default MainScreen;
