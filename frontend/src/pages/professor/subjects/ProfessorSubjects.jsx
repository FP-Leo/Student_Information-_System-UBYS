
import FilterAltOutlinedIcon from "@mui/icons-material/FilterAltOutlined";
import { CancelOutlined } from "@mui/icons-material";
import {
  Box,
  Button,
  FormControl,
  MenuItem,
  Select,
  Typography,
} from "@mui/material";
import { useEffect, useState } from "react";

import FilterAltOutlinedIcon from '@mui/icons-material/FilterAltOutlined';
import { CancelOutlined } from '@mui/icons-material';
import { Box, Button, FormControl, MenuItem, Select, Typography } from '@mui/material';
import { useEffect, useState, useTransition } from 'react';


import OwnedCourses from "../../../Data/ProfessorCourses.json";
import ProfessorSubjectItem from "./ProfessorSubjectItem/ProfessorSubjectItem";
import ProfessorSubjectsTableHeader from "./ProfessorSubjectItem/ProfessorSubjectsTableHeader";

export default function ProfessorSubjects() {

  const [yil, setYil] = useState(2024);
  const [donem, setDonem] = useState("Bahar");
  const yillar = [2024, 2023, 2022, 2021];
  const donemler = ["Bahar", "Güz"];

  const [professorCourses, setProfessorCourses] = useState(
    OwnedCourses.professorCourses.sort(function (a, b) {
      return b.dersYili - a.dersYili;
    })
  );

  const [isFiltered, setIsFiltered] = useState(false);

  const resetProfessorCourse = () => {
    setProfessorCourses(
      OwnedCourses.professorCourses.sort(function (a, b) {
        return b.dersYili - a.dersYili;
      })
    );
  };
  const filterCourses = () => {
    setProfessorCourses(
      professorCourses.filter(
        (course) => course.dersYili === yil && course.dersDonemi === donem
      )
    );
  };
  useEffect(() => {
    setIsFiltered(false);
    resetProfessorCourse();
  }, [yil, donem]);

  const [tabloBaslik, setTabloBaslik] = useState(yil + "-" + donem);

  const handleSetYear = (event) => {
    setYil(event.target.value);
  };
  const handleSetDonem = (event) => {
    setDonem(event.target.value);
  };

  const onClickFilter = () => {
    setTabloBaslik(yil + "-" + donem);
    if (isFiltered) {
      resetProfessorCourse();
    } else {
      filterCourses();


    const [yil,setYil] = useState(2024);
    const [donem,setDonem] = useState("Bahar")
    const yillar = [2024,2023,2022,2021]
    const donemler = ["Bahar","Güz"]

    const [professorCourses, setProfessorCourses] = useState(OwnedCourses.professorCourses.sort(function(a,b){return b.dersYili - a.dersYili}))
    
    const [isFiltered,setIsFiltered] = useState(false)

    const resetProfessorCourse = ( )=>{
      setProfessorCourses(OwnedCourses.professorCourses.sort(function(a,b){return b.dersYili - a.dersYili}))
    }
    const filterCourses = () =>{
      setProfessorCourses(professorCourses.filter((course)=>course.dersYili === yil && course.dersDonemi === donem))
    }
    useEffect(()=>{
      setIsFiltered(false)
      resetProfessorCourse()
    },[yil,donem])
  
 
    
    const [tabloBaslik,setTabloBaslik] = useState(yil + "-" + donem)

    const handleSetYear = (event) =>{
        setYil(event.target.value)
    }
    const handleSetDonem = (event)=>{
        setDonem(event.target.value)

    }
    setIsFiltered(!isFiltered);
  };


  const sortByHeader = (event) => {
    console.log(event.target.innerText); // Backendden veri gelince burayı dinamik yapacağım
    // Bu sayede tıklayıp direkt sort edebilecekler
  };

    const onClickFilter =()=>{
        setTabloBaslik(yil + "-" + donem)
        if(isFiltered){
          resetProfessorCourse()
        }else{
          filterCourses()
        }
        setIsFiltered(!isFiltered)
    }
    

    const sortByHeader = (event) =>{  
      console.log(event.target.innerText); // Backendden veri gelince burayı dinamik yapacağım
      // Bu sayede tıklayıp direkt sort edebilecekler
    }

    
    

  return (
    <Box sx={{ width: "100%", display: "flex", flexDirection: "column" }}>
      <Box
        sx={{
          display: "flex",
          alignItems: "flex-start",
          justifyContent: "space-evenly",
        }}
        my={5}
      >
        <FormControl size="small" sx={{ minWidth: 400 }} id="yilSelect">
          <Select
            value={yil}
            sx={{ fontSize: "12px", fontWeight: "500" }}
            onChange={handleSetYear}
            displayEmpty
            inputProps={{ "aria-label": "Without label" }}
          >
            {yillar.map((yil) => (
              <MenuItem value={yil}>{yil}</MenuItem>
            ))}
          </Select>
        </FormControl>
        <FormControl size="small" sx={{ minWidth: 400 }} id="donemSelect">
          <Select
            value={donem}
            sx={{ fontSize: "12px", fontWeight: "500" }}
            onChange={handleSetDonem}
            inputProps={{ "aria-label": "Without label" }}
          >
            {donemler.map((donem) => (
              <MenuItem value={donem}>{donem}</MenuItem>
            ))}
          </Select>
        </FormControl>
        <Button
          onClick={onClickFilter}
          sx={{
            minWidth: 400,
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
              marginY: "20px",
              marginX: "35px",
            }}
          >
            <Typography variant="subtitle1">{tabloBaslik}</Typography>
          </Box>
          <Box
            sx={{
              width: "100%",
              display: "grid",
              gridTemplateColumns: "1.25fr 1.75fr 1.5fr 2.5fr 1.5fr 2.5fr 2fr",
              borderLeft: "1px solid #B3B3B3",
              borderRight: "1px solid #B3B3B3",
            }}
          >
            <ProfessorSubjectsTableHeader sortByHeader={sortByHeader} />
          </Box>
          {professorCourses.map((course) => {
            return (
              <ProfessorSubjectItem
                dersAdi={course.dersAdi}
                dersBirimi={course.dersBirimi}
                dersKodu={course.dersKodu}
                dersFakulte={course.dersFakulte}
                yil={course.dersYili}
                donem={course.dersDonemi}
                key={course.id}
              />
            );
          })}
        </Box>

        {professorCourses.map((course)=>{
          return(
            <ProfessorSubjectItem 
            course={course}
            dersAdi={course.dersAdi}
            dersBirimi={course.dersBirimi}
            dersKodu={course.dersKodu}
            dersFakulte={course.dersFakulte}
            yil={course.dersYili} 
            donem={course.dersDonemi} 
            key={course.id}/>
          )
        })}

      </Box>
    </Box>
  );
}
