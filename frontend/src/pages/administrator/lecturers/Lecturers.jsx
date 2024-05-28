import {
  Box,
  Typography,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Grid,
} from "@mui/material";
import { useTheme } from "@mui/material/styles";
import LecturerTableRow from "./components/LecturerTableRow";

const LECTURERS = [
  {
    id: 1,
    name: "Prof. Dr. Ahmet Yıldız",
    number: "123456",
    department: "Bilgisayar Mühendisliği",
    faculty: "Mühendislik",
    status: "Aktif",
  },
  {
    id: 2,
    name: "Prof. Dr. Ayşe Demir",
    number: "654321",
    department: "Elektrik-Elektronik Mühendisliği",
    faculty: "Mühendislik",
    status: "Aktif",
  },
  {
    id: 3,
    name: "Doç. Dr. Mehmet Kara",
    number: "112233",
    department: "Makine Mühendisliği",
    faculty: "Mühendislik",
    status: "Aktif",
  },
  {
    id: 4,
    name: "Yrd. Doç. Dr. Zeynep Kaya",
    number: "334455",
    department: "İnşaat Mühendisliği",
    faculty: "Mühendislik",
    status: "Aktif",
  },
  {
    id: 5,
    name: "Prof. Dr. Ali Vural",
    number: "556677",
    department: "Kimya Mühendisliği",
    faculty: "Mühendislik",
    status: "Aktif",
  },
  {
    id: 6,
    name: "Dr. Öğr. Üyesi Elif Yılmaz",
    number: "778899",
    department: "Endüstri Mühendisliği",
    faculty: "Mühendislik",
    status: "Aktif",
  },
  {
    id: 7,
    name: "Prof. Dr. Burak Can",
    number: "998877",
    department: "Bilgisayar Mühendisliği",
    faculty: "Mühendislik",
    status: "Aktif",
  },
  {
    id: 8,
    name: "Doç. Dr. Cemal Aydın",
    number: "223344",
    department: "Elektrik-Elektronik Mühendisliği",
    faculty: "Mühendislik",
    status: "Aktif",
  },
  {
    id: 9,
    name: "Yrd. Doç. Dr. Deniz Öz",
    number: "556688",
    department: "Makine Mühendisliği",
    faculty: "Mühendislik",
    status: "Aktif",
  },
  {
    id: 10,
    name: "Prof. Dr. Fatma Çelik",
    number: "112244",
    department: "İnşaat Mühendisliği",
    faculty: "Mühendislik",
    status: "Aktif",
  },
  {
    id: 11,
    name: "Dr. Öğr. Üyesi Gökhan Şahin",
    number: "334466",
    department: "Kimya Mühendisliği",
    faculty: "Mühendislik",
    status: "Aktif",
  },
];

const Lecturers = () => {
  const theme = useTheme();
  return (
    <Box
      sx={{
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        marginY: 5,
      }}
    >
      <Typography variant="subtitle1">Lecturers List</Typography>
      <Box
        sx={{
          overflowY: "scroll",
          height: "450px",
          borderRadius: 2,
          boxShadow: theme.customShadows.z8,
          backgroundColor: theme.palette.common.white,
          padding: 1,
          marginTop: 3,
          width: "80%",
        }}
      >
        <Box
          sx={{
            backgroundColor: theme.palette.background.paper,
            width: "100%",
            display: "grid",
            height: "50px",
            border: `1px solid ${theme.palette.grey[500]}`,
            justifyContent: "center",
            alignItems: "center",
            gridTemplateColumns: "0.8fr 1.5fr 2.5fr 3fr 1.2fr 1fr",
          }}
        >
          <Box
            sx={{
              height: "100%",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              borderRight: `1px solid ${theme.palette.grey[500]}`,
            }}
          >
            <Typography variant="subtitle2">Resim</Typography>
          </Box>
          <Box
            sx={{
              height: "100%",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              borderRight: `1px solid ${theme.palette.grey[500]}`,
            }}
          >
            <Typography variant="subtitle2">Numerası</Typography>
          </Box>{" "}
          <Box
            sx={{
              height: "100%",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              borderRight: `1px solid ${theme.palette.grey[500]}`,
            }}
          >
            <Typography variant="subtitle2">Ad Soyad</Typography>
          </Box>{" "}
          <Box
            sx={{
              height: "100%",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              borderRight: `1px solid ${theme.palette.grey[500]}`,
            }}
          >
            <Typography variant="subtitle2">Fakülte/Bölüm</Typography>
          </Box>{" "}
          <Box
            sx={{
              height: "100%",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              borderRight: `1px solid ${theme.palette.grey[500]}`,
            }}
          >
            <Typography variant="subtitle2">Durum</Typography>
          </Box>{" "}
          <Box
            sx={{
              height: "100%",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
            }}
          >
            <Typography variant="subtitle2">İşlemler</Typography>
          </Box>
        </Box>
        {LECTURERS.map((lecturer) => (
          <LecturerTableRow data={lecturer} key={lecturer.id} />
        ))}
      </Box>
    </Box>
  );
};
export default Lecturers;
