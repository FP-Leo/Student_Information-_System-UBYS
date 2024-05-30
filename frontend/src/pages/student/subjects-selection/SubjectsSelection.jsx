import { Box } from "@mui/material";

import InfoHeader from "./components/InfoHeader";
import SecDersler from "./components/Secdersler";
import SeciliDersler from "./components/SeciliDersler";

const SubjectsSelection = () => {
  return (
    <Box sx={{ width: "100%" }}>
      <InfoHeader />
      <Box
        display="flex"
        sx={{ justifyContent: "center", alignItems: "flex-start" }}
      >
        <SeciliDersler />
        <SecDersler />
      </Box>
    </Box>
  );
};

export default SubjectsSelection;
