import axios from "axios";

import { useEffect, useState } from "react";

import { Box, Button } from "@mui/material";

import { useSelector } from "react-redux";
import { selectProgram } from "store/program/program.selector";

import { getToken } from "utils/helper-functions";
import SubjectsTable from "./SubjectsTable";

const Subjects = () => {
  const program = useSelector(selectProgram);
  const [open, setOpen] = useState(false);
  const [subjects, setSubjects] = useState([]);

  useEffect(() => {
    const token = getToken();
    axios
      .get(
        "http://localhost:5158/api/University/Faculty/Departments/Student/Courses/Details",
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
          params: { DepName: program },
        }
      )
      .then((response) => {
        setSubjects(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, [program]);

  const result = Object.groupBy(subjects, ({ schoolYear }) => schoolYear);

  return (
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
      {Object.keys(result).map((year, index) => {
        const subjectsForYear = result[year];
        if (index === 0 || open) {
          return <SubjectsTable subjects={subjectsForYear} />;
        }
      })}
      <Box sx={{ margin: "50px" }}>
        <Button
          onClick={() => setOpen(!open)}
          type="submit"
          size="large"
          variant="contained"
          style={{
            height: "50px",
            borderRadius: "12px",
            marginTop: "60px",
          }}
          fullWidth={true}
        >
          {" "}
          {open
            ? "Geçmiş Dönem Derslerini Gizle"
            : "Geçmiş Dönem Derslerini Göster"}
        </Button>
      </Box>
    </Box>
  );
};

export default Subjects;
