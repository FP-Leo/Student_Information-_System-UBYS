import { Box, Typography } from "@mui/material";
import { useTheme } from "@mui/material/styles";
import TableHeader from "components/TableHeader";

const Subjects = () => {
  const theme = useTheme();
  return (
    <Box
      sx={{
        width: "100%",
        height: "auto",
        display: "flex",
        justifyContent: "center",
      }}
    >
      <Box
        sx={{
          width: "auto",
          marginTop: "50px",
          borderRadius: "10px",
          boxShadow: theme.customShadows.card,
          backgroundColor: "background.neutral",
        }}
      >
        <Box
          sx={{
            marginY: "20px",
            marginX: "35px",
          }}
        >
          <Typography variant="subtitle1">2023 - Bahar</Typography>
        </Box>
        <Box
          sx={{
            width1: "100%",
            display: "flex",
          }}
        >
          <TableHeader title="Ders Kodu" />
          <TableHeader title="Ders Adı" />
          <TableHeader title="Kredi" />
          <TableHeader title="AKTS" />
          <TableHeader title="Dersin Koordinatörü" />
          <TableHeader title="Devam Durumu" />
          <TableHeader title="Geçme Notu" />
          <TableHeader title="HBN" />
          <TableHeader title="Başarı Durumu" />
        </Box>
      </Box>
    </Box>
  );
};

export default Subjects;
