import { useTheme } from "@emotion/react";
import { Avatar, Box, Button, TextField, Typography } from "@mui/material";
import Avatar1 from "assets/avatar1.png";
import React from "react";

export default function SınıfListeItem({ type }) {
  const typeGridTempColumns = {
    "Sınıf Görüntüle": "0.5fr 1fr 1fr 1fr",
    "Vize Sınav": "1fr 1.5fr 1.5fr 1.5fr 2fr",
    "Final Sınav": "1fr 1.5fr 1.5fr 1.5fr 2fr",
    "Bütünleme Listesi": "1fr 1.5fr 1.5fr 1fr 4fr",
    "Not Giriş": "1fr 1.5fr 1.5fr 1fr 4fr",
  };

  const theme = useTheme();

  const rastgeleOrtalamaSayi = Math.floor(Math.random() * (1, 60));

  let pageTemplate = <></>;
  switch (type) {
    case "Vize Sınav":
      pageTemplate = (
        <>
          <Box display={"flex"}>
            <Typography fontWeight={600} pr={1}>
              Vize Notu : 60
            </Typography>
          </Box>
        </>
      );
      break;
    case "Final Sınav":
      pageTemplate = (
        <>
          <Box display={"flex"}>
            <Typography fontWeight={600} pr={1}>
              Final Notu : 80
            </Typography>
          </Box>
        </>
      );
      break;
    case "Bütünleme Listesi":
      pageTemplate = (
        <>
          <Box
            display={"flex"}
            alignItems={"center"}
            justifyContent={"space-between"}
          >
            <Box display={"flex"} textAlign={"center"} paddingX={"20px"}>
              <Typography fontWeight={600} pr={1}>
                Ortalama:
              </Typography>
              <Typography>{rastgeleOrtalamaSayi}</Typography>
            </Box>
            <Box display={"flex"}>
              <Button
                sx={{
                  bgcolor: theme.palette.success.main,
                  marginRight: "10px",
                  ":hover": { backgroundColor: theme.palette.success.main },
                }}
              >
                {" "}
                Onayla{" "}
              </Button>
              <Button
                sx={{
                  bgcolor: theme.palette.error.main,
                  ":hover": { backgroundColor: theme.palette.error.main },
                }}
              >
                {" "}
                Reddet
              </Button>
            </Box>
          </Box>
        </>
      );
      break;
    case "Not Giriş":
      pageTemplate = (
        <>
          <Box
            display={"flex"}
          >
            <Box sx={{ paddingRight: "20px" }}>
              <TextField
                label="Vize"
                type="number"
                InputLabelProps={{
                  shrink: true,
                }}
                variant="outlined"
                size="small"
              />
            </Box>
            <Box sx={{ paddingRight: "20px" }}>
              <TextField
                label="Final"
                type="number"
                InputLabelProps={{
                  shrink: true,
                }}
                variant="outlined"
                size="small"
              />
            </Box>

            <Box sx={{ paddingRight: "10px" }}>
              <TextField
                label="Büt"
                type="number"
                InputLabelProps={{
                  shrink: true,
                }}
                variant="outlined"
                size="small"
              />
            </Box>
          </Box>
        </>
      );
      break;
    default:
      break;
  }
  return (
    <Box
      sx={{
        width: type === "Sınıf Görüntüle" ? "40vw" : "60vw",
        display: "grid",
        border: "1px solid #B3B3B3",
        gridTemplateColumns: typeGridTempColumns[type],
        alignItems: "center",
        height: "50px",
        paddingX: "10px",
      }}
    >
      <Avatar src={Avatar1}></Avatar>
      <Box display={"flex"}>
        <Typography fontWeight={600} pr={1}>
          Eren Nokta
        </Typography>
      </Box>
      <Box display={"flex"}>
        <Typography fontWeight={600} pr={1}>
          200401012
        </Typography>
      </Box>
      <Box display={"flex"}>
        <Typography fontWeight={600} pr={1}>
          4.Sınıf
        </Typography>
      </Box>
      {pageTemplate}
    </Box>
  );
}
