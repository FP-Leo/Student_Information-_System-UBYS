import { TableCell, TableRow } from "@mui/material";
import { useTheme } from "@mui/material/styles";

const LecturerSubjectRow = ({ data }) => {
  const theme = useTheme();
  const { courseCode, courseName, akts, kredi, department } = data;

  return (
    <TableRow
      sx={{
        "&:nth-of-type(odd)": {
          backgroundColor: theme.palette.action.hover,
        },
      }}
    >
      <TableCell>{courseCode}</TableCell>
      <TableCell>{courseName}</TableCell>
      <TableCell>{department}</TableCell>
      <TableCell>{kredi}</TableCell>
      <TableCell>{akts}</TableCell>
    </TableRow>
  );
};

export default LecturerSubjectRow;
