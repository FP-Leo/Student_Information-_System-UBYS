import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import SubjectsTableRow from "../components/SubjectsTableRow";
import {
  getFaculties,
  //getDepartments,
  getSubjects,
  filteredSubjects,
  getDepartmentsByFaculty,
} from "pages/administrator/sample-data";

import { useTheme } from "@mui/material/styles";
import {
  Box,
  Button,
  TableContainer,
  Typography,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  IconButton,
} from "@mui/material";
import Dialog from "@mui/material/Dialog";
import Select from "@mui/material/Select";
import MenuItem from "@mui/material/MenuItem";
import InputLabel from "@mui/material/InputLabel";
import FormControl from "@mui/material/FormControl";
import DialogTitle from "@mui/material/DialogTitle";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import SaveAsRoundedIcon from "@mui/icons-material/SaveAsRounded";
import DeleteRoundedIcon from "@mui/icons-material/DeleteRounded";

import { useSelector, useDispatch } from "react-redux";
import {
  //setFetchedSubjects,
  //setSelectedSubjects,
  removeSubjectFromStore,
} from "store/ders-secimi/ders-secimi.action";
import {
  //selectFetchedSubjects,
  selectSelectedSubjects,
} from "store/ders-secimi/ders-secimi.selector";

const LecturerSubjectRegistration = () => {
  const theme = useTheme();
  const params = useParams();
  const SUBJECTS = getSubjects();
  const dispatch = useDispatch();
  const FACULTIES = getFaculties();
  //const DEPARTMENTS = getDepartments();
  //const fetchedSubjects = useSelector(selectFetchedSubjects);
  const selectedSubjects = useSelector(selectSelectedSubjects);

  const [open, setOpen] = useState(false);
  const [faculty, setFaulty] = useState("");
  const [subjects, setSubjects] = useState([]);
  const [changed, setChanged] = useState(false);
  //const [faculties, setFaculties] = useState([]);
  const [department, setDepartment] = useState("");
  const [departments, setDepartments] = useState([]);

  useEffect(() => {
    setSubjects(SUBJECTS);
  }, [SUBJECTS]);

  const handleChange = (event) => {
    const { name, value } = event.target;
    switch (name) {
      case "faculty":
        setFaulty(value);
        setChanged(true);
        setDepartments(getDepartmentsByFaculty(value));
        break;
      case "department":
        setDepartment(value);
        setChanged(true);
        break;
      default:
        break;
    }
  };

  const handleFilter = () => {
    setSubjects(filteredSubjects(faculty, department));
    setChanged(false);
  };

  const handleRemove = (subject) => (event) => {
    event.preventDefault();
    dispatch(removeSubjectFromStore(selectedSubjects, subject));
  };

  const handleClear = () => {
    setFaulty("");
    setDepartment("");
    setSubjects(SUBJECTS);
  };

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  return (
    <Box
      sx={{
        width: "100%",
        display: "grid",
        gridTemplateColumns: "1.2fr 1fr",
      }}
    >
      <Dialog
        open={open}
        onClose={handleClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">
          {"Ders Atamasını Onayla"}
        </DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            Ders atamasını onaylamak istediğinize emin misiniz?
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button
            sx={{
              color: theme.palette.common.white,
            }}
            variant="contained"
            color="success"
            onClick={handleClose}
            autoFocus
          >
            Agree
          </Button>
          <Button variant="contained" color="error" onClick={handleClose}>
            Disagree
          </Button>
        </DialogActions>
      </Dialog>
      <Box
        sx={{
          display: "flex",
          gridColumn: "1/3",
          alignItems: "center",
          paddingY: 1,
          paddingX: 5,
          width: "100%",
          justifyContent: "space-between",
        }}
      >
        <Typography variant="subtitle1">
          {`Öğretim Eleman No: ${params.id}`}{" "}
        </Typography>
        <Button
          startIcon={<SaveAsRoundedIcon />}
          onClick={handleClickOpen}
          sx={{
            color: theme.palette.common.white,
          }}
          color="success"
          variant="contained"
        >
          Ders Atamasını Onayla
        </Button>
      </Box>
      <Box
        sx={{
          gridColumn: "1/2",
          marginLeft: 2,
          marginRight: 1,
          borderRadius: 1,
          padding: 3,
        }}
      >
        <Box
          sx={{
            display: "flex",
            gap: 2,
          }}
        >
          <FormControl size="small" fullWidth>
            <InputLabel id="demo-simple-select-label">Fakülte</InputLabel>
            <Select
              labelId="demo-simple-select-label"
              id="demo-simple-select"
              value={faculty}
              name="faculty"
              label="Fakülte"
              onChange={handleChange}
            >
              {FACULTIES.map((faculty, index) => (
                <MenuItem key={index} value={faculty}>
                  {faculty}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
          <FormControl size="small" fullWidth>
            <InputLabel id="demo-simple-select-label">Bölüm</InputLabel>
            <Select
              labelId="demo-simple-select-label"
              id="demo-simple-select"
              value={department}
              name="department"
              label="Bölüm"
              onChange={handleChange}
            >
              {departments.map((department, index) => (
                <MenuItem key={index} value={department}>
                  {department}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
          <Box sx={{ display: "flex", gap: 2 }}>
            <Button
              onClick={handleFilter}
              variant="contained"
              disabled={!changed}
            >
              Filer
            </Button>
            <Button onClick={handleClear} color="error" variant="contained">
              Clear
            </Button>
          </Box>
        </Box>
        <Box
          sx={{
            marginTop: 3,
          }}
        >
          <TableContainer
            sx={{
              borderRadius: "5px",
              boxShadow: theme.customShadows.z4,
              backgroundColor: theme.palette.common.white,
            }}
          >
            <Table>
              <TableHead
                sx={{
                  backgroundColor: theme.palette.grey[300],
                }}
              >
                <TableRow>
                  <TableCell> Kodu</TableCell>
                  <TableCell
                    sx={{
                      width: "20%",
                    }}
                  >
                    Ders Adı
                  </TableCell>
                  <TableCell
                    sx={{
                      width: "30%",
                    }}
                  >
                    Fakülte/Bölüm
                  </TableCell>
                  <TableCell>Dönem</TableCell>
                  <TableCell>Kredi</TableCell>
                  <TableCell>AKTS</TableCell>
                  <TableCell></TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {subjects.map((subject, index) => (
                  <SubjectsTableRow
                    key={index}
                    toControl={subjects}
                    subject={subject}
                  />
                ))}
              </TableBody>
            </Table>
          </TableContainer>
        </Box>
      </Box>
      <Box
        sx={{
          gridColumn: "2/3",
          marginLeft: 1,
          marginRight: 2,
        }}
      >
        <TableContainer
          sx={{
            borderRadius: "5px",
            boxShadow: theme.customShadows.z4,
            backgroundColor: theme.palette.common.white,
          }}
        >
          <Table>
            <TableHead
              sx={{
                backgroundColor: theme.palette.grey[300],
              }}
            >
              <TableRow>
                <TableCell
                  sx={{
                    width: "15%",
                  }}
                >
                  Kodu
                </TableCell>
                <TableCell
                  sx={{
                    width: "30%",
                  }}
                >
                  Ders Adı
                </TableCell>
                <TableCell>Fakülte / Bölüm</TableCell>
                <TableCell align="center">Kredi</TableCell>
                <TableCell></TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {selectedSubjects.map((subject, index) => (
                <TableRow
                  sx={{
                    backgroundColor: theme.palette.success.lighter,
                  }}
                  key={index}
                >
                  <TableCell
                    sx={{
                      width: "15%",
                    }}
                    size="small"
                  >
                    {subject.subjectCode}
                  </TableCell>
                  <TableCell
                    sx={{
                      width: "30%",
                    }}
                    size="small"
                  >
                    {subject.dersAdı}
                  </TableCell>
                  <TableCell size="small">Mühendislik Fakültesi</TableCell>
                  <TableCell size="small" align="center">
                    {subject.kredi}
                  </TableCell>
                  <TableCell size="small">
                    <IconButton onClick={handleRemove(subject)}>
                      <DeleteRoundedIcon color="error" />
                    </IconButton>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </Box>
    </Box>
  );
};

export default LecturerSubjectRegistration;
