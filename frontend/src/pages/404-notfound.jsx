import { Typography, Box, Button } from "@mui/material";
import { Link } from "react-router-dom";
import NotFoundIcon from "../assets/not-found-icon";

const NotFoundPage = () => {
  return (
    <Box
      sx={{
        height: "100vh",
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "space-around",
      }}
    >
      <Box
        sx={{
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
          marginTop: "50px",
        }}
      >
        <Typography variant="h4" color="text.primary">
          Sorry, Page Not Found!
        </Typography>
        <Typography variant="body1" color="text.secondary">
          {" "}
          The requested URL was not found on this server.
        </Typography>
      </Box>

      <NotFoundIcon />

      <Button variant="contained" color="primary" to="/home" component={Link}>
        Back Home
      </Button>
    </Box>
  );
};

export default NotFoundPage;
