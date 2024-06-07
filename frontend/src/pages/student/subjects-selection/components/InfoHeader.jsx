import { Box, Typography, Button } from "@mui/material";
import SendIcon from "assets/send-icon";
import axios from "axios";
import { useSelector } from "react-redux";
import { selectUserToken } from "store/user/user.selector";
import { selectProgram } from "store/program/program.selector";
import { selectSelectedSubjects } from "store/ders-secimi/ders-secimi.selector";

const InfoHeader = ({ details }) => {
  //const { currentSemester, currentSchoolYear } = details;
  const token = useSelector(selectUserToken);
  const department = useSelector(selectProgram);
  const selectedSubjects = useSelector(selectSelectedSubjects);

  const handleSend = () => {
    const codes = [];
    selectedSubjects.map((subject) => {
      codes.push(subject.courseCode);
    });

    axios
      .post(
        "http://localhost:5158/api/University/Faculty/Department/Semester/Student/Courses/Select",
        {
          departmentName: department,
          selectedCoursesCodes: codes,
        },
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      )
      .then((res) => {
        console.log(res);
      })
      .catch((err) => {
        console.log(err);
        alert(err);
      });
  };

  const currentSemester = "2021-2022 Bahar";
  const currentSchoolYear = "4. Sınıf";

  return (
    <Box
      sx={{
        paddingX: "50px",
        width: "100%",
        height: "50px",
        backgroundColor: "#E9E9EA",
        display: "flex",
        justifyContent: "space-between",
        alignItems: "center",
      }}
    >
      <Box
        sx={{
          display: "flex",
        }}
      >
        <Box
          sx={{
            display: "flex",
          }}
        >
          <Typography variant="subtitle1">Danışman: </Typography>
          <Typography
            style={{
              marginLeft: "10px",
            }}
          >
            Doç. Dr. Erlindi İsaj
          </Typography>
        </Box>
        <Typography
          style={{
            margin: "0 15px",
          }}
          color={"text.disabled"}
        >
          /
        </Typography>
        <Box
          sx={{
            display: "flex",
          }}
        >
          <Typography variant="subtitle1">Sınıf: </Typography>
          <Typography
            style={{
              marginLeft: "10px",
            }}
            color={"text.disabled"}
          >
            {currentSchoolYear}
          </Typography>
        </Box>
        <Typography
          style={{
            margin: "0 15px",
          }}
          color={"text.disabled"}
        >
          /
        </Typography>
        <Box
          sx={{
            display: "flex",
          }}
        >
          <Typography variant="subtitle1">Ders Dönemi: </Typography>
          <Typography
            style={{
              marginLeft: "10px",
            }}
          >
            {currentSemester}
          </Typography>
        </Box>
        <Typography
          style={{
            margin: "0 15px",
          }}
          color={"text.disabled"}
        >
          /
        </Typography>
        <Box
          sx={{
            display: "flex",
          }}
        >
          <Typography variant="subtitle1">Durum: </Typography>
          <Typography
            style={{
              marginLeft: "10px",
            }}
            variant="cardHeader"
          >
            Ders Seçimi
          </Typography>
        </Box>
      </Box>
      <Button
        style={{
          color: "white",
          borderRadius: "10px",
          height: "40px",
        }}
        variant="contained"
        color="success"
        onClick={handleSend}
      >
        Danışmanına Gönder &nbsp;
        <SendIcon />
      </Button>
    </Box>
  );
};

export default InfoHeader;
