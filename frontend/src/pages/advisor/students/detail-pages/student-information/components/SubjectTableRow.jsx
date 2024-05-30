import { useTheme } from "@mui/material/styles";
import { Box, TableCell, TableRow, Typography } from "@mui/material";

const SubjectTableRow = ({ subject }) => {
  const { dersKodu, dersAdi, vize, final, devamDurumu } = subject;
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
      <TableCell size="small">{dersKodu}</TableCell>
      <TableCell size="small">{dersAdi}</TableCell>
      <TableCell size="small" align="center">
        {devamDurumu}
      </TableCell>
      <TableCell
        size="small"
        sx={{
          display: "flex",
          flexDirection: "column",
        }}
      >
        <Box>
          <Typography variant="caption2">{"Vize: " + vize.puan}</Typography>
          <Typography sx={{ marginLeft: 1 }} variant="caption2">
            {"Sıralama: " + vize.siralama}
          </Typography>
        </Box>
        <Box>
          <Typography variant="caption2">{"Final: " + final.puan}</Typography>
          <Typography sx={{ marginLeft: 1 }} variant="caption2">
            {"Sıralama: " + final.siralama}
          </Typography>
        </Box>
      </TableCell>
      <TableCell align="center">-</TableCell>
    </TableRow>
  );
};

export default SubjectTableRow;
