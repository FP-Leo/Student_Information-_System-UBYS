import {
  Box,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography,
} from "@mui/material";
import { useTheme } from "@mui/material/styles";

import LecturerSubjectRow from "../components/LecturerSubjectRow";
import { useEffect, useState } from "react";
import axios from "axios";
import { useSelector } from "react-redux";
import { selectUserToken } from "store/user/user.selector";
import { useParams } from "react-router-dom";

const LecturerSubjects = () => {
  const theme = useTheme();
  const params = useParams();
  const token = useSelector(selectUserToken);
  const [courses, setCourses] = useState([]);

  useEffect(() => {
    axios
      .get(
        "http://localhost:5158/api/University/Faculty/Administrator/Lecturer/Courses",
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
          params: {
            LecturerId: params.id,
          },
        }
      )
      .then((res) => {
        setCourses(res.data);
      })
      .catch((err) => {
        alert(err);
      });
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
          width: "100%",
          marginTop: 5,
          paddingX: 10,
        }}
      >
        <Typography variant="subtitle1">Lecturer Subjects</Typography>
      </Box>
      <Box
        sx={{
          width: "80%",
          marginTop: 3,
        }}
      >
        <TableContainer
          sx={{
            borderRadius: "10px",
            backgroundColor: theme.palette.common.white,
            boxShadow: theme.customShadows.z8,
          }}
        >
          <Table>
            <TableHead
              sx={{
                backgroundColor: theme.palette.grey[300],
              }}
            >
              <TableRow>
                <TableCell>Ders Kodu</TableCell>
                <TableCell
                  sx={{
                    width: "30%",
                  }}
                >
                  Ders Adı
                </TableCell>
                <TableCell
                  sx={{
                    width: "30%",
                  }}
                >
                  Fakülte / Bölüm
                </TableCell>
                <TableCell>Kredi</TableCell>
                <TableCell>AKTS</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {courses.map((course, index) => {
                return <LecturerSubjectRow data={course} key={index} />;
              })}
            </TableBody>
          </Table>
        </TableContainer>
      </Box>
    </Box>
  );
};
export default LecturerSubjects;
