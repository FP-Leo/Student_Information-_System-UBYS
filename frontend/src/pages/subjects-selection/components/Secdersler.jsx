import { Box, Typography, Button } from "@mui/material";
import { useTheme } from "@mui/material/styles";

const SecDersler = () => {
  const theme = useTheme();
  return (
    <Box
      sx={{
        marginLeft: "15px",
        marginTop: "15px",
        borderRadius: "10px",
        backgroundColor: "white",
        height: "auto",
        boxShadow: theme.customShadows.card,
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
      }}
    >
      <Box sx={{ marginY: "5px", marginX: "10px" }}>
        <Button variant="headerButton">Aciklama</Button>

        <Button variant="headerButton">Zorunlu Dersler</Button>

        <Button variant="headerButton">Üst Dönem Dersler</Button>

        <Button variant="headerButton">Başarılı Olunan Dersler</Button>

        <Button variant="headerButton">Seçmeli Dersler</Button>

        <Button variant="headerButton">Program Dışı Dersler</Button>
      </Box>
      <Box
        sx={{
          marginY: "20px",
          height: "70px",
          width: "95%",
          borderRadius: "10px",
          backgroundColor: theme.palette.info.light,
        }}
      ></Box>
    </Box>
  );
};

export default SecDersler;
