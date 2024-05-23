import { Box, Button } from "@mui/material";
import InfoHeader from "./InfoHeader";
import InfoCard from "../../components/InfoCard";
import { useTheme } from "@mui/material/styles";
import SelectSubjects from "./SelectSubjects";
import SelectedSubjects from "./SelectedSubjects";
import CheckRoundedIcon from "@mui/icons-material/CheckRounded";

const SubjectsRegistration = () => {
  const theme = useTheme();
  return (
    <Box
      sx={{
        width: "100%",
        display: "flex",
        alignItems: "flex-start",
        justifyContent: "center",
      }}
    >
      <Box
        sx={{
          borderRadius: "10px",

          border: `1px solid ${theme.palette.divider}`,
          backgroundColor: theme.palette.common.white,
          paddingBottom: 2,
          margin: 2,
          display: "flex",
          flexDirection: "column",
          width: "70%",
          minWidth: "1000px",
        }}
      >
        <InfoHeader />
        <Box
          sx={{
            backgroundColor: theme.palette.common.white,
            display: "flex",
            justifyContent: "space-around",
            alignItems: "center",
            paddingTop: 2,
          }}
        >
          <InfoCard content="(*) ile işaretli dersler Kredi veya Ders Saati toplamlarına katılmaz." />
          <InfoCard content="(**) ile işaretli derslerin Uzaktan Eğitim olarak verilen şubesi vardır. Kayıt yaptırmak istediğiniz şubeyi seçebilirsiniz. Uzaktan Eğitim, Öğretim Elemanı ve öğrencinin aynı ortamda bulunma zorunluluğu olmaksızın elektronik ortamda internet üzerinden verilen eğitim biçimidir." />
          <InfoCard content="Öğrenci Seçtiği Dersleri Onayınıza Göndermiştir. Onaylayabilir veya Ders Seçimi Yapıp Kaydedip Öğrenci Onayına Gönderebilirsiniz. " />
        </Box>
        <SelectSubjects />
      </Box>
      <Box
        sx={{
          display: "flex",
          flexDirection: "column",
          alignItems: "flex-end",
        }}
      >
        <Button
          style={{
            color: "white",
            borderRadius: "10px",
            height: "40px",
            marginRight: "15px",
            marginTop: "15px",
          }}
          variant="contained"
          color="success"
        >
          Kayıtlanmayı Tamamla &nbsp;
          <CheckRoundedIcon />
        </Button>
        <SelectedSubjects />
      </Box>
    </Box>
  );
};

export default SubjectsRegistration;
