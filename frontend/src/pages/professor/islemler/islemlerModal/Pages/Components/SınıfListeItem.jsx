import { useTheme } from "@emotion/react";
import { DoNotDisturb } from "@mui/icons-material";
import {
  Avatar,
  Box,
  Button,
  Checkbox,
  TextField,
  Typography,
} from "@mui/material";
import Avatar1 from "assets/avatar1.png";

export default function SınıfListeItem({ type, item, students,setStudents }) {

  const handleFilteringStudents = () =>{
    setStudents(
      students.filter((student)=>student.ssn !== item.ssn)
    )
  }

  const typeGridTempColumns = {
    "Sınıf Görüntüle": "0.5fr 1fr 1fr 1fr",
    "Vize Sınav": "1fr 1.5fr 1.5fr 1.5fr 2fr",
    "Final Sınav": "1fr 1.5fr 1.5fr 1.5fr 2fr",
    "Bütünleme Listesi": "1fr 1.5fr 1.5fr 1fr 4fr",
    "Not Giriş": "1fr 1.5fr 1.5fr 1fr 4fr",
    "Vize Yoklama": "1fr 1fr 1fr 1fr 1fr",
    "Final Yoklama": "1fr 1fr 1fr 1fr 1fr",
    "Öğrenci Not Listesi": "0.75fr 1fr 1fr 0.5fr 1fr 1fr 1fr",
    "Devam Listesi": "1fr 1fr 1fr 1fr 1fr",
    NotFound: "1fr",
  };

  const theme = useTheme();
  let pageTemplate = <></>;
  switch (type) {
    case "Vize Sınav":
      pageTemplate = (
        <>
          <Box display={"flex"}>
            <Typography fontWeight={600} pr={1}>
              Vize Notu : {item.midTerm}
            </Typography>
          </Box>
        </>
      );
      break;
    case "Final Sınav":
      pageTemplate = (
        <>
          <Box display={"flex"}>
            <Typography fontWeight={600} pr={1}>
              Final Notu : {item.final}
            </Typography>
          </Box>
        </>
      );
      break;
    case "Bütünleme Listesi":
      pageTemplate = (
        <>
          <Box
            display={"flex"}
            alignItems={"center"}
            justifyContent={"space-between"}
          >
            <Box display={"flex"} textAlign={"center"} paddingX={"20px"}>
              <Typography fontWeight={600} pr={1}>
                Ortalama:
              </Typography>
              <Typography>{(item.midTerm + item.final) / 2}</Typography>
            </Box>
            <Box display={"flex"}>
              <Button
                sx={{
                  bgcolor: theme.palette.success.main,
                  marginRight: "10px",
                  ":hover": { backgroundColor: theme.palette.success.main },
                }}
              >
                {" "}
                Onayla{" "}
              </Button>
              <Button
                onClick={handleFilteringStudents}
                sx={{
                  bgcolor: theme.palette.error.main,
                  ":hover": { backgroundColor: theme.palette.error.main },
                }}
              >
                {" "}
                Reddet
              </Button>
            </Box>
          </Box>
        </>
      );
      break;
    case "Not Giriş":
      pageTemplate = (
        <>
          <Box display={"flex"}>
            <Box
              sx={{
                paddingRight: "20px",
                display: "flex",
                flexDirection: "column",
              }}
            >
              <TextField
                label="Vize"
                type="number"
                InputLabelProps={{
                  shrink: true,
                }}
                variant="outlined"
                size="small"
              />
            </Box>
            <Box sx={{ paddingRight: "20px" }}>
              <TextField
                label="Final"
                type="number"
                InputLabelProps={{
                  shrink: true,
                }}
                variant="outlined"
                size="small"
              />
            </Box>

            <Box sx={{ paddingRight: "10px" }}>
              <TextField
                label="Büt"
                type="number"
                InputLabelProps={{
                  shrink: true,
                }}
                variant="outlined"
                size="small"
              />
            </Box>
          </Box>
        </>
      );
      break;
    case "Vize Yoklama":
      pageTemplate = (
        <>
          <Box
            display={"flex"}
            alignItems={"center"}
            flexDirection={"column"}
            justifyContent={"center"}
          >
            <Typography>Vize Yoklama</Typography>
            {item.attendanceFulfilled === true ? (
              <Checkbox
                color="success"
                checked={true}
                sx={{
                  ":hover": {
                    backgroundColor: "transparent",
                    cursor: "default",
                  },
                }}
              />
            ) : (
              <Checkbox
                disabled
                checked={true}
                checkedIcon={<DoNotDisturb color="error" />}
              />
            )}
          </Box>
        </>
      );
      break;
    case "Final Yoklama":
      pageTemplate = (
        <>
          <Box
            display={"flex"}
            alignItems={"center"}
            flexDirection={"column"}
            justifyContent={"center"}
          >
            <Typography>Final Yoklama</Typography>
            {item.attendanceFulfilled === true ? (
              <Checkbox
                color="success"
                checked={true}
                sx={{
                  ":hover": {
                    backgroundColor: "transparent",
                    cursor: "default",
                  },
                }}
              />
            ) : (
              <Checkbox
                disabled
                checked={true}
                checkedIcon={<DoNotDisturb color="error" />}
              />
            )}
          </Box>
        </>
      );
      break;
    case "Öğrenci Not Listesi":
      pageTemplate = (
        <>
          <Box
            display={"flex"}
            flexDirection={"column"}
            alignItems={"center"}
            justifyContent={"center"}
          >
            <Typography fontWeight={600} pr={1}>
              Vize Not :
            </Typography>
            <Typography fontWeight={600} pr={1}>
              {item.midTerm}
            </Typography>
          </Box>
          <Box
            display={"flex"}
            flexDirection={"column"}
            alignItems={"center"}
            justifyContent={"center"}
          >
            <Typography fontWeight={600} pr={1}>
              Final Not :
            </Typography>
            <Typography fontWeight={600} pr={1}>
              {item.final}
            </Typography>
          </Box>
          <Box
            display={"flex"}
            flexDirection={"column"}
            alignItems={"center"}
            justifyContent={"center"}
          >
            <Typography fontWeight={600} pr={1}>
              Büt Not :
            </Typography>
            <Typography fontWeight={600} pr={1}>
              -
            </Typography>
          </Box>
        </>
      );
      break;
    case "Devam Listesi":
      pageTemplate = (
        <>
          <Box>
            <Typography
              color={
                item.attendanceFulfilled === true ? theme.palette.success.dark : "error"
              }
            >
              {item.attendanceFulfilled === true ? "Devam Ediyor" : "Devamsızlıktan Kaldı"}
            </Typography>
          </Box>
        </>
      );
      break;
    default:
      break;
  }
  return type !== "NotFound" ? (
    <Box
      sx={{
        width: type === "Sınıf Görüntüle" ? "50vw" : "60vw",
        display: "grid",
        border: "1px solid #B3B3B3",
        gridTemplateColumns: typeGridTempColumns[type],
        alignItems: "center",
        height: "70px",
        paddingX: "10px",
      }}
    >
      <Avatar src={Avatar1}></Avatar>
      <Box display={"flex"}>
        <Typography fontWeight={600} pr={1}>
          {item.studentName}
        </Typography>
      </Box>
      <Box display={"flex"}>
        <Typography fontWeight={600} pr={1}>
          {item.ssn}
        </Typography>
      </Box>
      <Box display={"flex"}>
        <Typography fontWeight={600} pr={1}>
          {item.year}.Sınıf
        </Typography>
      </Box>
      {pageTemplate}
    </Box>
  ) : (
    <>
      <Box width={"50vw"} textAlign={"center"} marginTop={"20px"}>
        Aradığınız Kişi bulunamadı
      </Box>
    </>
  );
}
