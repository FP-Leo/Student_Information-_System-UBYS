import { Box, Typography, Button } from "@mui/material";
import InfoHeader from "./components/InfoHeader";
import SeciliDersler from "./components/SeciliDersler";

const SubjectsSelection = () => {
  return (
    <Box sx={{ width: "100%" }}>
      <InfoHeader />
      <SeciliDersler />
    </Box>
  );
};

export default SubjectsSelection;
