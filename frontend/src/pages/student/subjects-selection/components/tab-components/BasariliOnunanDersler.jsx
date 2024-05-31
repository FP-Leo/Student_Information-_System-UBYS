import Ders from "../Ders";
import { Data } from "data";

import { Box, Typography } from "@mui/material";
import { useTheme } from "@mui/material/styles";

import SelectSubjectsTableHeader from "components/SelectSubjectsTableHeader";

const BasariliOnunanDersler = ({ courses }) => {
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
          justifyContent: "center",
          display: "flex",
          backgroundColor: theme.palette.info.light,
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
          Başarılı olunan derslerim tabında daha önce aldığınız ve başarılı
          olduğunuz dersler yer almaktadır. Not yükseltme amacı ile bu
          derslerden seçebilirsiniz.
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
        {courses ? (
          courses.map((item, index) => (
            <Ders key={index} state="success" data={item} />
          ))
        ) : (
          <Typography
            padding={3}
            color="error"
            textAlign="center"
            variant="subtitle2"
          >
            Ders bulunamadı.
          </Typography>
        )}
      </Box>
    </Box>
  );
};

export default BasariliOnunanDersler;
