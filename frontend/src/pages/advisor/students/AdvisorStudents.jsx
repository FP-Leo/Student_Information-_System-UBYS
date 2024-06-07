import { useEffect, useRef, useState } from "react";
import axios from "axios";

import generatePDF from "react-to-pdf";

import { useTheme } from "@mui/material/styles";
import { Box, Button, Typography } from "@mui/material";

import StudentTableRow from "./components/StudentTableRow";
import DownloadAsExcel from "./components/DownloadExcelFile";

import PdfIcon from "assets/pdf-icon";

import { getArrayFromObject } from "utils/helper-functions";

import { selectUserToken } from "store/user/user.selector";
import { useSelector } from "react-redux";

export const STUDENTS = [
  {
    id: 1,
    name: "Ali Veli",
    number: "200401114",
    program: "Bilgisayar Mühendisliği",
    status: "Sisteme Girmemiş",
    sinif: "1",
    debt: "0",
    state: "Aktif",
    stateDetail: "Ders Kaydi Yapmadı",
    gano: "2.5",
  },
  {
    id: 1,
    name: "Ali Veli",
    number: "200401114",
    program: "Bilgisayar Mühendisliği",
    status: "Sisteme Girmemiş",
    sinif: "1",
    debt: "0",
    state: "Aktif",
    stateDetail: "Ders Kaydi Yapmadı",
    gano: "2.5",
  },
  {
    id: 1,
    name: "Ali Veli",
    number: "200401114",
    program: "Bilgisayar Mühendisliği",
    status: "Sisteme Girmemiş",
    sinif: "1",
    debt: "0",
    state: "Aktif",
    stateDetail: "Ders Kaydi Yapmadı",
    gano: "2.5",
  },
  {
    id: 1,
    name: "Ali Veli",
    number: "200401114",
    program: "Bilgisayar Mühendisliği",
    status: "Sisteme Girmemiş",
    sinif: "1",
    debt: "0",
    state: "Aktif",
    stateDetail: "Ders Kaydi Yapmadı",
    gano: "2.5",
  },
  {
    id: 1,
    name: "Ali Veli",
    number: "200401114",
    program: "Bilgisayar Mühendisliği",
    status: "Sisteme Girmemiş",
    sinif: "1",
    debt: "0",
    state: "Aktif",
    stateDetail: "Ders Kaydi Yapmadı",
    gano: "2.5",
  },
];

const AdvisorStudents = () => {
  const token = useSelector(selectUserToken);
  const [students, setStudents] = useState([]);
  const theme = useTheme();
  const targetRef = useRef();
  const dataAsArray = getArrayFromObject(STUDENTS);

  useEffect(() => {
    axios
      .get("http://localhost:5158/api/University/Students", {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
      .then((res) => {
        setStudents(res.data);
      })
      .catch((err) => console.log(err));
  }, []);

  return (
    <Box
      sx={{
        marginY: 4,
        display: "flex",
        alignItems: "center",
        flexDirection: "column",
        width: "100%",
        paddingX: 6,
      }}
    >
      <Box sx={{ width: "100%" }}>
        <Typography variant="subtitle1">
          Danışmanı Olduğum Öğrenciler
        </Typography>
      </Box>
      <Box
        sx={{
          marginTop: 3,
          width: "50%",
          display: "flex",
          justifyContent: "space-around",
        }}
      >
        <Button
          sx={{ height: "45px" }}
          startIcon={<PdfIcon color="#ffffff" />}
          variant="contained"
          onClick={() => generatePDF(targetRef, { filename: "page.pdf" })}
        >
          Listeyi PDF olarak al.
        </Button>
        <DownloadAsExcel data={dataAsArray} />
      </Box>
      <Box
        ref={targetRef}
        sx={{
          overflowY: "scroll",
          borderRadius: 2,
          boxShadow: theme.customShadows.z8,
          backgroundColor: theme.palette.common.white,
          padding: 1,
          marginTop: 3,
          width: "100%",
        }}
      >
        <Box
          sx={{
            backgroundColor: theme.palette.background.paper,
            width: "100%",
            display: "grid",
            height: "50px",
            border: `1px solid ${theme.palette.grey[500]}`,
            justifyContent: "center",
            alignItems: "center",
            gridTemplateColumns: "0.8fr 1.5fr 2.5fr 3fr 1.2fr 1fr  1fr 1fr",
          }}
        >
          <Box
            sx={{
              height: "100%",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              borderRight: `1px solid ${theme.palette.grey[500]}`,
            }}
          >
            <Typography variant="subtitle2">Resim</Typography>
          </Box>
          <Box
            sx={{
              height: "100%",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              borderRight: `1px solid ${theme.palette.grey[500]}`,
            }}
          >
            <Typography variant="subtitle2">Numerası</Typography>
          </Box>{" "}
          <Box
            sx={{
              height: "100%",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              borderRight: `1px solid ${theme.palette.grey[500]}`,
            }}
          >
            <Typography variant="subtitle2">Ad Soyad</Typography>
          </Box>{" "}
          <Box
            sx={{
              height: "100%",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              borderRight: `1px solid ${theme.palette.grey[500]}`,
            }}
          >
            <Typography variant="subtitle2">Akademik Program</Typography>
          </Box>{" "}
          <Box
            sx={{
              height: "100%",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              borderRight: `1px solid ${theme.palette.grey[500]}`,
            }}
          >
            <Typography textAlign="center" variant="subtitle2">
              Kayıtlanma Aşaması
            </Typography>
          </Box>{" "}
          <Box
            sx={{
              height: "100%",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              borderRight: `1px solid ${theme.palette.grey[500]}`,
            }}
          >
            <Typography variant="subtitle2">Sınıf</Typography>
          </Box>{" "}
          <Box
            sx={{
              height: "100%",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              borderRight: `1px solid ${theme.palette.grey[500]}`,
            }}
          >
            <Typography variant="subtitle2">GANO</Typography>
          </Box>{" "}
          <Box
            sx={{
              height: "100%",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
            }}
          >
            <Typography variant="subtitle2">İşlemler</Typography>
          </Box>
        </Box>
        {students.map((student, index) => {
          const { ssn, name, departments } = student;
          return departments.map((program, index) => (
            <StudentTableRow key={index} ssn={ssn} name={name} data={program} />
          ));
        })}
      </Box>
    </Box>
  );
};

export default AdvisorStudents;
