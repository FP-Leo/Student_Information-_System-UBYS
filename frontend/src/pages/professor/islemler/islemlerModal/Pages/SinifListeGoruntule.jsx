import { useTheme } from "@emotion/react";
import { Box, Button } from "@mui/material";
import SearchInput from "components/SearchInput";
import { useState } from "react";
import SınıfListeItem from "./Components/SınıfListeItem";
import { set } from "lodash";
import axios from "axios";

export default function SinifListeGoruntule({ type, courseSize,courseCode }) {
  const [professorStudents, setProfessorStudents] = useState(courseSize);
  const theme = useTheme();
  console.log(professorStudents);
  const [records, setRecords] = useState(courseSize);
  const [butunlemeStudents, setButunlemeStudents] = useState(courseSize);
  const [vizeAvailable, setVizeAvailable] = useState(true);
  const [finalAvailable, setFinalAvailable] = useState(true);
  const [butAvailable, setButAvailable] = useState(true);

  const [vize,setVize] = useState(0)
  const [final,setFinal] = useState(0)
  const [but,setBut] = useState(0)

  const [studentSsn,setStudentSsn] = useState(0)

  const handleVizeIlan= async ()  =>{
    const response = await axios.get(
      'http://localhost:5158/api/University/Faculty/Department/Course/Student/MidTerm',{CourseCode:dersKodu,tc:studentSsn,points:vize}
      ,
      {
        headers:{
          Authorization:"Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiMTAwMDAwMDAwMDMiLCJyb2xlIjoiTGVjdHVyZXIiLCJuYmYiOjE3MTc1MTkyNzAsImV4cCI6MTcxODEyNDA3MCwiaWF0IjoxNzE3NTE5MjcwLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUyNDYiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUyNDYifQ.eu4xmuFF1i0qXNN9O19aUcDAsn4PLBgsx7SEbpSRTc0Q2pR1jrkJ24Qw829eFcrVq9_q7dNit03P8ZrwzQi2Gg"
        },
      }
    ).then(response=>setCourseSize(response.data.students))

  }

  const handleFinalIlan= async ()  =>{
    const response = await axios.get(URL,
      {
        headers:{
          Authorization:"Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiMTAwMDAwMDAwMDMiLCJyb2xlIjoiTGVjdHVyZXIiLCJuYmYiOjE3MTc1MTkyNzAsImV4cCI6MTcxODEyNDA3MCwiaWF0IjoxNzE3NTE5MjcwLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUyNDYiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUyNDYifQ.eu4xmuFF1i0qXNN9O19aUcDAsn4PLBgsx7SEbpSRTc0Q2pR1jrkJ24Qw829eFcrVq9_q7dNit03P8ZrwzQi2Gg"
        },
        params:{CourseCode:dersKodu,tc:studentSsn,points:final}
      }
    ).then(response=>setCourseSize(response.data.students))

  }

  const handleButIlan= async ()  =>{
    const response = await axios.get(URL,
      {
        headers:{
          Authorization:"Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiMTAwMDAwMDAwMDMiLCJyb2xlIjoiTGVjdHVyZXIiLCJuYmYiOjE3MTc1MTkyNzAsImV4cCI6MTcxODEyNDA3MCwiaWF0IjoxNzE3NTE5MjcwLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUyNDYiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUyNDYifQ.eu4xmuFF1i0qXNN9O19aUcDAsn4PLBgsx7SEbpSRTc0Q2pR1jrkJ24Qw829eFcrVq9_q7dNit03P8ZrwzQi2Gg"
        },
        params:{CourseCode:dersKodu,tc:studentSsn,points:but}
      }
    ).then(response=>setCourseSize(response.data.students))

  }

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
            onClick={()=>{
              if(vizeAvailable){
                handleVizeIlan()
              }
              setVizeAvailable(!vizeAvailable)
            }}
            >Vize İlan Et</Button>
            <Button
            onClick={()=>{
              if(finalAvailable){
                handleFinalIlan()
              }
              setFinalAvailable(!finalAvailable)
            }}            
            >Final İlan Et</Button>
            <Button
            onClick={()=>{
              if(butAvailable){
                handleButIlan()
              }
              setVizeAvailable(!butAvailable)
            }}            
            >Büt İlan Et</Button>
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
