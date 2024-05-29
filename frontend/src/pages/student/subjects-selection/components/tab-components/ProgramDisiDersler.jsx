import Ders from "../Ders";
import { Data } from "data";

import { Box, Typography } from "@mui/material";
import { useTheme } from "@mui/material/styles";

import SelectSubjectsTableHeader from "components/SelectSubjectsTableHeader";

const ProgramDisiDersler = () => {
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
          minWidth: "95%",
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
          Burada da bölümünüzün kayıtabileceğiniz dersler bulunmaktadır. Kendi
          biriminizde açılmayan dersler başka birimde açılabilir. Öğrenci
          işlerine danışmadan dış birimden ders almayınız.
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
        {Data.programDisi.map((item) => (
          <Ders data={item} />
        ))}
      </Box>
    </Box>
  );
};

export default ProgramDisiDersler;
