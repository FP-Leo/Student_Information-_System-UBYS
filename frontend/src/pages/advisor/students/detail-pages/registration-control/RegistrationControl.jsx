import { Box } from "@mui/material";

import StudentInfo from "./components/StudentInfo";
import AdvisorInfo from "./components/AdvisorInfo";
import SubjectsList from "./components/SubjectsList";

const RegistrationControl = () => {
  return (
    <Box
      sx={{
        width: "100%",
        display: "flex",
        flexDirection: "column",
        padding: 3,
      }}
    >
      <Box
        sx={{
          display: "flex",
        }}
      >
        <StudentInfo />
        <AdvisorInfo />
      </Box>
      <SubjectsList />
    </Box>
  );
};

export default RegistrationControl;
