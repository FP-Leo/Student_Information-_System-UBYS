import { CancelOutlined } from "@mui/icons-material";
import FilterAltOutlinedIcon from "@mui/icons-material/FilterAltOutlined";
import {
  Box,
  Button,
  FormControl,
  MenuItem,
  Select,
  Typography
} from "@mui/material";
import SearchInput from "components/SearchInput";
import { useState } from "react";
import OwnedStudents from "../../../Data/ProfessorStudents.json";
import MyStudentsItem from "./MyStudentsItem/MyStudentsItem";
import MyStudentsTableHeader from "./MyStudentsItem/MyStudentsTableHeader";

export default function ProfessorsStudents() {
  const [selectedBolum, setSelectedBolum] = useState("");
  const bolumler = [
    "Makine Mühendisliği",
    "Bilgisayar Mühendisliği",
    "Bilgisayar Programcılığı",
  ];
  const handleSetSelectedBolum = (event) => {
    setSelectedBolum(event.target.value);
  };

  const [isFiltered, setIsFiltered] = useState(false);

  const [professorStudents, setProfessorStudents] = useState(
    OwnedStudents.professorStudents.sort(function (a, b) {
      return b.ogrenciAd - a.ogrenciAd;
    })
  );

  const resetProfessorStudents = () => {
    setSelectedBolum("");
    setProfessorStudents(
      OwnedStudents.professorStudents.sort(function (a, b) {
        return b.ogrenciAd - a.ogrenciAd;
      })
    );
    setIsFiltered(false);
  };
  const filterStudents = () => {
    if (selectedBolum !== "") {
      setProfessorStudents([
        ...professorStudents.filter(
          (student) => student.ogrenciProgram === selectedBolum
        ),
      ]);
      setIsFiltered(true);
    }
  };

  const onClickFilter = () => {
    if (isFiltered) {
      resetProfessorStudents();
    } else {
      filterStudents();
    }
    setIsFiltered(!isFiltered);
  };

  const [records, setRecords] = useState(professorStudents);


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
          alignItems: "center",
        }}
        my={5}
        maxWidth={"1250px"}
      >
        <Box display={"flex"} alignItems={"center"}>
          <Typography mx={2}>Bölüm:</Typography>
          <FormControl size="small" sx={{ minWidth: 1200 }}>
            <Select
              value={selectedBolum}
              sx={{ fontSize: "12px", fontWeight: "500" }}
              onChange={handleSetSelectedBolum}
              displayEmpty
              inputProps={{ "aria-label": "Without label" }}
            >
              <MenuItem disabled value="">
                Bölüm Seçiniz
              </MenuItem>
              {bolumler.map((bolum) => (
                <MenuItem value={bolum}>{bolum}</MenuItem>
              ))}
            </Select>
          </FormControl>
        </Box>
        <Button
          onClick={onClickFilter}
          disabled={selectedBolum === "" ? true : false}
          sx={{
            minWidth: 200,
            marginLeft: "15px",
            bgcolor: !isFiltered ? "#1769aa" : "#bb2124",
            color: "white",
            ":hover": { backgroundColor: !isFiltered ? "#1769aa" : "#bb2124" },
          }}
          startIcon={
            isFiltered ? <CancelOutlined /> : <FilterAltOutlinedIcon />
          }
        >
          {isFiltered ? "Filtreyi Kaldır" : "Filtrele"}
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
         <SearchInput setSearchInputArray={setRecords} initialArray={professorStudents} />
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
            marginBottom: "50px",
          }}
        >
          <Box
            sx={{
              width: "100%",
              display: "grid",
              gridTemplateColumns: "1fr 1fr 1fr 3fr 1fr 1fr 1fr 1fr 1fr 1fr",
              borderBottom: "1px solid #B3B3B3",
              borderLeft: "1px solid #B3B3B3",
              borderRight: "1px solid #B3B3B3",
              textAlign: "center",
            }}
          >
            <MyStudentsTableHeader />
          </Box>
          {records.map((student) => {
            return <MyStudentsItem key={student.id} student={student} />;
          })}
        </Box>
      </Box>
    </Box>
  );
}
