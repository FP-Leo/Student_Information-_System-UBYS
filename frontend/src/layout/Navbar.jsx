import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import IconButton from "@mui/material/IconButton";
import MenuIcon from "@mui/icons-material/Menu";

import Profile from "./Profile";

export default function Navbar() {
  return (
    <Box sx={{ flexGrow: 1 }} dis>
      <AppBar
        sx={{ position: "relative" }}
        style={{
          backgroundColor: "transparent",
          boxShadow: "none",
          borderBottom: "1px solid #E0E0E0",
        }}
      >
        <Toolbar
          sx={{
            mx: 3,
            display: "flex",
            justifyContent: "space-between",
          }}
        >
          <IconButton
            size="large"
            edge="start"
            color="black"
            aria-label="menu"
            sx={{ mr: 2 }}
          >
            <MenuIcon />
          </IconButton>
          <Profile />
        </Toolbar>
      </AppBar>
    </Box>
  );
}
