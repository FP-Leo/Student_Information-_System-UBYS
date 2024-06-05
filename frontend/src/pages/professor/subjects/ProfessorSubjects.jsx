import { CancelOutlined } from "@mui/icons-material";
import FilterAltOutlinedIcon from "@mui/icons-material/FilterAltOutlined";
import {
  Box,
  Button,
  CircularProgress,
  FormControl,
  MenuItem,
  Select,
  Typography,
} from "@mui/material";
import { useEffect, useState } from "react";

import axios from "axios";
import { useSelector } from "react-redux";
import { selectProgram } from "store/program/program.selector";
import { selectUserToken } from "store/user/user.selector";
import ProfessorSubjectsTableHeader from "./ProfessorSubjectItem/ProfessorSubjectsTableHeader";
import ProfessorSubjectItem from "./ProfessorSubjectItem/ProfessorSubjectItem";

export default function ProfessorSubjects() {
  const [yil, setYil] = useState(2024);
  const yillar = [2024, 2023, 2022, 2021];
  const token = useSelector(selectUserToken);
  const program = useSelector(selectProgram);

  const PORT = 53675;
  const [professorCourses, setProfessorCourses] = useState([])
  const [coursesDepartment, setCoursesDepartment] = useState("");
  const [coursesFaculty, setCoursesFaculty] = useState("");
  const [loading, setLoading] = useState(false);

  const handleGetProfessorCourses = async () => {
    setLoading(true);
    try {
      const response = await axios.get(
        `https://localhost:${PORT}/api/University/Faculty/Department/Lecturer/Courses`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
          params: { DepartmentName: program },
        }
      ).then(response=>(
        setProfessorCourses(response.data.courses),
        response.data.courseFaculty === "M" && setCoursesFaculty("Mühendislik Fakültesi"),
        response.data.courseDepartment === "BM" && setCoursesDepartment("Bilgisayar Mühendisliği")
      ))
      
    } catch (exception) {
      console.log(exception);
    } finally {
      setLoading(false); // Always set loading to false even on errors
    }
  };
  
  useEffect(() => {
    handleGetProfessorCourses();
  }, []);

  const [isFiltered, setIsFiltered] = useState(false);





  const [tabloBaslik, setTabloBaslik] = useState(yil);

  const onClickFilter = () => {
    setTabloBaslik(yil);
    if(!isFiltered){
      let course = professorCourses.filter((item) => item.schoolYear === yil)
      setProfessorCourses([...course])
    }else{
      handleGetProfessorCourses()
    }
    setIsFiltered(!isFiltered);
  
  };

  const sortByHeader = (event) => {
    console.log(event.target.innerText); // Backendden veri gelince burayı dinamik yapacağım
    // Bu sayede tıklayıp direkt sort edebilecekler
  };

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
            key={yil}
            value={yil}
            sx={{ fontSize: "12px", fontWeight: "500" }}
            onChange={(event)=>{setYil(event.target.value)}}
            displayEmpty
            inputProps={{ "aria-label": "Without label" }}
          >
            {yillar.map((yil) => (
              <MenuItem value={yil}>{yil}</MenuItem>
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
      {loading ? (
        <Box
          sx={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            height: "200px",
          }}
        >
          <CircularProgress />
        </Box>
      ) : (
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
                gridTemplateColumns: "1.25fr 1.75fr 1.5fr 2.5fr 1.5fr 2.5fr",
                borderLeft: "1px solid #B3B3B3",
                borderRight: "1px solid #B3B3B3",
              }}
            >
              <ProfessorSubjectsTableHeader sortByHeader={sortByHeader} />
            </Box>
            {professorCourses.map((course) => {
              return <ProfessorSubjectItem 
              course={course}
              key={course.id}
              yil={course.schoolYear} 
              dersKodu={course.courseCode} 
              dersFakulte={coursesFaculty}
              dersBirimi ={coursesDepartment}
              dersAdi={course.courseName}/>
            })}
          </Box>
        </Box>
      )}
    </Box>
  );
}
