import { Box, Typography } from "@mui/material";
import { Data } from "data";
import { useTheme } from "@mui/material/styles";
import Ders from "../Ders";
import SelectSubjectsTableHeader from "components/SelectSubjectsTableHeader";

const ZorunluDersler = () => {
  const theme = useTheme();
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
        {Data.zorunlu.map((item) => (
          <Ders data={item} />
        ))}
      </Box>
    </Box>
  );
};

export default ZorunluDersler;
