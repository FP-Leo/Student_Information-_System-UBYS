import { TableCell, TableRow } from "@mui/material";
import { useTheme } from "@mui/material/styles";
const LecturerSubjectRow = () => {
  const theme = useTheme();
  return (
    <TableRow
      sx={{
        "&:nth-of-type(odd)": {
          backgroundColor: theme.palette.action.hover,
        },
      }}
    >
      <TableCell>BLM101</TableCell>
      <TableCell>Introduction to Computer Science</TableCell>
      <TableCell>Computer Engineering</TableCell>
      <TableCell>3</TableCell>
      <TableCell>5</TableCell>
    </TableRow>
  );
};

export default LecturerSubjectRow;
