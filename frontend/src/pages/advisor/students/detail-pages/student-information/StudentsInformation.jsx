import {
  Box,
  Table,
  TableContainer,
  Typography,
  TableBody,
} from "@mui/material";
import { useTheme, alpha } from "@mui/material/styles";
import SubjectTableRow from "./components/SubjectTableRow";
import SubjectTableHead from "./components/SubjectTableHead";
import { data } from "./../student-transcript/StudentTranscript";

const StudentsInformation = () => {
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
          marginY: 3,
          paddingLeft: 10,
          width: "100%",
          display: "flex",
        }}
      >
        <Typography variant="subtitle1">Öğrenci Bilgileri</Typography>
      </Box>
      <Box
        sx={{
          padding: 2,
          width: "90%",
          backgroundColor: theme.palette.common.white,
          border: `1px solid ${theme.palette.grey[300]}`,
          borderRadius: 1,
          boxShadow: theme.customShadows.z4,
        }}
      >
        <Box
          sx={{
            display: "grid",
            gridTemplateColumns: "0.7fr 3fr",
          }}
        >
          <Box
            sx={{
              display: "flex",
              flexDirection: "column",
              alignItems: "flex-start",
            }}
          >
            <Typography variant="caption">Öğrenci Numerası:</Typography>
            <Typography variant="caption">Adı:</Typography>
            <Typography variant="caption">Programı:</Typography>
            <Typography variant="caption">Sınıf/Ders Dönemi:</Typography>
          </Box>
          <Box
            sx={{
              display: "flex",
              flexDirection: "column",
              alignItems: "flex-start",
            }}
          >
            <Typography variant="caption2">123456</Typography>
            <Typography variant="caption2">Ali Veli</Typography>
            <Typography variant="caption2">Bilgisayar Mühendisliği</Typography>
            <Typography variant="caption2">3. Sınıf/Bahar</Typography>
          </Box>
        </Box>
        {data.map((item, index) => (
          <Box
            key={index}
            sx={{
              marginTop: 2,
            }}
          >
            <Box
              sx={{
                padding: 2,
                backgroundColor: theme.palette.grey[200],
              }}
            >
              <Typography variant="subtitle1">
                {item.year + " " + item.semester}
              </Typography>
            </Box>

            <TableContainer
              sx={{
                boxShadow: "none",
                borderRadius: "none",
                backgroundColor: alpha(theme.palette.background.default, 0.9),
              }}
            >
              <Table
                sx={{
                  boxShadow: "none",
                  borderRadius: "none",
                }}
              >
                <SubjectTableHead />
                <TableBody>
                  {item.subjects.map((subject, index) => (
                    <SubjectTableRow key={index} subject={subject} />
                  ))}
                </TableBody>
              </Table>
            </TableContainer>
          </Box>
        ))}
      </Box>
    </Box>
  );
};
export default StudentsInformation;
