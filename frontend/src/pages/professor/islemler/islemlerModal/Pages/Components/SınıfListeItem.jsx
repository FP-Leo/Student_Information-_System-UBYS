import { Avatar, Box, Typography } from '@mui/material'
import Avatar1 from 'assets/avatar1.png'
import React from 'react'

export default function SınıfListeItem() {
  return (
   <Box
   sx={{
    display:"grid",
    border:"1px solid #B3B3B3",
    gridTemplateColumns:"75px 100px 100px 75px 150px 150px 200px 150px"
   }}
   >
    <Avatar src={Avatar1}></Avatar>
    <Box display={"flex"}>
        <Typography fontWeight={600} pr={1}>Eren Nokta</Typography>
    </Box>
    <Box display={"flex"}>
        <Typography fontWeight={600} pr={1}>200401012</Typography>
    </Box>
    <Box display={"flex"}>
        <Typography fontWeight={600} pr={1}>4.Sınıf</Typography>
    </Box>
    <Box display={"flex"}>
        <Typography fontWeight={600} pr={1}>Vize Notu : 60</Typography>
    </Box>
    <Box display={"flex"}>
        <Typography fontWeight={600} pr={1}>Final Notu : 80</Typography>
    </Box>
    <Box display={"flex"}>
        <Typography fontWeight={600} pr={1}>Büt Durumu : Kaldı</Typography>
    </Box>
    <Box display={"flex"}>
        <Typography fontWeight={600} pr={1}>Büt Notu : -</Typography>
    </Box>
</Box>
  )
}
