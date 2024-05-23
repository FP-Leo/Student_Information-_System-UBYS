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
      },
      {
        dersKodu: "MATH201",
        dersAdi: "Calculus I",
        kredi: 3,
        akts: 5,
        hbn: "BB",
      },
      {
        dersKodu: "PHYS101",
        dersAdi: "Physics I",
        kredi: 4,
        akts: 6,
        hbn: "CC",
      },
      {
        dersKodu: "HIST101",
        dersAdi: "History of Modern Turkey",
        kredi: 2,
        akts: 3,
        hbn: "DD",
      },
      {
        dersKodu: "CS201",
        dersAdi: "Discrete Mathematics",
        kredi: 3,
        akts: 5,
        hbn: "AA",
      },
      {
        dersKodu: "MATH203",
        dersAdi: "Differential Equations",
        kredi: 3,
        akts: 5,
        hbn: "BB",
      },
      {
        dersKodu: "CHEM101",
        dersAdi: "General Chemistry",
        kredi: 4,
        akts: 6,
        hbn: "CC",
      },
      {
        dersKodu: "SOC101",
        dersAdi: "Introduction to Sociology",
        kredi: 3,
        akts: 4,
        hbn: "DD",
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
      },
      {
        dersKodu: "MATH201",
        dersAdi: "Calculus I",
        kredi: 3,
        akts: 5,
        hbn: "BB",
      },
      {
        dersKodu: "PHYS101",
        dersAdi: "Physics I",
        kredi: 4,
        akts: 6,
        hbn: "CC",
      },
      {
        dersKodu: "HIST101",
        dersAdi: "History of Modern Turkey",
        kredi: 2,
        akts: 3,
        hbn: "DD",
      },
      {
        dersKodu: "CS301",
        dersAdi: "Object-Oriented Programming",
        kredi: 4,
        akts: 6,
        hbn: "AA",
      },
      {
        dersKodu: "MATH301",
        dersAdi: "Linear Algebra",
        kredi: 3,
        akts: 5,
        hbn: "BB",
      },
      {
        dersKodu: "EE201",
        dersAdi: "Introduction to Electrical Engineering",
        kredi: 4,
        akts: 6,
        hbn: "CC",
      },
      {
        dersKodu: "TURK101",
        dersAdi: "Turkish Language and Literature",
        kredi: 2,
        akts: 3,
        hbn: "DD",
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
