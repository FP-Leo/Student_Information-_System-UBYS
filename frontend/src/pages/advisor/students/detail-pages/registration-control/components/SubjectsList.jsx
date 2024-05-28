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

const SubjectsList = () => {
  const theme = useTheme();
  return (
    <Box
      sx={{
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
        <Typography variant="caption">Seçilmiş Dersler</Typography>
      </Box>
      <Box
        sx={{
          padding: 3,
        }}
      >
        <TableContainer sx={{ border: `1px solid ${theme.palette.grey[500]}` }}>
          <Table>
            <TableHead sx={{ backgroundColor: theme.palette.grey[300] }}>
              <TableRow>
                <TableCell size="small">Ders Kodu</TableCell>
                <TableCell
                  sx={{
                    width: "30%",
                  }}
                >
                  Ders Adı
                </TableCell>
                <TableCell size="small">Dönemi</TableCell>
                <TableCell size="small">AKTS</TableCell>
                <TableCell size="small"> Açıklama</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              <TableRow
                sx={{
                  backgroundColor: theme.palette.success.light,
                }}
                size="small"
              >
                <TableCell size="small">BLM101</TableCell>
                <TableCell size="small">Algoritma ve Programlama I</TableCell>
                <TableCell size="small">1</TableCell>
                <TableCell size="small">6</TableCell>
                <TableCell size="small">Alabilir</TableCell>
              </TableRow>
              <TableRow
                sx={{
                  backgroundColor: theme.palette.success.light,
                }}
                size="small"
              >
                <TableCell size="small">BLM101</TableCell>
                <TableCell size="small">Algoritma ve Programlama I</TableCell>
                <TableCell size="small">1</TableCell>
                <TableCell size="small">6</TableCell>
                <TableCell size="small">Alabilir</TableCell>
              </TableRow>{" "}
              <TableRow
                sx={{
                  backgroundColor: theme.palette.success.light,
                }}
                size="small"
              >
                <TableCell size="small">BLM101</TableCell>
                <TableCell size="small">Algoritma ve Programlama I</TableCell>
                <TableCell size="small">1</TableCell>
                <TableCell size="small">6</TableCell>
                <TableCell size="small">Alabilir</TableCell>
              </TableRow>{" "}
              <TableRow
                sx={{
                  backgroundColor: theme.palette.success.light,
                }}
                size="small"
              >
                <TableCell size="small">BLM101</TableCell>
                <TableCell size="small">Algoritma ve Programlama I</TableCell>
                <TableCell size="small">1</TableCell>
                <TableCell size="small">6</TableCell>
                <TableCell size="small">Alabilir</TableCell>
              </TableRow>{" "}
              <TableRow
                sx={{
                  backgroundColor: theme.palette.success.light,
                }}
                size="small"
              >
                <TableCell size="small">BLM101</TableCell>
                <TableCell size="small">Algoritma ve Programlama I</TableCell>
                <TableCell size="small">1</TableCell>
                <TableCell size="small">6</TableCell>
                <TableCell size="small">Alabilir</TableCell>
              </TableRow>
            </TableBody>
          </Table>
        </TableContainer>
      </Box>
    </Box>
  );
};

export default SubjectsList;
