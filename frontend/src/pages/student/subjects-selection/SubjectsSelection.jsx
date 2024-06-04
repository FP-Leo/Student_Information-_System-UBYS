import { useEffect, useState } from "react";

import axios from "axios";

import { Box } from "@mui/material";

import InfoHeader from "./components/InfoHeader";
import SecDersler from "./components/Secdersler";
import SeciliDersler from "./components/SeciliDersler";
import { useSelector } from "react-redux";
import { selectUserToken } from "store/user/user.selector";
import { selectProgram } from "store/program/program.selector";

const SubjectsSelection = () => {
  const token = useSelector(selectUserToken);
  const department = useSelector(selectProgram);

  const [data, setData] = useState([]);
  const [details, setDetails] = useState();

  useEffect(() => {
    try {
      axios
        .get(
          "http://localhost:5158/api/University/Faculty/Department/Semester/Student/Courses/Selected",
          {
            headers: {
              Authorization: `Bearer ${token}`,
            },
            params: { DepName: department },
          }
        )
        .then((response) => {
          setData(response.data);
        });
      axios
        .get(
          "http://localhost:5158/api/University/Faculty/Departments/Student/Details",
          {
            headers: {
              Authorization: `Bearer ${token}`,
            },
          }
        )
        .then((response) => {
          setDetails(response.data);
        });
    } catch (err) {
      console.log(err);
    }
  }, []);

  console.log(details);

  return (
    <Box sx={{ width: "100%" }}>
      <InfoHeader details={details} />
      <Box
        display="flex"
        sx={{ justifyContent: "center", alignItems: "flex-start" }}
      >
        <SeciliDersler />
        <SecDersler data={data} />
      </Box>
    </Box>
  );
};

export default SubjectsSelection;
