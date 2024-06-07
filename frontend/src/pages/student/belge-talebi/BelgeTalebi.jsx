import { useState } from "react";

import Select from "@mui/material/Select";
import MenuItem from "@mui/material/MenuItem";
import { useTheme } from "@mui/material/styles";
import InputLabel from "@mui/material/InputLabel";
import FormControl from "@mui/material/FormControl";
import { Box, Button, Typography } from "@mui/material";

import TableRow from "./components/TableRow";

import axios from "axios";
import { useSelector } from "react-redux";

import { useRef } from "react";
import { selectUserToken, selectUserData } from "store/user/user.selector";

import { selectProgram } from "store/program/program.selector";

const BelgeTablebi = () => {
  const theme = useTheme();
  const targetRef = useRef();
  const token = useSelector(selectUserToken);
  const user = useSelector(selectUserData);
  const program = useSelector(selectProgram);
  const [document, setDocument] = useState("");
  const [language, setLanguage] = useState("");
  const [documents, setDocuments] = useState([]);

  const handleDocumentChange = (event) => {
    setDocument(event.target.value);
  };
  const handleLanguageChange = (event) => {
    setLanguage(event.target.value);
  };

  const handleDocumentRequest = async () => {
    if (!document || !language) alert("Lütfen tüm alanları doldurunuz.");
    else {
      document === 10
        ? await axios
            .get(
              "http://localhost:5158/api/University/Faculty/Department/Student/Transcript",
              {
                headers: {
                  Authorization: `Bearer ${token}`,
                },
                params: { DepName: program, SSN: user.ssn },
              }
            )
            .then((res) => {
              setDocuments([
                ...documents,
                {
                  ...res.data,
                  id: documents.length + 10000000,
                  date: new Date().toLocaleDateString(),
                  language: "Turkish",
                  status: "Onaylandı",
                  type: "Transcript",
                },
              ]);
              //generatePdf();
            })
            .catch((err) => {
              console.log(err);
            })
        : document === 20
        ? await axios
            .get(
              "http://localhost:5158/api/University/Faculty/Department/Student/Document",
              {
                headers: {
                  Authorization: `Bearer ${token}`,
                },
                params: { DepName: program },
              }
            )
            .then((res) => {
              setDocuments([
                ...documents,
                {
                  ...res.data,
                  id: documents.length + 10000000,
                  date: new Date().toLocaleDateString(),
                  language: "Turkish",
                  status: "Onaylandı",
                  type: "Öğrenci Belgesi",
                },
              ]);
              //generatePdf();
            })
            .catch((err) => {
              console.log(err);
            })
        : console.log(null);
    }
  };

  return (
    <Box
      sx={{
        marginY: 5,
        width: "100%",
        height: "100%",
        display: "flex",
        justifyContent: "center",
      }}
    >
      <Box
        sx={{
          paddingBottom: 5,
          width: "80%",
          height: "100%",
          backgroundColor: "background.neutral",
          boxShadow: theme.customShadows.z8,
          borderRadius: "10px",
        }}
      >
        <Box
          sx={{
            display: "flex",
            height: "50px",
            alignItems: "center",
            pl: 2,
            borderBottom: `1px solid ${theme.palette.grey[300]}`,
          }}
        >
          <Typography variant="subtitle1" mr={1}>
            200401114
          </Typography>
          <Typography mr={1}>-</Typography>
          <Typography variant="subtitle1" mr={1}>
            Mühendislik Fakültesi
          </Typography>
          <Typography mr={1}>-</Typography>
          <Typography variant="subtitle1" mr={1}>
            Bilgisayar Mühendisliği Bölümü
          </Typography>
          <Typography mr={1}>-</Typography>
          <Typography variant="subtitle1" mr={1}>
            Lisans
          </Typography>
          <Typography mr={1}>-</Typography>
          <Typography variant="subtitle1">
            Normal Öğretim Eğitim Dönemi
          </Typography>
        </Box>
        <Box
          sx={{
            paddingX: 10,
            justifyContent: "space-between",
            display: "flex",
            mt: 3,
          }}
        >
          <Box width="35%">
            <FormControl fullWidth>
              <InputLabel id="label">Belge Talebi</InputLabel>
              <Select
                labelId="label"
                id="demo-simple-select"
                value={document}
                label="Belge Talebi"
                onChange={handleDocumentChange}
                required
              >
                <MenuItem value={10}>Transcript</MenuItem>
                <MenuItem value={20}>Öğrenci Belgesi</MenuItem>
              </Select>
            </FormControl>
          </Box>
          <Box width="35%">
            {" "}
            <FormControl fullWidth>
              <InputLabel id="dil">Dil</InputLabel>
              <Select
                labelId="dil"
                id="demo-simple-select"
                value={language}
                label="Dil"
                onChange={handleLanguageChange}
                required
              >
                <MenuItem value={10}>Turkish</MenuItem>
              </Select>
            </FormControl>
          </Box>
        </Box>
        <Box
          width="100%"
          sx={{
            paddingX: 10,
            paddingY: 3,
            display: "flex",
            justifyContent: "flex-end",
          }}
        >
          <Button
            onClick={handleDocumentRequest}
            variant="contained"
            color="primary"
          >
            Belge Talep Et
          </Button>
        </Box>
        <Box
          sx={{
            border: `1px solid ${theme.palette.primary.main}`,
          }}
        >
          <Box
            sx={{
              height: "50px",
              paddingX: 3,
              display: "flex",
              alignItems: "center",
              backgroundColor: theme.palette.primary.main,
            }}
          >
            <Typography color="white">Talep Edilen Belgeler</Typography>
          </Box>

          <Box
            sx={{
              paddingX: 2,
              height: "40px",
              borderBottom: `1px solid ${theme.palette.grey[300]}`,
              display: "grid",
              alignItems: "center",
              gridTemplateColumns: "1fr 1fr 1fr 1fr 1fr 1fr",
            }}
          >
            <Typography variant="subtitle2">Belge No</Typography>
            <Typography variant="subtitle2">Belge Tipi</Typography>
            <Typography variant="subtitle2">Dil</Typography>
            <Typography variant="subtitle2">Talep Tarih</Typography>
            <Typography variant="subtitle2">Durum</Typography>
            <Typography variant="subtitle2">İşlemler</Typography>
          </Box>
          {documents.map((data) => (
            <TableRow key={data.id} data={data} />
          ))}
        </Box>
      </Box>
    </Box>
  );
};

export default BelgeTablebi;
