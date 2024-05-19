import { Box, IconButton, Typography } from "@mui/material";
import { useTheme } from "@mui/material/styles";
import DownloadIcon from "assets/download-icon";

const TableRow = ({ data }) => {
  const { id, no, type, date, language, status } = data;
  const theme = useTheme();
  return (
    <Box
      sx={{
        paddingX: 2,
        backgroundColor: theme.palette.grey[100],
        display: "grid",
        alignItems: "center",
        gridTemplateColumns: "1fr 1fr 1fr 1fr 1fr 1fr",
      }}
    >
      <Typography variant="body2">{no}</Typography>
      <Typography variant="body2">{type}</Typography>
      <Typography variant="body2">{language}</Typography>
      <Typography variant="body2">{date}</Typography>
      <Typography
        color={status === "Onaylanmadı" ? "error" : "success.main"}
        variant="body2"
      >
        {status}
      </Typography>
      <Box>
        <IconButton variant="contained">
          <DownloadIcon />
        </IconButton>
      </Box>
    </Box>
  );
};

export default TableRow;
