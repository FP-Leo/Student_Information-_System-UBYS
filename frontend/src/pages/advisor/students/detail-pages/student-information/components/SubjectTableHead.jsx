import { TableCell, TableHead, TableRow } from "@mui/material";
const SubjectTableHead = () => {
  return (
    <TableHead>
      <TableRow>
        <TableCell
          sx={{
            width: "15%",
          }}
        >
          Ders Kodu
        </TableCell>
        <TableCell sx={{ width: "30%" }}>Ders Adı</TableCell>
        <TableCell align="center">Devam Durumu</TableCell>
        <TableCell sx={{ width: "20%" }}>Sınavlar</TableCell>
        <TableCell align="center">Devamsızlık</TableCell>
      </TableRow>
    </TableHead>
  );
};

export default SubjectTableHead;
