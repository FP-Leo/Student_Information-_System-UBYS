import {
  Box,
  Button,
  Grid,
  Table,
  TableContainer,
  Typography,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  Paper,
} from "@mui/material";
import { useTheme, alpha } from "@mui/material/styles";

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
        <Box
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
            <Typography variant="subtitle1">2024 Bahar Dersleri</Typography>
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
              <TableHead>
                <TableRow colSpan={8}>
                  <TableCell colSpan={1}>Ders Kodu</TableCell>
                  <TableCell colSpan={4}>Ders Adı</TableCell>
                  <TableCell colSpan={1}>Devam Durumu</TableCell>
                  <TableCell colSpan={1}>Sınavlar</TableCell>
                  <TableCell colSpan={1}>Devamsızlık</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                <TableRow
                  colSpan={8}
                  sx={{
                    "&:nth-of-type(odd)": {
                      backgroundColor: theme.palette.background.paper,
                    },
                  }}
                >
                  <TableCell colSpan={1}>MAT101</TableCell>
                  <TableCell colSpan={4}>Matematik</TableCell>
                  <TableCell colSpan={1}>%80</TableCell>
                  <TableCell colSpan={1}>100</TableCell>
                  <TableCell colSpan={1}>2</TableCell>
                </TableRow>
              </TableBody>
            </Table>
          </TableContainer>
        </Box>
      </Box>
    </Box>
  );
};
export default StudentsInformation;
