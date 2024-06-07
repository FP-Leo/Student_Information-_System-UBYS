import { useEffect, useState } from "react";

import { useDispatch, useSelector } from "react-redux";

import { useTheme } from "@mui/material/styles";
import { Box, Typography, Button } from "@mui/material";

import "react-toastify/dist/ReactToastify.css";
import { ToastContainer, toast } from "react-toastify";

import Select from "@mui/material/Select";
import MenuItem from "@mui/material/MenuItem";
import FormControl from "@mui/material/FormControl";

import { addSubjectToStore } from "store/ders-secimi/ders-secimi.action";
import {
  selectSelectedSubjects,
  selectedSubjectsAkts,
} from "store/ders-secimi/ders-secimi.selector";

const Ders = ({ data, state }) => {
  const { courseCode, courseName, akts, lecturerName, courseType } = data;

  const theme = useTheme();
  const dispatch = useDispatch();

  const [age, setAge] = useState("");
  const [isSelected, setIsSelected] = useState(false);
  const selectedAkts = useSelector(selectedSubjectsAkts);
  const selectedSubjects = useSelector(selectSelectedSubjects);

  useEffect(() => {
    if (selectedSubjects === undefined) return isSelected;
    let found = false;
    selectedSubjects.forEach((item) => {
      if (item.courseCode === courseCode) found = true;
    });
    setIsSelected(found);
    // eslint-disable-next-line
  }, [selectedSubjects]);

  const handleAdd = (e) => {
    e.preventDefault();
    if (selectedAkts + akts > 45) {
      toast.error("35 AKTS'den fazla ders seçemezsiniz!");
      return;
    } else
      dispatch(addSubjectToStore(selectedSubjects, { ...data, type: state }));
  };

  const handleChange = (event) => {
    setAge(event.target.value);
  };

  return (
    <>
      <Box
        sx={{
          width: "100%",
          height: "50px",
          display: "grid",
          gridTemplateColumns: "1fr 2fr 5fr 1fr 4fr 2fr ",
          backgroundColor:
            isSelected && state === "success"
              ? theme.palette.success.light
              : isSelected && state === "failed"
              ? theme.palette.error.light
              : "",
        }}
      >
        <Box
          sx={{
            width: "100%",
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
          }}
        >
          {!isSelected ? (
            <Button
              onClick={handleAdd}
              sx={{
                width: "70%",
                height: "35px",
                color: "white",
              }}
              variant="contained"
              color="success"
            >
              +&nbsp;Seç
            </Button>
          ) : (
            ""
          )}
        </Box>
        <Box
          sx={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
          }}
        >
          <Typography variant="subtitle2" color="info.dark">
            {courseCode}
          </Typography>
        </Box>
        <Box
          sx={{
            marginLeft: "20px",
            display: "flex",
            justifyContent: "flex-start",
            alignItems: "center",
          }}
        >
          <Typography variant="subtitle2">{courseName}</Typography>
        </Box>
        <Box
          sx={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
          }}
        >
          <Typography variant="subtitle2">{akts}</Typography>
        </Box>
        <Box
          sx={{
            marginLeft: "20px",
            display: "flex",
            justifyContent: "flex-start",
            alignItems: "center",
          }}
        >
          <FormControl size="small" sx={{ minWidth: 120 }}>
            <Select
              disabled={isSelected}
              value={age}
              sx={{
                fontSize: "12px",
                fontWeight: "500",
              }}
              onChange={handleChange}
              displayEmpty
              inputProps={{ "aria-label": "Without label" }}
            >
              <MenuItem value="">
                <em>None</em>
              </MenuItem>
              <MenuItem value={lecturerName}>{lecturerName}</MenuItem>
            </Select>
          </FormControl>
        </Box>
        <Box
          sx={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
          }}
        >
          <Typography variant="subtitle2">Alabilir</Typography>
        </Box>
      </Box>
      <ToastContainer />
    </>
  );
};

export default Ders;
