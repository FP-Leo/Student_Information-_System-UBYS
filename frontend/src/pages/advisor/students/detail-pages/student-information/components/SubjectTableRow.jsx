import { useTheme } from "@mui/material/styles";
import { Box, TableCell, TableRow, Typography } from "@mui/material";

const SubjectTableRow = ({ subject }) => {
  const { courseName, courseCode, vize, final, state } = subject;
  const theme = useTheme();

  return (
    <TableRow
      sx={{
        height: "30px",
        "&:nth-of-type(odd)": {
          backgroundColor: theme.palette.background.paper,
        },
      }}
    >
      <TableCell size="small">{courseCode}</TableCell>
      <TableCell size="small">{courseName}</TableCell>
      <TableCell size="small" align="center">
        {state}
      </TableCell>
      <TableCell
        size="small"
        sx={{
          display: "flex",
          flexDirection: "column",
        }}
      >
        <Box>
          <Typography variant="caption2">{"Vize: "}</Typography>
          <Typography sx={{ marginLeft: 1 }} variant="caption2">
            {"Sıralama: "}
          </Typography>
        </Box>
        <Box>
          <Typography variant="caption2">{"Final: "}</Typography>
          <Typography sx={{ marginLeft: 1 }} variant="caption2">
            {"Sıralama: "}
          </Typography>
        </Box>
      </TableCell>
      <TableCell align="center">-</TableCell>
    </TableRow>
  );
};

export default SubjectTableRow;
