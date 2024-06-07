import { Box } from "@mui/material";
import DetayGoruntuleItem from "./Components/DetayGoruntuleItem";
import axios from "axios";
import { useEffect, useState } from "react";

export default function DetayGoruntule({
  course,
  faculty,
  department,
  courseSize,
}) {
  const { courseName, courseCode } = course;
  const size = courseSize.length;
  console.log(course);
  const PORT = 53675;
  const [akts, setAkts] = useState(0);

  const handleSetAkts = async () => {
    const response = await axios
      .get(
        `http://localhost:5158/api/University/Faculty/Department/Course/Class/Code?CourseCode=BLM-2001`,
        {
          headers: {
            Authorization:
              "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiMTAwMDAwMDAwMDMiLCJyb2xlIjoiTGVjdHVyZXIiLCJuYmYiOjE3MTc1MTkyNzAsImV4cCI6MTcxODEyNDA3MCwiaWF0IjoxNzE3NTE5MjcwLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUyNDYiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUyNDYifQ.eu4xmuFF1i0qXNN9O19aUcDAsn4PLBgsx7SEbpSRTc0Q2pR1jrkJ24Qw829eFcrVq9_q7dNit03P8ZrwzQi2Gg",
          },
          params: { CourseCode: courseCode },
        }
      )
      .then((response) => setAkts(response.data.akts));
  };

  useEffect(() => {
    handleSetAkts();
  });

  return (
    <Box display={"flex"} flexDirection={"column"} py={10}>
      <DetayGoruntuleItem title={"Ders Adı  "} desc={courseName} />

      <DetayGoruntuleItem title={"Ders Fakülte  "} desc={department} />

      <DetayGoruntuleItem title={"Ders Bölüm  "} desc={faculty} />

      <DetayGoruntuleItem title={"Ders Kodu  "} desc={courseCode} />

      <DetayGoruntuleItem title={"Ders AKTS  "} desc={akts} />

      <DetayGoruntuleItem title={"Kayıtlı Öğrenci Sayısı  "} desc={size} />
    </Box>
  );
}
