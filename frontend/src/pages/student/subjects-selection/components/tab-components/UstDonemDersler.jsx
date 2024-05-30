import Ders from "../Ders";
import { Data } from "data";

import { Box, Typography } from "@mui/material";
import { useTheme } from "@mui/material/styles";

import SelectSubjectsTableHeader from "components/SelectSubjectsTableHeader";

const UstDonemDersler = () => {
  const theme = useTheme();
  return (
    <Box
      sx={{
        width: "100%",
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
      }}
    >
      <Box
        sx={{
          marginY: "20px",
          minWidth: "95%",
          height: "auto",
          maxWidth: "95%",
          borderRadius: "10px",
          display: "flex",
          backgroundColor: theme.palette.info.light,
          justifyContent: "center",
          padding: "10px",
        }}
      >
        <Typography
          sx={{
            textAlign: "center",
          }}
          variant="caption2"
          color="info.darker"
        >
          Üst dönem dersleri tabında üst döneminize ait dersler bulunmaktadır.
        </Typography>
      </Box>
      <SelectSubjectsTableHeader />
      <Box
        sx={{
          backgroundColor: "background.neutral",
          width: "100%",
          display: "flex",
          flexDirection: "column",
        }}
      >
        {Data.ustDonem.map((item) => (
          <Ders data={item} />
        ))}
      </Box>
    </Box>
  );
};

export default UstDonemDersler;
