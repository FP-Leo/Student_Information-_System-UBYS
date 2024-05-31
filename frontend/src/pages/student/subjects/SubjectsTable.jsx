import { useTheme } from "@mui/material/styles";
import { Box, Typography } from "@mui/material";

import TableRow from "components/TableRow";
import TableHeader from "components/TableHeader";

const SubjectsTable = ({ subjects }) => {
  const theme = useTheme();
  return (
    <Box
      sx={{
        width: "1200px",
        minWidth: "1200px",
        marginTop: "50px",
        borderRadius: "10px",
        boxShadow: theme.customShadows.card,
        backgroundColor: "background.neutral",
        paddingBottom: "30px",
        marginBottom: "50px",
      }}
    >
      <Box
        sx={{
          marginY: "20px",
          marginX: "35px",
        }}
      >
        <Typography variant="subtitle1">2023 - Bahar</Typography>
      </Box>
      <Box
        sx={{
          width: "100%",
          display: "grid",
          gridTemplateColumns: "1.5fr 2fr 1fr 1fr 2fr 2fr 1fr 2fr",
          borderLeft: "1px solid #B3B3B3",
          borderRight: "1px solid #B3B3B3",
        }}
      >
        <TableHeader left={false} right={true} title="Ders Kodu" />
        <TableHeader left={false} right={false} title="Ders Adı" />
        <TableHeader left={true} right={true} title="Kredi" />
        <TableHeader left={false} right={true} title="AKTS" />
        <TableHeader left={false} right={true} title="Devam Durumu" />
        <TableHeader left={false} right={false} title="Geçme Notu" />
        <TableHeader left={true} right={true} title="HBN" />
        <TableHeader left={false} right={false} title="Başarı Durumu" />
      </Box>
      {subjects.map((subject, index) => (
        <TableRow key={index} data={subject} />
      ))}
    </Box>
  );
};

export default SubjectsTable;
