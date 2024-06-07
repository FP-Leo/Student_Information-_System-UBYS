import { useTheme } from "@emotion/react";
import { Box, Button } from "@mui/material";
import SearchInput from "components/SearchInput";
import { useSelector } from "react-redux";
import { selectUserToken } from "store/user/user.selector";
import { useEffect, useState } from "react";
import SınıfListeItem from "./Components/SınıfListeItem";
import { set } from "lodash";
import axios from "axios";

export default function SinifListeGoruntule({ type, courseSize, courseCode }) {
  const [professorStudents, setProfessorStudents] = useState(courseSize);
  const theme = useTheme();
  const token = useSelector(selectUserToken);
  console.log(professorStudents);
  const [records, setRecords] = useState(courseSize);
  const [butunlemeStudents, setButunlemeStudents] = useState(courseSize);
  const [vizeAvailable, setVizeAvailable] = useState(true);
  const [finalAvailable, setFinalAvailable] = useState(true);
  const [butAvailable, setButAvailable] = useState(true);

  const [deneme, setDeneme] = useState([]);

  const [vize, setVize] = useState(0);
  const [final, setFinal] = useState(0);
  const [but, setBut] = useState(0);

  const [studentSsn, setStudentSsn] = useState(0);

  useEffect(() => {
    axios
      .get(
        "http://localhost:5158/api/University/Faculty/Departments/Course/Students/Details",
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
          params: {
            CourseCode: "BLM-2001",
          },
        }
      )
      .then((res) => {
        console.log(res.data);
        setDeneme([...res.data.students]);
      })
      .catch((err) => console.log(err));
  }, []);

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
            <Button
              onClick={() => {
                setVizeAvailable(!vizeAvailable);
              }}
            >
              Vize İlan Et
            </Button>
            <Button
              onClick={() => {
                setFinalAvailable(!finalAvailable);
              }}
            >
              Final İlan Et
            </Button>
            <Button
              onClick={() => {
                setVizeAvailable(!butAvailable);
              }}
            >
              Büt İlan Et
            </Button>
          </Box>
        )}
      </Box>

      <Box
        sx={{
          overflow: "auto",
        }}
      >
        {deneme.length !== 0 ? (
          deneme.map((item) => {
            return (
              <SınıfListeItem
                students={
                  type === "Bütünleme Listesi"
                    ? butunlemeStudents
                    : professorStudents
                }
                setStudents={
                  type === "Bütünleme Listesi" && setButunlemeStudents
                }
                type={type}
                key={item}
                item={item}
                vizeAvailable={vizeAvailable}
                finalAvailable={finalAvailable}
                butAvailable={butAvailable}
                setVize={setVize}
                setFinal={setFinal}
                setBut={setBut}
                setStudentSsn={setStudentSsn}
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
