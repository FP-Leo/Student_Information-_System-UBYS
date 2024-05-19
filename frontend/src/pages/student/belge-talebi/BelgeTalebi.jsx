import {
  Box,
  Button,
  Container,
  Grid,
  IconButton,
  Typography,
} from "@mui/material";
import { useState } from "react";
import { useTheme } from "@mui/material/styles";
import InputLabel from "@mui/material/InputLabel";
import MenuItem from "@mui/material/MenuItem";
import FormControl from "@mui/material/FormControl";
import Select from "@mui/material/Select";
import TableRow from "./components/TableRow";
import { DOCUMENTS } from "./documents";

const BelgeTablebi = () => {
  const theme = useTheme();
  const [document, setDocument] = useState("");
  const [language, setLanguage] = useState("");

  const handleDocumentChange = (event) => {
    setDocument(event.target.value);
  };
  const handleLanguageChange = (event) => {
    setLanguage(event.target.value);
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
              >
                <MenuItem value={10}>Transcript</MenuItem>
                <MenuItem value={20}>Student Confirmation</MenuItem>
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
              >
                <MenuItem value={10}>Turkish</MenuItem>
                <MenuItem value={20}>English</MenuItem>
                <MenuItem value={30}>Albanian</MenuItem>
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
          <Button variant="contained" color="primary">
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
          {DOCUMENTS.map((data) => (
            <TableRow key={data.id} data={data} />
          ))}
        </Box>
      </Box>
    </Box>
  );
};

export default BelgeTablebi;
