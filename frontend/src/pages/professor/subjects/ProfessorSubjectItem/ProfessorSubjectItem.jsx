import { Box, Button, Checkbox, Typography } from "@mui/material";
import axios from "axios";
import Islemler from "pages/professor/islemler/Islemler";
import { useEffect, useState } from "react";

export default function ProfessorSubjectItem({
  yil,
  dersAdi,
  dersBirimi,
  dersKodu,
  dersFakulte,
  course,
}) {
  const [selectedSubject, setSelectedSubject] = useState(false);

  const handleSelectedSubject = () => {
    setSelectedSubject(!selectedSubject);
  };

  const [islemler, setIslemler] = useState(false);
  const [courseSize, setCourseSize] = useState(0);

  const handleIslemler = () => {
    setIslemler(!islemler);
  };
  const PORT = 5158;
  const handleGetSubjectStudents = async () => {
    axios
      .get(
        `http://localhost:5158/api/University/Faculty/Departments/Course/Students/Details`,
        {
          headers: {
            Authorization:
              "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiMTAwMDAwMDAwMDMiLCJyb2xlIjoiTGVjdHVyZXIiLCJuYmYiOjE3MTc1MTkyNzAsImV4cCI6MTcxODEyNDA3MCwiaWF0IjoxNzE3NTE5MjcwLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUyNDYiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUyNDYifQ.eu4xmuFF1i0qXNN9O19aUcDAsn4PLBgsx7SEbpSRTc0Q2pR1jrkJ24Qw829eFcrVq9_q7dNit03P8ZrwzQi2Gg",
          },
          params: { CourseCode: dersKodu },
        }
      )
      .then((response) => setCourseSize(response.data.students));
  };

  useEffect(() => {
    handleGetSubjectStudents();
  }, []);

  return (
    <>
      {islemler === false ? (
        <Box>
          <Box
            sx={{
              width: "100%",
              display: "grid",
              height: "75px",
              gridTemplateRows: "1fr 1fr 1fr 1fr",
              gridTemplateColumns: "1.25fr 1.75fr 1.5fr 2.5fr 1.5fr 2.5fr",
              borderBottom: "1px solid #B3B3B3",
              borderLeft: "1px solid #B3B3B3",
              borderRight: "1px solid #B3B3B3",
              textAlign: "center",
            }}
          >
            <Box
              sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                gridRow: "1/5",
                borderRight: "1px solid #B3B3B3",
              }}
            >
              <Checkbox
                checked={selectedSubject}
                onChange={handleSelectedSubject}
                inputProps={{ "aria-label": "controlled" }}
                color="success"
                size="large"
              />
            </Box>
            <Box
              sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                gridRow: "1/5",
              }}
            >
              <Typography variant="body2" sx={{ textAlign: "center" }}>
                {dersFakulte}-{dersBirimi}
              </Typography>
            </Box>
            <Box
              sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                gridRow: "1/5",
                borderRight: "1px solid #B3B3B3",
                borderLeft: "1px solid #B3B3B3",
                textAlign: "center",
              }}
            >
              <Typography variant="body2">{dersKodu}</Typography>
            </Box>
            <Box
              sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                gridRow: "1/5",
                borderRight: "1px solid #B3B3B3",
              }}
            >
              <Typography variant="body2">{dersAdi}</Typography>
            </Box>
            <Box
              sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                gridRow: "1/5",
              }}
            >
              <Typography variant="body2">{yil}</Typography>
            </Box>
            <Box
              sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                gridRow: "1/5",
                borderLeft: "1px solid #B3B3B3",
              }}
            >
              <Button onClick={handleIslemler}>
                <Typography variant="body2">İşlemler</Typography>
              </Button>
            </Box>
          </Box>
        </Box>
      ) : (
        <Islemler
          courseSize={courseSize}
          show={islemler}
          setIslemler={setIslemler}
          course={course}
          faculty={dersFakulte}
          department={dersBirimi}
        />
      )}
    </>
  );
}
