import { Box, Button, Checkbox, Typography } from "@mui/material";
import axios from "axios";
import Islemler from "pages/professor/islemler/Islemler";
import { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { selectUserToken } from "store/user/user.selector";

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
  const token = useSelector(selectUserToken);
  

  const handleIslemler = () => {
    setIslemler(!islemler);
  };
  const handleGetSubjectStudents = async () => {
    axios
      .get(
        `http://localhost:5158/api/University/Faculty/Departments/Course/Students/Details`,
        {
          headers: {
              Authorization: `Bearer ${token}`,
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
