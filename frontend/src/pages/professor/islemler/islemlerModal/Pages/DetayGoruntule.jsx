import { Box } from "@mui/material";
import DetayGoruntuleItem from "./Components/DetayGoruntuleItem";

export default function DetayGoruntule({ course }) {
  const { dersAdi, dersFakulte, dersBirimi, dersKodu } = course;
  return (
    <Box display={"flex"} flexDirection={"column"} py={10}>
      <DetayGoruntuleItem title={"Ders Adı : "} desc={dersAdi} />

      <DetayGoruntuleItem title={"Ders Fakülte : "} desc={dersFakulte} />

      <DetayGoruntuleItem title={"Ders Bölüm : "} desc={dersBirimi} />

      <DetayGoruntuleItem title={"Ders Kodu : "} desc={dersKodu} />

      <DetayGoruntuleItem title={"Ders AKTS : "} desc={5} />

      <DetayGoruntuleItem title={"Kayıtlı Öğrenci Sayısı : "} desc={70} />
    </Box>
  );
}
