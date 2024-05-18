import { Box, Typography } from "@mui/material";
import { Data } from "data";
import { useTheme } from "@mui/material/styles";
import Ders from "../Ders";
import SelectSubjectsTableHeader from "components/SelectSubjectsTableHeader";

const BasariliOnunanDersler = () => {
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
          minWidth: "95%",
          height: "auto",
          maxWidth: "95%",
          borderRadius: "10px",
          justifyContent: "center",
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
          Başarılı olunan derslerim tabında daha önce aldığınız ve başarılı
          olduğunuz dersler yer almaktadır. Not yükseltme amacı ile bu
          derslerden seçebilirsiniz.
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
        {Data.basariliOlunan.map((item) => (
          <Ders data={item} />
        ))}
      </Box>
    </Box>
  );
};

export default BasariliOnunanDersler;
