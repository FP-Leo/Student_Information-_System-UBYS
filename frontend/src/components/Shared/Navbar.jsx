import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import { Avatar, Typography } from '@mui/material';
import PfImage from "../../assets/photo.svg"
import ProfileMenu from './ProfileMenu';

export default function Navbar() {

  const [isMenuOpened,setIsMenuOpened] = React.useState(false)

  const handleMenu = ()=> {
    console.log(isMenuOpened);
    setIsMenuOpened(!isMenuOpened) 
  }
  return (
      <Box sx={{ flexGrow: 1 }} dis>
      <AppBar sx={{position:"relative"}}  style={{backgroundColor:"transparent",boxShadow:"none"}}>
        <Toolbar sx={{display:"flex",justifyContent:"space-between"}}>
          <IconButton
            size="large"
            edge="start"
            color="black"
            aria-label="menu"
            sx={{ mr: 2 }}
          >
            <MenuIcon />
          </IconButton>
          <Box 
          onClick={handleMenu}
          sx={{ cursor:"pointer",
          mr: 4 ,display:"flex" ,
          alignItems:"center",backgroundColor:"#EFEFEF",
          color:"black",px:2,py:1,boxShadow:"5px 5px lightgrey"}}>

          <Typography sx={{mr:2 , textDecoration:"none"}}> Name - Surname</Typography>

          <Avatar alt="Remy Sharp" src={PfImage}/>
          
          </Box>
        </Toolbar>
      </AppBar>
      {isMenuOpened && <ProfileMenu shadowAvailable={false} />}
    </Box>
  );
}