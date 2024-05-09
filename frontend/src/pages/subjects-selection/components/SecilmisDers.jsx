import { Box, Typography } from "@mui/material";

const SecilmisDers = ({ state }) => {
  return (
    <Box
      sx={{
        backgroundColor: state === "success" ? "success.light" : "error.light",
        height: "50px",
        width: "100%",
        display: "grid",
        gridTemplateColumns: "1fr 1.75fr 4fr 1fr",
        gridTemplateRows: "1fr",
        alignItems: "center",
        paddingLeft: 2,
      }}
    >
      {" "}
      <Typography variant="body2">1</Typography>
      <Typography color="info.main" variant="body2">
        BML2002
      </Typography>
      <Typography variant="body2">Programlama Dilleri Kavramları</Typography>
      <Typography variant="body2">5</Typography>
    </Box>
  );
};

export default SecilmisDers;
