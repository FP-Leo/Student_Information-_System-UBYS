import { Box, Typography } from "@mui/material";
import { useTheme } from "@mui/material/styles";

const HaftaIcerikleri = () => {
  const theme = useTheme();
  return (
    <Box
      sx={{
        display: "flex",
        flexDirection: "column",
      }}
    >
      <Box
        sx={{
          paddingLeft: 3,
          width: "100%",
          height: "50px",
          display: "flex",
          alignItems: "center",
          borderBottom: `1px solid ${theme.palette.divider}`,
        }}
      >
        <Typography variant="subtitle2">Ders İçerikleri</Typography>
      </Box>
      <Box
        sx={{
          display: "flex",
          p: 3,
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <Typography color="error" variant="caption">
          Henüz ders içeriği eklenmemiştir.
        </Typography>
      </Box>
    </Box>
  );
};

export default HaftaIcerikleri;
