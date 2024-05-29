import { useTheme } from "@mui/material/styles";
import { Avatar, Box, Typography } from "@mui/material";

const StudentInfo = () => {
  const theme = useTheme();

  return (
    <Box
      sx={{
        width: "70%",
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
        <Typography variant="caption">Students Information</Typography>
      </Box>
      <Box
        sx={{
          display: "grid",
          paddingY: 4,
          gridTemplateColumns: "1.3fr 1fr 1.5fr 0.7fr",
          alignItems: "center",
        }}
      >
        <Box
          sx={{
            display: "flex",
            alignItems: "center",
          }}
        >
          <Avatar
            sx={{
              margin: 3,
            }}
          />
          <Box sx={{ display: "flex", flexDirection: "column" }}>
            <Typography variant="caption">Ad Soyad:</Typography>
            <Typography variant="caption">Öğrenci No:</Typography>
            <Typography variant="caption">Kimlik No:</Typography>
          </Box>
        </Box>
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
          }}
        >
          <Typography variant="caption">Yıl:</Typography>
          <Typography variant="caption">Dönem:</Typography>
          <Typography variant="caption">Max AKTS:</Typography>
          <Typography variant="caption">Min AKTS:</Typography>
        </Box>
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
          }}
        >
          <Typography variant="caption">Kayıtlanacağı Sınıf:</Typography>
          <Typography variant="caption">
            Kayıtlanacağı Eğitim Dönemi:
          </Typography>
          <Typography variant="caption">Kayıtlanacağı Ders Dönemi:</Typography>
          <Typography variant="caption">Kayıt Aşaması:</Typography>
        </Box>
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
          }}
        >
          <Typography variant="caption">GNO:</Typography>
          <Typography variant="caption">YANO:</Typography>
        </Box>
      </Box>
    </Box>
  );
};

export default StudentInfo;
