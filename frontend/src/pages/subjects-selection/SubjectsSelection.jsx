
import { Box } from "@mui/material";
import InfoHeader from "./components/InfoHeader";
import SecDersler from "./components/Secdersler";
import SeciliDersler from "./components/SeciliDersler";

const SubjectsSelection = () => {
  return (
    <Box sx={{ width: "100%"}}>
      <InfoHeader />
      <Box
        display="flex"
        sx={{ justifyContent: "center", border: "1px solid red" ,pb:2}}
      >
        <SeciliDersler />
        <SecDersler />
      </Box>
    </Box>
  );
};

export default SubjectsSelection;
