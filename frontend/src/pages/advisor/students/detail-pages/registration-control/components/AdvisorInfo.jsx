import { Box, Typography } from "@mui/material";
import { useTheme } from "@mui/material/styles";

const AdvisorInfo = () => {
  const theme = useTheme();
  return (
    <Box
      sx={{
        width: "30%",
        backgroundColor: theme.palette.common.white,
        boxShadow: theme.customShadows.z4,
        borderRadius: "5px",
        margin: 2,
      }}
    >
      <Box
        sx={{
          height: "40px",
          backgroundColor: theme.palette.grey[300],
          display: "flex",
          alignItems: "center",
          borderRadius: "5px 5px 0 0",
          paddingX: 2,
        }}
      >
        {" "}
        <Typography variant="caption">Advisor Information</Typography>
      </Box>
      <Box
        sx={{
          paddingY: 4,
          paddingX: 2,
          display: "flex",
          flexDirection: "column",
          justifyContent: "center",
        }}
      >
        <Typography variant="caption">Ad Soyad:</Typography>
        <Typography variant="caption">Email:</Typography>
        <Typography variant="caption">Tel:</Typography>
      </Box>
    </Box>
  );
};

export default AdvisorInfo;
