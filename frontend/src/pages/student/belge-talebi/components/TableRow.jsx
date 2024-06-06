import { useTheme } from "@mui/material/styles";
import { Box, IconButton, Typography } from "@mui/material";

import DownloadIcon from "assets/download-icon";
import { PDFDownloadLink } from "@react-pdf/renderer";
import StudentInfoPdf from "./studentInfoPdf";

const studentData = {
  nationality: "Arnavutluk",
  fatherName: "Agim",
  class: "LİSANS",
  educationLevel: "Isaj",
  lastName: "Erlindi",
  firstName: "Valdete",
  studentId: "200401114",
  tcId: "99399599530",
  motherName: "Valdete",
  birthPlace: "Arnavutluk",
  birthDate: "03.05.2002",
  studentStatus: "Aktif",
  registrationDate: "27.10.2020",
  registrationType:
    "YÖS İle Yerleşen (Kendi imkanlarıyla eğitim almak isteyen)",
  preparatoryClassStatus: "Hazırlık Sınıfı Yok",
  schoolAddress: "Terzioğlu Kampüsü Mühendislik Fakültesi 17100",
  scholarshipType: "Burs Almıyor",
  department: "BİLGİSAYAR MÜHENDİSLİĞİ",
  minStudyDuration: 4,
  maxStudyDuration: 7,
  educationType: "Normal Öğretim",
};

const TableRow = ({ data }) => {
  const { id, type, date, language, status } = data;
  const theme = useTheme();
  const generatePdf = () => {
    <PDFDownloadLink
      document={<StudentInfoPdf studentData={studentData} />}
      fileName="student_document.pdf"
    >
      {({ blob, url, loading, error }) =>
        loading ? "Loading document..." : "Download now!"
      }
    </PDFDownloadLink>;
  };

  return (
    <Box
      sx={{
        paddingX: 2,
        backgroundColor: theme.palette.grey[100],
        display: "grid",
        alignItems: "center",
        gridTemplateColumns: "1fr 1fr 1fr 1fr 1fr 1fr",
      }}
    >
      <Typography variant="body2">{id}</Typography>
      <Typography variant="body2">{type}</Typography>
      <Typography variant="body2">{language}</Typography>
      <Typography variant="body2">{date}</Typography>
      <Typography
        color={status === "Onaylanmadı" ? "error" : "success.main"}
        variant="body2"
      >
        {status}
      </Typography>
      <Box>
        <PDFDownloadLink
          document={<StudentInfoPdf studentData={data} />}
          fileName="student_document.pdf"
        >
          {({ blob, url, loading, error }) =>
            loading ? null : <IconButton>{<DownloadIcon />}</IconButton>
          }
        </PDFDownloadLink>
      </Box>
    </Box>
  );
};

export default TableRow;
