import { useTheme } from "@mui/material/styles";
import { Box, Typography } from "@mui/material";
import WarningRoundedIcon from "@mui/icons-material/WarningRounded";

const InfoCard = ({ content }) => {
  const theme = useTheme();

  return (
    <Box
      sx={{
        border: `1px solid ${theme.palette.info.main}`,
        backgroundColor: theme.palette.background.paper,
        borderRadius: 1,
        padding: 2,
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "center",
        marginX: 2,
        minWidth: "250px",
        height: "200px",
      }}
    >
      <WarningRoundedIcon color="info" />
      <Box
        sx={{
          marginTop: 1,
          display: "flex",
          justifyContent: "center",
        }}
      >
        <Typography textAlign="center" variant="caption">
          {content}
        </Typography>
      </Box>
    </Box>
  );
};

export default InfoCard;
