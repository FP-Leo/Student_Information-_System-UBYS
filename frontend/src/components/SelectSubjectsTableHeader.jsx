import { Box, Typography } from "@mui/material";

const SelectSubjectsTableHeader = () => {
  return (
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
        variant="subtitle2"
        sx={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        Seç
      </Typography>
      <Typography
        variant="subtitle2"
        sx={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        Ders Kodu
      </Typography>
      <Typography
        variant="subtitle2"
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
        variant="subtitle2"
        sx={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        AKTS
      </Typography>
      <Typography
        variant="subtitle2"
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
        variant="subtitle2"
        sx={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        Açıklama
      </Typography>
    </Box>
  );
};

export default SelectSubjectsTableHeader;
