import { Box, Typography } from "@mui/material";

const InfoHeader = () => {
  return (
    <Box
      sx={{
        borderRadius: "10px 10px 0 0 ",
        paddingX: "10px",
        width: "100%",
        height: "50px",
        backgroundColor: "#E9E9EA",
        display: "flex",
        justifyContent: "space-between",
        alignItems: "center",
      }}
    >
      <Box
        sx={{
          display: "flex",
        }}
      >
        <Box
          sx={{
            display: "flex",
          }}
        >
          <Typography variant="caption">Öğrenci: </Typography>
          <Typography
            style={{
              marginLeft: "10px",
            }}
            variant="caption2"
          >
            200401114 Erlindi İsaj
          </Typography>
        </Box>
        <Typography
          variant="caption2"
          style={{
            margin: "0 15px",
          }}
          color={"text.disabled"}
        >
          /
        </Typography>
        <Box
          sx={{
            display: "flex",
          }}
        >
          <Typography variant="caption">Sınıf: </Typography>
          <Typography
            variant="caption2"
            style={{
              marginLeft: "10px",
            }}
          >
            2
          </Typography>
        </Box>
        <Typography
          style={{
            margin: "0 15px",
          }}
          color={"text.disabled"}
          variant="caption2"
        >
          /
        </Typography>
        <Box
          sx={{
            display: "flex",
          }}
        >
          <Typography variant="caption">Ders Dönemi: </Typography>
          <Typography
            variant="caption2"
            style={{
              marginLeft: "10px",
            }}
          >
            3
          </Typography>
        </Box>
        <Typography
          variant="caption2"
          style={{
            margin: "0 15px",
          }}
          color={"text.disabled"}
        >
          /
        </Typography>
        <Box
          sx={{
            display: "flex",
          }}
        >
          <Typography variant="caption">Max AKTS: </Typography>
          <Typography
            style={{
              marginLeft: "10px",
            }}
            variant="caption2"
          >
            30.00
          </Typography>
        </Box>
        <Typography
          variant="caption2"
          style={{
            margin: "0 15px",
          }}
          color={"text.disabled"}
        >
          /
        </Typography>
        <Box
          sx={{
            display: "flex",
          }}
        >
          <Typography variant="caption">Seçili AKTS: </Typography>
          <Typography
            style={{
              marginLeft: "10px",
            }}
            variant="caption2"
          >
            20.00
          </Typography>
        </Box>
      </Box>
      <Box
        sx={{
          display: "flex",
        }}
      >
        <Typography variant="caption">Durum: </Typography>
        <Typography
          style={{
            marginLeft: "10px",
          }}
          variant="caption2"
        >
          Danışman Onayında
        </Typography>
      </Box>
    </Box>
  );
};

export default InfoHeader;
