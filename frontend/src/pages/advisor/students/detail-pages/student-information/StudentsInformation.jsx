import {
  Box,
  Table,
  TableContainer,
  Typography,
  TableBody,
} from "@mui/material";
import { useTheme, alpha } from "@mui/material/styles";

import SubjectTableRow from "./components/SubjectTableRow";
import SubjectTableHead from "./components/SubjectTableHead";
import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { selectUserToken } from "store/user/user.selector";
import { selectProgram } from "store/program/program.selector";
import axios from "axios";
const StudentsInformation = () => {
  const theme = useTheme();
  const { id } = useParams();
  const [semesters, setSemesters] = useState([]);
  const [studentInfo, setStudentInfo] = useState();
  const [depInfo, setDepInfo] = useState();
  const token = useSelector(selectUserToken);
  const program = useSelector(selectProgram);

  useEffect(() => {
    axios
      .get(
        "http://localhost:5158/api/University/Faculty/Department/Student/Transcript",
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
          params: {
            DepName: program,
            SSN: id,
          },
        }
      )
      .then((res) => {
        console.log(res.data);
        setStudentInfo(res.data.studentInfo);
        setDepInfo(res.data.departmentInfo);
        setSemesters(res.data.semesters);
      })
      .catch((err) => console.log(err));
  }, []);

  return (
    <Box
      sx={{
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        width: "100%",
      }}
    >
      <Box
        sx={{
          marginY: 3,
          paddingLeft: 10,
          width: "100%",
          display: "flex",
        }}
      >
        <Typography variant="subtitle1">Öğrenci Bilgileri</Typography>
      </Box>
      <Box
        sx={{
          padding: 2,
          width: "90%",
          backgroundColor: theme.palette.common.white,
          border: `1px solid ${theme.palette.grey[300]}`,
          borderRadius: 1,
          boxShadow: theme.customShadows.z4,
        }}
      >
        <Box
          sx={{
            display: "grid",
            gridTemplateColumns: "0.7fr 3fr",
          }}
        >
          <Box
            sx={{
              display: "flex",
              flexDirection: "column",
              alignItems: "flex-start",
            }}
          >
            <Typography variant="caption">Öğrenci Numerası:</Typography>
            <Typography variant="caption">Adı:</Typography>
            <Typography variant="caption">Programı:</Typography>
            <Typography variant="caption">TC:</Typography>
          </Box>
          <Box
            sx={{
              display: "flex",
              flexDirection: "column",
              alignItems: "flex-start",
            }}
          >
            <Typography variant="caption2">{studentInfo.ssn}</Typography>
            <Typography variant="caption2">
              {studentInfo.firstName + " " + studentInfo.lastName}
            </Typography>
            <Typography variant="caption2">
              {depInfo.facultyName + " / " + depInfo.departmentName}
            </Typography>
            <Typography variant="caption2">{+studentInfo.tc}</Typography>
          </Box>
        </Box>
        {console.log(semesters)}
        {semesters.map((item, index) => (
          <Box
            key={index}
            sx={{
              marginTop: 2,
            }}
          >
            <Box
              sx={{
                padding: 2,
                backgroundColor: theme.palette.grey[200],
              }}
            >
              <Typography variant="subtitle1">donem</Typography>
            </Box>

            <TableContainer
              sx={{
                boxShadow: "none",
                borderRadius: "none",
                backgroundColor: alpha(theme.palette.background.default, 0.9),
              }}
            >
              <Table
                sx={{
                  boxShadow: "none",
                  borderRadius: "none",
                }}
              >
                <SubjectTableHead />
                <TableBody>
                  {item.courses.map((subject, index) => (
                    <SubjectTableRow key={index} subject={subject} />
                  ))}
                </TableBody>
              </Table>
            </TableContainer>
          </Box>
        ))}
      </Box>
    </Box>
  );
};
export default StudentsInformation;
