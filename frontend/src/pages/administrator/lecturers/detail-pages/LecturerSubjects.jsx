import {
  Box,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography,
} from "@mui/material";

import { useTheme } from "@mui/material/styles";
import LecturerSubjectRow from "../components/LecturerSubjectRow";
const LecturerSubjects = () => {
  const theme = useTheme();
  return (
    <Box
      sx={{
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        width: "100%",
      }}
    >
      <Box
        sx={{
          width: "100%",
          marginTop: 5,
          paddingX: 10,
        }}
      >
        <Typography variant="subtitle1">Lecturer Subjects</Typography>
      </Box>
      <Box
        sx={{
          width: "80%",
          marginTop: 3,
        }}
      >
        <TableContainer
          sx={{
            borderRadius: "10px",
            backgroundColor: theme.palette.common.white,
            boxShadow: theme.customShadows.z8,
          }}
        >
          <Table>
            <TableHead
              sx={{
                backgroundColor: theme.palette.grey[300],
              }}
            >
              <TableRow>
                <TableCell>Ders Kodu</TableCell>
                <TableCell
                  sx={{
                    width: "30%",
                  }}
                >
                  Ders Adı
                </TableCell>
                <TableCell
                  sx={{
                    width: "30%",
                  }}
                >
                  Fakülte / Bölüm
                </TableCell>
                <TableCell>Kredi</TableCell>
                <TableCell>AKTS</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              <LecturerSubjectRow />
              <LecturerSubjectRow />
              <LecturerSubjectRow />
              <LecturerSubjectRow />
              <LecturerSubjectRow />
            </TableBody>
          </Table>
        </TableContainer>
      </Box>
    </Box>
  );
};
export default LecturerSubjects;
