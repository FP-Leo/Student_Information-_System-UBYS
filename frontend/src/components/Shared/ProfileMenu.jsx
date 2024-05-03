import { Box, Button } from "@mui/material";
import { ThemeProvider, createTheme } from "@mui/material/styles";
import React from "react";
import UserCardSm from "../MainScreen-UserInfo/UserCardSm";
import ExitToAppIcon from "@mui/icons-material/ExitToApp";
import ContactSupportIcon from "@mui/icons-material/ContactSupport";
import ManageAccountsIcon from "@mui/icons-material/ManageAccounts";

export default function ProfileMenu() {
  return (
    <Box
      sx={{
        position: "absolute",
        top: "100px",
        right: "50px",
        width: "300px",
        height: "250px",
        boxShadow: "5px 5px 10px #919EAB",
      }}
      flexDirection={"column"}
      display={"flex"}
      alignItems={"flex-start"}
      justifyContent={"space-evenly"}
    >
      <ThemeProvider theme={themeForButton}>

        <Box display={"flex"}>
          <UserCardSm
            shadowAvailable={false}
            ppSize={"sm"}
            backgroundAvailable={false}
            isMenuCard={true}
            role={"Student"}
          />
          <Button startIcon={<ExitToAppIcon />} color="grey"></Button>
        </Box>

        {/* I'll refactor and make them One component */}
        <Button startIcon={<ManageAccountsIcon />} color="grey" sx={{ ml: 2 ,pr:20,py:2}}>
          Settings
        </Button>
        <Button startIcon={<ContactSupportIcon />} color="grey" sx={{ ml: 2,pr:20 ,py:2}}>
          Support
        </Button>
        <Button startIcon={<ExitToAppIcon />} color="grey" sx={{ ml: 2 ,pr:20,py:2}}>
          Logout
        </Button>
      </ThemeProvider>
    </Box>
  );
}

const themeForButton = createTheme({
  palette: {
    grey: {
      main: "#3E3E3E",
    },
  },
});
