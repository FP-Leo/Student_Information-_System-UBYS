import axios from "axios";

import { useEffect, useState } from "react";

import { useTheme } from "@mui/material/styles";
import { Box, Button, Typography } from "@mui/material";

import TableRow from "components/TableRow";
import TableHeader from "components/TableHeader";

import { useSelector } from "react-redux";
import { selectProgram } from "store/program/program.selector";

import { getToken } from "utils/helper-functions";

const Subjects = () => {
  const theme = useTheme();
  const program = useSelector(selectProgram);
  const [subjects, setSubjects] = useState([]);

  useEffect(() => {
    const token = getToken();
    axios
      .get(
        "http://localhost:5158/api/University/Faculty/Departments/Student/Courses/Details",
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
          params: { DepName: program },
        }
      )
      .then((response) => {
        setSubjects(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, [program]);

  return (
    <Box
      sx={{
        width: "100%",
        height: "auto",
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "center",
      }}
    >
      <Box
        sx={{
          width: "1200px",
          minWidth: "1200px",
          marginTop: "50px",
          borderRadius: "10px",
          boxShadow: theme.customShadows.card,
          backgroundColor: "background.neutral",
          paddingBottom: "30px",
          marginBottom: "50px",
        }}
      >
        <Box
          sx={{
            marginY: "20px",
            marginX: "35px",
          }}
        >
          <Typography variant="subtitle1">2023 - Bahar</Typography>
        </Box>
        <Box
          sx={{
            width: "100%",
            display: "grid",
            gridTemplateColumns: "1.5fr 2fr 1fr 1fr 3fr 2fr 2fr 1fr 2fr",
            borderLeft: "1px solid #B3B3B3",
            borderRight: "1px solid #B3B3B3",
          }}
        >
          <TableHeader left={false} right={true} title="Ders Kodu" />
          <TableHeader left={false} right={false} title="Ders Adı" />
          <TableHeader left={true} right={true} title="Kredi" />
          <TableHeader left={false} right={true} title="AKTS" />
          <TableHeader left={false} right={false} title="Dersin Koordinatörü" />
          <TableHeader left={true} right={true} title="Devam Durumu" />
          <TableHeader left={false} right={false} title="Geçme Notu" />
          <TableHeader left={true} right={true} title="HBN" />
          <TableHeader left={false} right={false} title="Başarı Durumu" />
        </Box>
        {subjects.map((subject, index) => (
          <TableRow key={index} data={subject} />
        ))}
      </Box>
      <Box sx={{ margin: "50px" }}>
        <Button
          type="submit"
          size="large"
          variant="contained"
          style={{
            height: "50px",
            borderRadius: "12px",
            marginTop: "60px",
          }}
          fullWidth={true}
        >
          Geçmiş Dönem Derslerini Göster
        </Button>
      </Box>
    </Box>
  );
};

export default Subjects;
