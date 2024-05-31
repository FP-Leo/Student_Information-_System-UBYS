import Ders from "../Ders";
import { Data } from "data";

import { useTheme } from "@mui/material/styles";
import { Box, Typography } from "@mui/material";

import SelectSubjectsTableHeader from "components/SelectSubjectsTableHeader";

const ZorunluDersler = ({ courses }) => {
  const theme = useTheme();
  const { required, failed } = courses;
  console.log("required", required);
  console.log("failed", failed);
  return (
    <Box
      sx={{
        width: "100%",
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
      }}
    >
      <Box
        sx={{
          marginY: "20px",
          height: "auto",
          maxWidth: "95%",
          borderRadius: "10px",
          display: "flex",
          backgroundColor: theme.palette.info.light,
          padding: "10px",
        }}
      >
        <Typography
          sx={{
            textAlign: "center",
          }}
          variant="caption2"
          color="info.darker"
        >
          Burada bölümünüze ait açmış veya daha önceki dönemlerinizde kaldığınız dersler yer almaktadır.
          (Önceki dönemde kalıp
          bu dönem açılmamışsa otomatik kayıtlıdır ve o dersleri burada göremiyorsunuz.)
          Mezun olabilmek için tamamlamanız zorunlu derslerdir.
        </Typography>
      </Box>
      <SelectSubjectsTableHeader />
      <Box
        sx={{
          backgroundColor: "background.neutral",
          width: "100%",
          display: "flex",
          flexDirection: "column",
        }}
      >
        {failed
          ? failed.map((item, index) => (
              <Ders state="failed" key={index} data={item} />
            ))
          : null}
        {required ? (
          required.map((item, index) => (
            <Ders state="success" key={index} data={item} />
          ))
        ) : (
          <Typography
            padding={3}
            color="error"
            textAlign="center"
            variant="subtitle2"
          >
            Ders bulunamadı.
          </Typography>
        )}
      </Box>
    </Box>
  );
};

export default ZorunluDersler;
