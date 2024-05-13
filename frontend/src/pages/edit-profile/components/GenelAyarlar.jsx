import { Box, Typography, Avatar, Button } from "@mui/material";
import avatar2 from "assets/avatar2.png";
import InputAdornment from "@mui/material/InputAdornment";
import LocalPhoneIcon from "@mui/icons-material/LocalPhone";
import TextField from "@mui/material/TextField";

const GenelAyarlar = () => {
  return (
    <Box
      sx={{
        marginTop: "40px",
      }}
    >
      <Box sx={{ display: "flex", alignItems: "center" }}>
        <Avatar
          src={avatar2}
          sx={{ width: "80px", height: "80px", marginRight: "20px" }}
        />
        <Button sx={{ height: "40px" }} variant="custom">
          CHANGE
        </Button>
      </Box>

      <form action="">
        <Box
          sx={{
            marginTop: "40px",
            display: "flex",
            flexDirection: "column",
          }}
        >
          <TextField
            sx={{
              width: "80%",
              marginY: "15px",
            }}
            InputProps={{
              sx: {
                borderRadius: "10px",
                marginRight: "20px",
              },
            }}
            id="outlined-search"
            label="Kurumsal e-posta"
            type="email"
            value="200401114@ogr.comu.edu.tr"
            disabled
          />{" "}
          <TextField
            sx={{
              width: "80%",
              marginY: "15px",
            }}
            InputProps={{
              sx: {
                borderRadius: "10px",
                marginRight: "20px",
              },
            }}
            id="outlined-search"
            label="Kişisel e-posta"
            type="email"
          />{" "}
          <TextField
            sx={{
              width: "80%",
              marginY: "15px",
            }}
            InputProps={{
              startAdornment: (
                <InputAdornment position="start">
                  <LocalPhoneIcon />
                </InputAdornment>
              ),
              sx: {
                borderRadius: "10px",
                marginRight: "20px",
              },
            }}
            id="outlined-search"
            label="Cep Telefonu"
            type="text"
          />{" "}
          <TextField
            sx={{
              width: "80%",
              marginY: "15px",
            }}
            InputProps={{
              sx: {
                borderRadius: "10px",
                marginRight: "20px",
              },
            }}
            id="outlined-search"
            label="Ikamet Adresi"
            type="text"
          />
          <Button
            sx={{
              width: "20%",
              margin: "20px 0",
              borderRadius: "10px",
            }}
            color="primary"
            size="large"
            type="submit"
            variant="contained"
          >
            Save Changes
          </Button>
        </Box>
      </form>
    </Box>
  );
};

export default GenelAyarlar;
