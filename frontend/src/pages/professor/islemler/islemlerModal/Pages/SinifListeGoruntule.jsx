import { useTheme } from "@emotion/react";
import { Box, Button } from "@mui/material";
import SearchInput from "components/SearchInput";
import { useState } from "react";
import SınıfListeItem from "./Components/SınıfListeItem";

export default function SinifListeGoruntule({ type, courseSize }) {
  const [professorStudents, setProfessorStudents] = useState(courseSize);
  const theme = useTheme();
  console.log(professorStudents);
  const [records, setRecords] = useState(courseSize);
  const [butunlemeStudents, setButunlemeStudents] = useState(courseSize);

  return (
    <Box sx={{ display: "flex", flexDirection: "column", height: "50vh" }}>
      <Box
        sx={{
          display: "flex",
          alignItems: "center",
          justifyContent: "space-between",
        }}
      >
        {type === "Bütünleme Listesi" && (
          <Box display={"flex"}>
            <Button
              sx={{
                bgcolor: theme.palette.success.main,
                marginRight: "10px",
                ":hover": { backgroundColor: theme.palette.success.main },
              }}
            >
              Hepsini Onayla{" "}
            </Button>
            <Button
              sx={{
                bgcolor: theme.palette.error.main,
                ":hover": { backgroundColor: theme.palette.error.main },
              }}
            >
              Hepsini Reddet
            </Button>
          </Box>
        )}

        <Box
          sx={{
            display: "flex",
            alignItems: "center",
            marginRight: "10px",
            marginBottom: "10px ",
          }}
        >
          <SearchInput
            setSearchInputArray={setRecords}
            initialArray={professorStudents}
          />
        </Box>
        {type === "Not Giriş" && (
          <Box display={"flex"}>
            <Button>Vize İlan Et</Button>
            <Button>Final İlan Et</Button>
            <Button>Büt İlan Et</Button>
          </Box>
        )}
      </Box>

      <Box
        sx={{
          overflow: "auto",
        }}
      >
        {records.length !== 0 ? (
          records.map((item) => {
            return (
              <SınıfListeItem
                students={type === "Bütünleme Listesi" ? butunlemeStudents : professorStudents}
                setStudents={type === "Bütünleme Listesi" && setButunlemeStudents}
                type={type}
                key={item}
                item={item}
              />
            );
          })
        ) : (
          <SınıfListeItem type={"NotFound"} key={null} item={null} />
        )}
      </Box>
    </Box>
  );
}
