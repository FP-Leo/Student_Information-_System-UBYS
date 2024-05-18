import { Box, Typography, Button } from "@mui/material";
import SendIcon from "assets/send-icon";
import laught from "assets/laugh.mp3";

const InfoHeader = () => {
  const audio = new Audio(laught);
  const playAudio = () => {
    audio.play();
  };
  return (
    <Box
      sx={{
        paddingX: "50px",
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
          <Typography variant="subtitle1">Danışman: </Typography>
          <Typography
            style={{
              marginLeft: "10px",
            }}
          >
            Doç. Dr. Erlindi İsaj
          </Typography>
        </Box>
        <Typography
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
          <Typography variant="subtitle1">Sınıf: </Typography>
          <Typography
            style={{
              marginLeft: "10px",
            }}
            color={"text.disabled"}
          >
            2
          </Typography>
        </Box>
        <Typography
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
          <Typography variant="subtitle1">Ders Dönemi: </Typography>
          <Typography
            style={{
              marginLeft: "10px",
            }}
          >
            3
          </Typography>
        </Box>
        <Typography
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
          <Typography variant="subtitle1">Durum: </Typography>
          <Typography
            style={{
              marginLeft: "10px",
            }}
            variant="cardHeader"
          >
            Ders Seçimi
          </Typography>
        </Box>
      </Box>
      <Button
        style={{
          color: "white",
          borderRadius: "10px",
          height: "40px",
        }}
        variant="contained"
        color="success"
        onClick={playAudio}
      >
        Danışmanına Gönder &nbsp;
        <SendIcon />
      </Button>
    </Box>
  );
};

export default InfoHeader;
