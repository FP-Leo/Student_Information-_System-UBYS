import { Box, Typography } from "@mui/material";
import SecilmisDers from "./SecilmisDers";
import { useTheme } from "@mui/material/styles";

const SeciliDersler = () => {
  const theme = useTheme();
  return (
    <Box
      sx={{
        marginLeft: "15px",
        marginTop: "15px",
        borderRadius: "10px",
        backgroundColor: "white",
        height: "auto",
        width: "450px",
        boxShadow: theme.customShadows.card,
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
      <Box
        mt={3}
        sx={{
          paddingX: "10px",
          height: "90px",
          display: "flex",
          flexDirection: "column",
          justifyContent: "center",
        }}
      >
        <Box
          sx={{
            display: "flex",
            alignItems: "center",
          }}
        >
          <Box
            sx={{
              marginX: "10px",
              backgroundColor: "success.light",
              height: "15px",
              width: "15px",
            }}
          />
          <Typography variant="body2">Seçilmiş Dersler</Typography>
        </Box>
        <Box
          sx={{
            display: "flex",
            marginTop: "5px",
            alignItems: "center",
          }}
        >
          <Box
            sx={{
              marginX: "10px",
              backgroundColor: "error.light",
              height: "15px",
              width: "15px",
            }}
          />
          <Typography variant="body2">Zorunlu Seçilmiş Dersler</Typography>
        </Box>
        <Box
          sx={{
            display: "flex",
            marginTop: "5px",
            alignItems: "center",
          }}
        >
          <Box
            sx={{
              marginX: "10px",
              backgroundColor: "warning.light",
              height: "15px",
              width: "15px",
            }}
          />
          <Typography variant="body2">Seçmeli Havuzlar</Typography>
        </Box>
      </Box>
    </Box>
  );
};

export default SeciliDersler;
