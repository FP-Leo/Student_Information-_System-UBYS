import { Box, Grid, IconButton, Typography } from "@mui/material";
import ClassIcon from "@mui/icons-material/Class";
import React from "react";
import AssignmentIcon from "@mui/icons-material/Assignment";
import CalendarMonthIcon from "@mui/icons-material/CalendarMonth";
import NoteAddIcon from "@mui/icons-material/NoteAdd";
export default function CategoryItem({ title }) {
  // we need title for each item so I used props and receive the "title"

  const iconMap = {
    Derslerim: ClassIcon,
    Takvim: CalendarMonthIcon,
    "Ders Seçimi": NoteAddIcon,
    "Belge Talebi": AssignmentIcon,
  };

  const IconComponent = iconMap[title];

  return (
    <Grid item xs={3}>
      <Box
        width={275}
        height={300}
        sx={{ backgroundColor: "#EFEFEF", cursor: "pointer" }}
        display={"flex"}
        alignItems={"center"}
        justifyContent={"space-around"}
        flexDirection={"column"}
        border={"2px solid lightgrey"}
        borderRadius={"15px"}
        boxShadow={"5px 5px #EFEFEF"}
      >
        <IconButton
          size="large"
          edge="start"
          color="black"
          sx={{
            px: 5,
            py: 5,
            mx: 2,
            cursor: "default",
            "&:hover": {
              // Apply styles on hover (but override them)
              backgroundColor: "transparent",
              cursor: "pointer", // Set the same background color on hover
            },
          }}
        >
          <IconComponent sx={{ fontSize: "5rem", textDecoration: "none" }} />
        </IconButton>
        <Typography color={"black"}>{title}</Typography>
      </Box>
    </Grid>
  );
}
