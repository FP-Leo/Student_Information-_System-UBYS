import { useState } from "react";

import { useNavigate } from "react-router-dom";

import Profile from "./Profile";

import Logo from "assets/logo";
import HomeIcon from "assets/home-icon";

import Box from "@mui/material/Box";
import List from "@mui/material/List";
import Toolbar from "@mui/material/Toolbar";
import ListItem from "@mui/material/ListItem";
import MenuIcon from "@mui/icons-material/Menu";
import { useTheme } from "@mui/material/styles";
import IconButton from "@mui/material/IconButton";
import { AppBar, Typography } from "@mui/material";
import CssBaseline from "@mui/material/CssBaseline";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemButton from "@mui/material/ListItemButton";
import SwipeableDrawer from "@mui/material/SwipeableDrawer";

export default function Navbar() {
  const theme = useTheme();

  const navigate = useNavigate();

  const [isOpen, setIsOpen] = useState(false);

  const toggleDrawer = (open) => (event) => {
    event.preventDefault();
    if (
      event &&
      event.type === "keydown" &&
      (event.key === "Tab" || event.key === "Shift")
    ) {
      return;
    }
    setIsOpen(open);
  };

  const list = () => (
    <Box
      sx={{ width: 250 }}
      role="presentation"
      onClick={toggleDrawer(false)}
      onKeyDown={toggleDrawer(false)}
    >
      <Box
        sx={{
          paddingY: 3,
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          borderBottom: `1px solid ${theme.palette.divider}`,
        }}
      >
        <Logo width="50px" />
        <Typography
          sx={{
            marginLeft: 2,
          }}
          variant="subtitle1"
        >
          ÇOMÜ
        </Typography>
      </Box>
      <Box
        sx={{
          display: "flex",
          flexDirection: "column",
          marginY: 3,
        }}
      >
        <List>
          <ListItem key={"Home"} disablePadding>
            <ListItemButton
              sx={{
                height: "50px",
              }}
              onClick={() => navigate("/home")}
            >
              <ListItemIcon>
                <HomeIcon />
              </ListItemIcon>
              <Typography
                color={theme.palette.text.primary}
                variant="subtitle2"
              >
                Anasayfa
              </Typography>
            </ListItemButton>
          </ListItem>
        </List>
      </Box>
    </Box>
  );

  return (
    <Box sx={{ display: "flex" }}>
      <CssBaseline />
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
            onClick={toggleDrawer(true)}
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
      <SwipeableDrawer
        open={isOpen}
        onClose={toggleDrawer(false)}
        onOpen={toggleDrawer(true)}
      >
        {list()}
      </SwipeableDrawer>
    </Box>
  );
}
