import { Box, Typography } from "@mui/material";
import { Data } from "data";
import { useTheme } from "@mui/material/styles";
import Ders from "../Ders";

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
          variant="body2"
          color="info.darker"
        >
          Başarılı olunan derslerim tabında daha önce aldığınız ve başarılı
          olduğunuz dersler yer almaktadır. Not yükseltme amacı ile bu
          derslerden seçebilirsiniz.
        </Typography>
      </Box>
      <Box
        sx={{
          width: "100%",
          height: "50px",
          backgroundColor: "#E9E9EA",
          display: "grid",
          gridTemplateColumns: "1fr 2fr 5fr 1fr 4fr 2fr ",
        }}
      >
        <Typography
          variant="cardHeader"
          sx={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
          }}
        >
          Seç
        </Typography>
        <Typography
          variant="cardHeader"
          sx={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
          }}
        >
          Ders Kodu
        </Typography>
        <Typography
          variant="cardHeader"
          sx={{
            marginLeft: "20px",
            display: "flex",
            justifyContent: "flex-start",
            alignItems: "center",
          }}
        >
          Ders Adı
        </Typography>
        <Typography
          variant="cardHeader"
          sx={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
          }}
        >
          AKTS
        </Typography>
        <Typography
          variant="cardHeader"
          sx={{
            marginLeft: "20px",
            display: "flex",
            justifyContent: "flex-start",
            alignItems: "center",
          }}
        >
          Şube
        </Typography>
        <Typography
          variant="cardHeader"
          sx={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
          }}
        >
          Açıklama
        </Typography>
      </Box>
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
