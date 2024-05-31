import Ders from "../Ders";
import { Data } from "data";

import { Box, Typography } from "@mui/material";
import { useTheme } from "@mui/material/styles";

import SelectSubjectsTableHeader from "components/SelectSubjectsTableHeader";

const SecmeliDersler = ({ courses }) => {
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
          height: "auto",
          maxWidth: "95%",
          borderRadius: "10px",
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
          Seçmeli dersler tabında seçmeli dersleriniz yer almaktadır. Mezuniyet
          için zorunlu değildir fakat mezuniyet için gerekli krediyi
          tamamlayabilmek için seçmeli ders almalısınız.
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
            <Ders state="success" key={index} data={item} />
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

export default SecmeliDersler;
