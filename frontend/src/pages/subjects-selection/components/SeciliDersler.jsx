import { Box, Typography } from "@mui/material";
import SecilmisDers from "./SecilmisDers";

const SeciliDersler = () => {
  return (
    <Box
      sx={{
        marginLeft: "15px",
        marginTop: "15px",
        borderRadius: "10px",
        backgroundColor: "white",
        height: "auto",
        width: "450px",
      }}
    >
      <Box
        sx={{
          borderRadius: "10px 10px 0 0",
          backgroundColor: "#E9E9EA",
          height: "60px",
          width: "100%",
          display: "flex",
          alignItems: "center",
          paddingLeft: 2,
          borderBottom: "1px solid #B3B3B3",
        }}
      >
        <Typography variant="subtitle1">Secili Dersler</Typography>
      </Box>
      <Box
        sx={{
          height: "60px",
          width: "100%",
          display: "flex",
          justifyContent: "space-around",
          borderBottom: "1px solid #B3B3B3",
        }}
      >
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            justifyContent: "center",
          }}
        >
          <Typography variant="body2">En Fazla AKTS</Typography>
          <Typography variant="body2" color="red">
            45
          </Typography>
        </Box>
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            justifyContent: "center",
          }}
        >
          <Typography variant="body2">Seçili AKTS</Typography>
          <Typography variant="body2" color="red">
            10
          </Typography>
        </Box>
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            justifyContent: "center",
          }}
        >
          <Typography variant="body2">Kalan AKTS</Typography>
          <Typography variant="body2" color="red">
            35
          </Typography>
        </Box>
      </Box>
      <Box
        sx={{
          height: "40px",
          backgroundColor: "#E9E9EA",
          display: "grid",
          gridTemplateColumns: "1fr 1.75fr 4fr 1fr",
          gridTemplateRows: "1fr",
          alignItems: "center",
          paddingLeft: 2,
          borderBottom: "1px solid #B3B3B3",
        }}
      >
        <Typography variant="body2">Sıra</Typography>
        <Typography variant="body2">Ders Kodu</Typography>
        <Typography variant="body2">Ders Adı</Typography>
        <Typography variant="body2">AKTS</Typography>
      </Box>
      <SecilmisDers state="success" />
      <SecilmisDers state="success" />
      <SecilmisDers state="success" />
      <SecilmisDers state="error" />
    </Box>
  );
};

export default SeciliDersler;
