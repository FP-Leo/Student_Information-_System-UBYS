import { useTheme } from "@mui/material/styles";
import { Box, Typography } from "@mui/material";

const InfoBox = ({ description, heading }) => {
  const theme = useTheme();
  return (
    <Box
      sx={{
        height: "auto",
        width: "100%",
        borderRadius: "10px",
        display: "flex",
        flexDirection: "column",
        alignItems: "flex-start",
        backgroundColor: theme.palette.info.light,
        padding: "10px",
        marginTop: "10px",
      }}
    >
      {heading && (
        <Typography variant="subtitle2" color="error">
          {heading}
        </Typography>
      )}
      <Typography variant="caption2" color="info.darker">
        {description}
      </Typography>
    </Box>
  );
};

export default InfoBox;
