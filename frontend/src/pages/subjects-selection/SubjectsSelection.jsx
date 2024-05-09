import { Box, Typography, Button } from "@mui/material";
import InfoHeader from "./components/InfoHeader";
import SeciliDersler from "./components/SeciliDersler";
import SecDersler from "./components/Secdersler";

const SubjectsSelection = () => {
  return (
    <Box sx={{ width: "100%" }}>
      <InfoHeader />
      <Box
        display="flex"
        sx={{ justifyContent: "center", border: "1px solid red" }}
      >
        <SeciliDersler />
        <SecDersler />
      </Box>
    </Box>
  );
};

export default SubjectsSelection;
