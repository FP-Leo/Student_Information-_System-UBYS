import { useState } from "react";
import { useNavigate } from "react-router-dom";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import IconButton from "@mui/material/IconButton";
import MenuIcon from "@mui/icons-material/Menu";
import CssBaseline from "@mui/material/CssBaseline";
import SwipeableDrawer from "@mui/material/SwipeableDrawer";
import { AppBar } from "@mui/material";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";

import Profile from "./Profile";
import HomeIcon from "assets/home-icon";

export default function Navbar() {
  const navigate = useNavigate();
  const [open, setOpen] = useState(false);

  const toggleDrawer = (open) => (event) => {
    if (
      event &&
      event.type === "keydown" &&
      (event.key === "Tab" || event.key === "Shift")
    ) {
      return;
    }

    setOpen(open);
  };

  const list = () => (
    <Box
      sx={{ width: 250, marginTop: "64px" }}
      role="presentation"
      onClick={toggleDrawer(false)}
      onKeyDown={toggleDrawer(false)}
    >
      <List>
        <ListItem key={"Home"} disablePadding>
          <ListItemButton onClick={() => navigate("/home")}>
            <ListItemIcon>
              <HomeIcon />
            </ListItemIcon>
            <ListItemText primary={"Home"} />
          </ListItemButton>
        </ListItem>
      </List>
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
        open={open}
        onClose={toggleDrawer(false)}
        onOpen={toggleDrawer(true)}
      >
        {list()}
      </SwipeableDrawer>
    </Box>
  );
}
