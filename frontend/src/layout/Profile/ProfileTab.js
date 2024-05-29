import { useState } from "react";

import PropTypes from "prop-types";

import { useNavigate } from "react-router-dom";

import { useTheme } from "@mui/material/styles";
import {
  Typography,
  List,
  ListItemButton,
  ListItemIcon,
  ListItemText,
} from "@mui/material";

import { EditOutlined, LogoutOutlined } from "@ant-design/icons";

import { removeSpacesAndLowerCase } from "utils/helper-functions";

// ==============================|| HEADER PROFILE - PROFILE TAB ||============================== //

const ProfileTab = ({ handleLogout }) => {
  const theme = useTheme();
  const navigate = useNavigate();
  const [selectedIndex, setSelectedIndex] = useState();

  const handleListItemClick = (event, index) => {
    setSelectedIndex(index);
    if (removeSpacesAndLowerCase(event.target.innerText) === "editprofile") {
      navigate("edit-profile");
    } else {
      console.log("Logout");
    }
  };

  return (
    <List
      component="nav"
      sx={{
        marginTop: 1,
        p: 0,
        "& .MuiListItemIcon-root": {
          minWidth: 32,
          color: theme.palette.grey[500],
        },
      }}
    >
      <ListItemButton
        selected={selectedIndex === 0}
        onClick={(event) => handleListItemClick(event, 0)}
      >
        <ListItemIcon>
          <EditOutlined />
        </ListItemIcon>
        <ListItemText
          primary={<Typography variant="subtitle2">Edit Profile</Typography>}
        />
      </ListItemButton>

      <ListItemButton selected={selectedIndex === 1} onClick={handleLogout}>
        <ListItemIcon>
          <LogoutOutlined />
        </ListItemIcon>
        <ListItemText
          primary={<Typography variant="subtitle2">Log Out</Typography>}
        />
      </ListItemButton>
    </List>
  );
};

ProfileTab.propTypes = {
  handleLogout: PropTypes.func,
};

export default ProfileTab;
