import { Container } from "@mui/material";
import MainScreenCategories from "../../components/MainScreen-Categories/MainScreenCategories";
import Navbar from "../../components/Shared/Navbar";

const MainScreen = () => {
  return (
    <div>
      <>
      <Navbar/>
      <Container sx={{my:10}}>
      <MainScreenCategories/>
      </Container>

      </>

    </div>
  );
};

export default MainScreen;
