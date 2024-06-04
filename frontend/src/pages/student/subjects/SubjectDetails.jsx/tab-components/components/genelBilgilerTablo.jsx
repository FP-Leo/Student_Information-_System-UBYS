import { Box, Typography, Avatar } from "@mui/material";
import { useTheme } from "@mui/material/styles";
import moment from "moment";
const GenelBilgilerTablo = ({ data }) => {
  const theme = useTheme();
  console.log(data);
  const { LecturerName, state, grade, examResultDtos } = data;

  return (
    <Box
      sx={{
        backgroundColor: theme.palette.common.white,
        boxShadow: theme.customShadows.z4,
        borderRadius: 1,
        display: "flex",
        flexDirection: "column",
        marginBottom: 3,
      }}
    >
      <Box
        sx={{
          paddingY: 2,
          paddingX: 3,
          width: "100%",
          display: "flex",
          justifyContent: "space-between",
        }}
      >
        <Typography variant="subtitle2">{`Ders Adı: Math`}</Typography>
        <Typography variant="subtitle2">{`Durum: ${
          state
            ? state === "Passed"
              ? "Başarılı"
              : "Başarısız"
            : "Durumu Netleşmemiş"
        }`}</Typography>
      </Box>
      <Box
        sx={{
          display: "grid",
          alignItems: "center",
          height: "40px",
          gridTemplateColumns: "1fr 1fr 1fr 1fr ",
          backgroundColor: theme.palette.grey[200],
          borderTop: `1px solid ${theme.palette.divider}`,
          borderBottom: `1px solid ${theme.palette.divider}`,
        }}
      >
        <Typography textAlign="center" variant="caption">
          Sınav Tipi
        </Typography>
        <Typography textAlign="center" variant="caption">
          Sınav Adı
        </Typography>
        <Typography textAlign="center" variant="caption">
          İlan Tarihi
        </Typography>
        <Typography textAlign="center" variant="caption">
          Sınav Notu
        </Typography>
      </Box>
      <Box
        sx={{
          width: "100%",
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <Box
          sx={{
            width: "100%",
            display: "flex",
            flexDirection: "column",
          }}
        >
          {examResultDtos.map((exam, index) => (
            <Box
              key={index}
              sx={{
                display: "grid",
                alignItems: "center",
                height: "40px",
                gridTemplateColumns: "1fr 1fr 1fr 1fr ",
                borderBottom: `1px solid ${theme.palette.divider}`,
              }}
            >
              <Typography textAlign="center" variant="caption">
                {exam.examName === "Mid Term"
                  ? "Ara Sınav"
                  : exam.examName === "Final"
                  ? "Final Sınavı"
                  : "Bütünleme Sınavı"}
              </Typography>
              <Typography textAlign="center" variant="caption">
                {exam.examName === "Mid Term"
                  ? "Vize"
                  : exam.examName === "Final"
                  ? "Final"
                  : "Bütünleme"}
              </Typography>
              <Typography textAlign="center" variant="caption">
                {moment(exam.announcmentDate).format("YYYY-MM-DD, h:mm")}
              </Typography>
              <Typography textAlign="center" variant="caption">
                {exam.points}
              </Typography>
            </Box>
          ))}
        </Box>
      </Box>
      <Box
        sx={{
          display: "flex",
          justifyContent: "space-between",
          alignItems: "center",
        }}
      >
        <Box
          sx={{
            display: "flex",
            alignItems: "center",
            marginLeft: 3,

            marginY: 3,
          }}
        >
          <Avatar src={""} />
          <Typography
            sx={{
              marginLeft: 3,
            }}
            variant="caption"
          >
            Dersi Veren: John Doe
          </Typography>
        </Box>
        <Box pr={3}>
          <Box
            sx={{
              display: "flex",
              alignItems: "center",
            }}
          >
            <Typography
              variant="caption"
              sx={{
                marginRight: 1,
              }}
            >
              Final Sonunda Oluşan Sınıf Ağırlıklı Not Ortalaması:{" "}
            </Typography>
            <Typography>-</Typography>
          </Box>
          <Box
            sx={{
              display: "flex",
              alignItems: "center",
            }}
          >
            <Typography
              variant="caption"
              sx={{
                marginRight: 1,
              }}
            >
              Bütünleme Sonunda Oluşan Sınıf Ağırlıklı Not Ortalaması:{" "}
            </Typography>
            <Typography>-</Typography>
          </Box>
        </Box>
      </Box>
    </Box>
  );
};
export default GenelBilgilerTablo;
