import {
  Box,
  Button,
  FormControl,
  MenuItem,
  Select,
  TextField,
  Typography,
} from "@mui/material";
import React, { useState } from "react";
import FilterAltOutlinedIcon from "@mui/icons-material/FilterAltOutlined";
import TableHeader from "components/TableHeader";
import MyStudentsItem from "./MyStudentsItem/MyStudentsItem";

export default function ProfessorsStudents() {
  const [selectedBolum, setSelectedBolum] = useState();
  const bolumler = [
    "Makine Mühendisliği",
    "Bilgisayar Mühendisliği",
    "Bilgisayar Programcılığı",
  ];
  const handleSetSelectedBolum = (event) => {
    setSelectedBolum(event.target.value);
  };

  return (
    <Box
      sx={{
        display: "flex",
        flexDirection: "column",
        width: "100%",
      }}
    >
      <Box
        sx={{
          display: "flex",
          alignItems: "flex-start",
          justifyContent: "space-evenly",
        }}
        my={5}
      >
        <FormControl size="small" sx={{ minWidth: 1200 }} id="yilSelect">
          <Select
            value={selectedBolum}
            sx={{ fontSize: "12px", fontWeight: "500" }}
            onChange={handleSetSelectedBolum}
            displayEmpty
            inputProps={{ "aria-label": "Without label" }}
          >
            {bolumler.map((bolum) => (
              <MenuItem value={bolum}>{bolum}</MenuItem>
            ))}
          </Select>
        </FormControl>
        <Button
          sx={{
            minWidth: 400,
            bgcolor: "#1769aa",
            color: "white",
            ":hover": { backgroundColor: "#1769aa" },
          }}
          startIcon={<FilterAltOutlinedIcon />}
        >
          Filtrele
        </Button>
      </Box>

      <Box
        sx={{
          display: "flex",
          alignItems: "center",
          justifyContent: "space-between",
        }}
      >
        <Box sx={{ display: "flex", alignItems: "center", marginLeft: 5 }}>
          <Typography>Sayfada</Typography>
          <select
            style={{
              minWidth: 100,
              minHeight: 35,
              marginLeft: 10,
              marginRight: 10,
            }}
          >
            <option value="10">10</option>
            <option value="20">20</option>
            <option value="20">50</option>
          </select>
          <Typography>kayıt göster</Typography>
        </Box>
        <Box sx={{ display: "flex", alignItems: "center", marginRight: 5 }}>
          <Typography mx={2}>Bul:</Typography>
          <TextField label="İsim giriniz" variant="outlined" />
        </Box>
      </Box>

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
        px={10}
        sx={{
          width: "100%",
          minWidth: "auto",
          marginTop: "50px",
          borderRadius: "10px",
          paddingBottom: "30px",
          marginBottom: "50px"
        }}
      >
        <Box
          sx={{
            width: "100%",
            display: "grid",
            gridTemplateColumns: "1fr 1.5fr 2fr 4fr 2fr 1fr 1fr 1fr 1fr 1fr 1fr",
            borderLeft: "1px solid #B3B3B3",
            borderRight: "1px solid #B3B3B3",
          }}
        >
          <TableHeader left={false} right={true} title="Resim" />
          <TableHeader left={false} right={false} title="Numarası" />
          <TableHeader left={true} right={true} title="Adı - Soyadı" />
          <TableHeader left={false} right={true} title="Akademik Program" />
          <TableHeader left={false} right={false} title="Kayıtlanma Aşaması" />
          <TableHeader left={true} right={false} title="Sınıfı" />
          <TableHeader left={true} right={true} title="Harç Borcu" />
          <TableHeader left={false} right={true} title="Durum" />
          <TableHeader left={false} right={false} title="Detay Durum" />
          <TableHeader left={true} right={true} title="GANO" />
          <TableHeader left={false} right={true} title="İşlemler" />

          
        </Box>
        <MyStudentsItem/>
        <MyStudentsItem/>
        <MyStudentsItem/>
        <MyStudentsItem/>
      </Box>
    </Box>
    </Box>
  );
}
