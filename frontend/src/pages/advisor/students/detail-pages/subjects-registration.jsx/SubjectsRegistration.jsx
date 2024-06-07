import { useEffect, useState } from "react";
import axios from "axios";

import { useNavigate } from "react-router-dom";

import { useSelector, useDispatch } from "react-redux";

import {
  Box,
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
} from "@mui/material";
import { useTheme, alpha } from "@mui/material/styles";
import CheckRoundedIcon from "@mui/icons-material/CheckRounded";

import {
  selectSelectedSubjects,
  selectFetchedSubjects,
} from "store/ders-secimi/ders-secimi.selector";
import {
  setFetchedSubjects,
  setSelectedSubjects,
} from "store/ders-secimi/ders-secimi.action";

import { isEqual } from "lodash";

import InfoHeader from "./InfoHeader";
import SelectSubjects from "./SelectSubjects";
import InfoCard from "../../components/InfoCard";
import SelectedSubjects from "./SelectedSubjects";

import SendIcon from "assets/send-icon";
import { useParams } from "react-router-dom";
import { selectUserToken } from "store/user/user.selector";
import { selectProgram } from "store/program/program.selector";

const SubjectsRegistration = () => {
  const theme = useTheme();
  const { id } = useParams();
  const token = useSelector(selectUserToken);
  const department = useSelector(selectProgram);

  const dispatch = useDispatch();
  const navigate = useNavigate();

  const [open, setOpen] = useState(false);
  const [changed, setChanged] = useState(false);
  const [tc, setTc] = useState();

  const selectedSubjects = useSelector(selectSelectedSubjects);
  const fetchedSubjects = useSelector(selectFetchedSubjects);

  useEffect(() => {
    axios
      .get(
        "http://localhost:5158/api/University/Faculty/Department/Student/Transcript",
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
          params: {
            DepName: department,
            SSN: id,
          },
        }
      )
      .then((res) => {
        setTc(res.data.studentInfo.tc);
      })
      .catch((err) => console.log(err));

    axios
      .get(
        "http://localhost:5158/api/University/Faculty/Department/Semester/Advisor/Courses/Selected",
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
          params: {
            DepName: department,
            TC: tc,
          },
        }
      )
      .then((res) => {
        console.log(res.data);
      })
      .catch((err) => console.log(err));
    // eslint-disable-next-line
  }, []);

  useEffect(() => {
    if (isEqual(selectedSubjects, fetchedSubjects)) {
      setChanged(false);
    } else {
      setChanged(true);
    }
  }, [selectedSubjects, fetchedSubjects]);

  const handleClose = () => {
    setOpen(false);
  };
  const handleGoBack = () => {
    navigate(-1);
  };

  return (
    <Box
      sx={{
        width: "100%",
        display: "flex",
        alignItems: "flex-start",
        justifyContent: "center",
      }}
    >
      <Box
        sx={{
          borderRadius: "10px",

          border: `1px solid ${theme.palette.divider}`,
          backgroundColor: theme.palette.common.white,
          paddingBottom: 2,
          margin: 2,
          display: "flex",
          flexDirection: "column",
          width: "70%",
          minWidth: "1000px",
        }}
      >
        <InfoHeader />
        <Box
          sx={{
            backgroundColor: theme.palette.common.white,
            display: "flex",
            justifyContent: "space-around",
            alignItems: "center",
            paddingTop: 2,
          }}
        >
          <InfoCard content="(*) ile işaretli dersler Kredi veya Ders Saati toplamlarına katılmaz." />
          <InfoCard content="(**) ile işaretli derslerin Uzaktan Eğitim olarak verilen şubesi vardır. Kayıt yaptırmak istediğiniz şubeyi seçebilirsiniz. Uzaktan Eğitim, Öğretim Elemanı ve öğrencinin aynı ortamda bulunma zorunluluğu olmaksızın elektronik ortamda internet üzerinden verilen eğitim biçimidir." />
          <InfoCard content="Öğrenci Seçtiği Dersleri Onayınıza Göndermiştir. Onaylayabilir veya Ders Seçimi Yapıp Kaydedip Öğrenci Onayına Gönderebilirsiniz. " />
        </Box>
        <SelectSubjects />
      </Box>
      <Box
        sx={{
          display: "flex",
          flexDirection: "column",
          alignItems: "flex-end",
        }}
      >
        {changed ? (
          <Button
            style={{
              color: "white",
              borderRadius: "10px",
              height: "40px",
              marginRight: "15px",
              marginTop: "15px",
            }}
            variant="contained"
            color="success"
          >
            Öğrenci Onayına Gönder &nbsp;
            <SendIcon />
          </Button>
        ) : (
          <Button
            style={{
              color: "white",
              borderRadius: "10px",
              height: "40px",
              marginRight: "15px",
              marginTop: "15px",
            }}
            variant="contained"
            color="success"
          >
            Kayıtlanmayı Tamamla &nbsp;
            <CheckRoundedIcon />
          </Button>
        )}

        <SelectedSubjects />
      </Box>
      <Dialog
        sx={{
          backgroundColor: alpha(theme.palette.error.main, 0.4),
        }}
        open={open}
        onClose={handleClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">{"Important!"}</DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            Öğrenci ders seçimi yapmaktadır. Dersleri sizim onayınıza gönderene
            kadar bir değişiklik yapamazsınız!
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleGoBack} autoFocus>
            Go Back
          </Button>
        </DialogActions>
      </Dialog>
    </Box>
  );
};

export default SubjectsRegistration;
