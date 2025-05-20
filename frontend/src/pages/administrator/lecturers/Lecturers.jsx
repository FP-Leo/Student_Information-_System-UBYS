import { useTheme } from "@mui/material/styles";
import { Box, Typography } from "@mui/material";
import axios from "axios";
import LecturerTableRow from "./components/LecturerTableRow";
import { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { selectUserToken } from "store/user/user.selector";



const Lecturers = () => {
  const theme = useTheme();
  const token = useSelector(selectUserToken);
  const [data, setData] = useState([]);
  useEffect(() => {
    axios
      .get(
        "http://localhost:5158/api/University/Faculty/Administrator/Lecturers",
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      )
      .then((res) => {
        setData(res.data);
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
        marginY: 5,
      }}
    >
      <Typography variant="subtitle1">Lecturers List</Typography>
      <Box
        sx={{
          overflowY: "scroll",
          borderRadius: 2,
          boxShadow: theme.customShadows.z8,
          backgroundColor: theme.palette.common.white,
          padding: 1,
          marginTop: 3,
          width: "80%",
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
            gridTemplateColumns: "0.8fr 1.5fr 2.5fr 3fr 1.2fr 1fr",
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
            <Typography variant="subtitle2">Fakülte/Bölüm</Typography>
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
            <Typography variant="subtitle2">Durum</Typography>
          </Box>{" "}
          <Box
            sx={{
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
            }}
          >
            <Typography variant="subtitle2">İşlemler</Typography>
          </Box>
        </Box>
        {data.map((lecturer, index) => (
          <LecturerTableRow data={lecturer} key={index} />
        ))}
      </Box>
    </Box>
  );
};
export default Lecturers;
