import { Box, Typography, Button } from "@mui/material";
import { useState } from "react";
import { useTheme } from "@mui/material/styles";

import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

import MenuItem from "@mui/material/MenuItem";
import FormControl from "@mui/material/FormControl";
import Select from "@mui/material/Select";
import { useDispatch, useSelector } from "react-redux";
import { addSubjectToStore } from "store/ders-secimi/ders-secimi.action";
import { selectSelectedSubjects } from "store/ders-secimi/ders-secimi.selector";

import { selectedSubjectsAkts } from "store/ders-secimi/ders-secimi.selector";

const Ders = ({ data }) => {
  const { subjectName, subjectCode, akts, subeler, aciklama, limit } = data;
  const [age, setAge] = useState("");
  const selectedSubjects = useSelector(selectSelectedSubjects);
  const selectedAkts = useSelector(selectedSubjectsAkts);

  const dispatch = useDispatch();

  const handleAdd = (e) => {
    e.preventDefault();

    if (selectedAkts + akts > 35) {
      toast.error("35 AKTS'den fazla ders seçemezsiniz!");
      return;
    } else dispatch(addSubjectToStore(selectedSubjects, data));
  };

  const handleChange = (event) => {
    setAge(event.target.value);
  };
  const theme = useTheme();
  return (
    <>
      <Box
        sx={{
          width: "100%",
          height: "50px",
          display: "grid",
          gridTemplateColumns: "1fr 2fr 5fr 1fr 4fr 2fr ",
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
        </Box>
        <Box
          sx={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
          }}
        >
          <Typography variant="subtitle2" color="info.dark">
            {subjectCode}
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
          <Typography variant="subtitle2">{subjectName}</Typography>
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
              value={age}
              sx={{ fontSize: "12px", fontWeight: "500" }}
              onChange={handleChange}
              displayEmpty
              inputProps={{ "aria-label": "Without label" }}
            >
              <MenuItem value="">
                <em>None</em>
              </MenuItem>
              {subeler.map((sube) => (
                <MenuItem value={sube}>{sube}</MenuItem>
              ))}
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
          <Typography variant="subtitle2">{aciklama}</Typography>
        </Box>
      </Box>
      <ToastContainer />
    </>
  );
};

export default Ders;
