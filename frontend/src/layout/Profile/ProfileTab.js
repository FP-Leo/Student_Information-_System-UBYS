import PropTypes from "prop-types";
import { useState } from "react";
import { useNavigate } from "react-router-dom";

import { removeSpacesAndLowerCase } from "utils/helper-functions";
// material-ui
import { useTheme } from "@mui/material/styles";
import {
  Typography,
  List,
  ListItemButton,
  ListItemIcon,
  ListItemText,
} from "@mui/material";

// assets
import { EditOutlined, LogoutOutlined, UserOutlined } from "@ant-design/icons";

// ==============================|| HEADER PROFILE - PROFILE TAB ||============================== //

const ProfileTab = ({ handleLogout }) => {
  const theme = useTheme();
  const navigate = useNavigate();

  const [selectedIndex, setSelectedIndex] = useState();
  const handleListItemClick = (event, index) => {
    setSelectedIndex(index);
    if (removeSpacesAndLowerCase(event.target.innerText) === "editprofile") {
      navigate("edit-profile");
    } else if (
      removeSpacesAndLowerCase(event.target.innerText) === "viewprofile"
    ) {
      // navigate("/view-profile");
    } else {
      console.log("Logout");
    }
  };

  return (
    <List
      component="nav"
      sx={{
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
      <ListItemButton
        selected={selectedIndex === 1}
        onClick={(event) => handleListItemClick(event, 1)}
      >
        <ListItemIcon>
          <UserOutlined />
        </ListItemIcon>
        <ListItemText
          primary={<Typography variant="subtitle2">View Profile</Typography>}
        />
      </ListItemButton>
      <ListItemButton selected={selectedIndex === 2} onClick={handleLogout}>
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
