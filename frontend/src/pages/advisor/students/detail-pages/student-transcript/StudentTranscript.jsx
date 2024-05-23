import TranscriptTable from "../../components/TranscriptTable";
import { Box, Typography } from "@mui/material";
import { useParams } from "react-router-dom";
const data = [
  {
    year: "2024",
    semester: "1. Yarıyıl",
    subjects: [
      {
        dersKodu: "CS101",
        dersAdi: "Introduction to Computer Science",
        kredi: 4,
        akts: 6,
        hbn: "AA",
        devamDurumu: "Devamlı",
        vize: {
          puan: 80,
          siralama: 10,
        },
        final: {
          puan: 90,
          siralama: 5,
        },
      },
      {
        dersKodu: "MATH201",
        dersAdi: "Calculus I",
        kredi: 3,
        akts: 5,
        hbn: "BB",
        devamDurumu: "Devamlı",
        vize: {
          puan: 80,
          siralama: 10,
        },
        final: {
          puan: 90,
          siralama: 5,
        },
      },
      {
        dersKodu: "PHYS101",
        dersAdi: "Physics I",
        kredi: 4,
        akts: 6,
        hbn: "CC",
        devamDurumu: "Devamlı",
        vize: {
          puan: 80,
          siralama: 10,
        },
        final: {
          puan: 90,
          siralama: 5,
        },
      },
      {
        dersKodu: "HIST101",
        dersAdi: "History of Modern Turkey",
        kredi: 2,
        akts: 3,
        hbn: "DD",
        devamDurumu: "Devamlı",
        vize: {
          puan: 80,
          siralama: 10,
        },
        final: {
          puan: 90,
          siralama: 5,
        },
      },
      {
        dersKodu: "CS201",
        dersAdi: "Discrete Mathematics",
        kredi: 3,
        akts: 5,
        hbn: "AA",
        devamDurumu: "Devamlı",
        vize: {
          puan: 80,
          siralama: 10,
        },
        final: {
          puan: 90,
          siralama: 5,
        },
      },
      {
        dersKodu: "MATH203",
        dersAdi: "Differential Equations",
        kredi: 3,
        akts: 5,
        hbn: "BB",
        devamDurumu: "Devamlı",
        vize: {
          puan: 80,
          siralama: 10,
        },
        final: {
          puan: 90,
          siralama: 5,
        },
      },
      {
        dersKodu: "CHEM101",
        dersAdi: "General Chemistry",
        kredi: 4,
        akts: 6,
        hbn: "CC",
        devamDurumu: "Devamlı",
        vize: {
          puan: 80,
          siralama: 10,
        },
        final: {
          puan: 90,
          siralama: 5,
        },
      },
      {
        dersKodu: "SOC101",
        dersAdi: "Introduction to Sociology",
        kredi: 3,
        akts: 4,
        hbn: "DD",
        devamDurumu: "Devamlı",
        vize: {
          puan: 80,
          siralama: 10,
        },
        final: {
          puan: 90,
          siralama: 5,
        },
      },
    ],
  },
  {
    year: "2024",
    semester: "2. Yarıyıl",
    subjects: [
      {
        dersKodu: "CS101",
        dersAdi: "Introduction to Computer Science",
        kredi: 4,
        akts: 6,
        hbn: "AA",
        devamDurumu: "Devamlı",
        vize: {
          puan: 80,
          siralama: 10,
        },
        final: {
          puan: 90,
          siralama: 5,
        },
      },
      {
        dersKodu: "MATH201",
        dersAdi: "Calculus I",
        kredi: 3,
        akts: 5,
        hbn: "BB",
        devamDurumu: "Devamlı",
        vize: {
          puan: 80,
          siralama: 10,
        },
        final: {
          puan: 90,
          siralama: 5,
        },
      },
      {
        dersKodu: "PHYS101",
        dersAdi: "Physics I",
        kredi: 4,
        akts: 6,
        hbn: "CC",
        devamDurumu: "Devamlı",
        vize: {
          puan: 80,
          siralama: 10,
        },
        final: {
          puan: 90,
          siralama: 5,
        },
      },
      {
        dersKodu: "HIST101",
        dersAdi: "History of Modern Turkey",
        kredi: 2,
        akts: 3,
        hbn: "DD",
        devamDurumu: "Devamlı",
        vize: {
          puan: 80,
          siralama: 10,
        },
        final: {
          puan: 90,
          siralama: 5,
        },
      },
      {
        dersKodu: "CS301",
        dersAdi: "Object-Oriented Programming",
        kredi: 4,
        akts: 6,
        hbn: "AA",
        devamDurumu: "Devamlı",
        vize: {
          puan: 80,
          siralama: 10,
        },
        final: {
          puan: 90,
          siralama: 5,
        },
      },
      {
        dersKodu: "MATH301",
        dersAdi: "Linear Algebra",
        kredi: 3,
        akts: 5,
        hbn: "BB",
        devamDurumu: "Devamlı",
        vize: {
          puan: 80,
          siralama: 10,
        },
        final: {
          puan: 90,
          siralama: 5,
        },
      },
      {
        dersKodu: "EE201",
        dersAdi: "Introduction to Electrical Engineering",
        kredi: 4,
        akts: 6,
        hbn: "CC",
        devamDurumu: "Devamlı",
        vize: {
          puan: 80,
          siralama: 10,
        },
        final: {
          puan: 90,
          siralama: 5,
        },
      },
      {
        dersKodu: "TURK101",
        dersAdi: "Turkish Language and Literature",
        kredi: 2,
        akts: 3,
        hbn: "DD",
        devamDurumu: "Devamlı",
        vize: {
          puan: 80,
          siralama: 10,
        },
        final: {
          puan: 90,
          siralama: 5,
        },
      },
    ],
  },
];

const StudentTranscript = () => {
  const { id } = useParams();
  return (
    <Box
      sx={{
        marginY: 3,
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "center",
      }}
    >
      <Box
        sx={{
          paddingLeft: 10,
          marginBottom: 3,
          width: "100%",
          display: "flex",
        }}
      >
        <Typography variant="subtitle1">Öğrenci no.</Typography>
        <Typography
          sx={{
            marginLeft: 2,
          }}
        >
          {id}
        </Typography>
      </Box>
      {data.map((transcript, index) => (
        <TranscriptTable key={index} data={transcript} />
      ))}
    </Box>
  );
};

export default StudentTranscript;
