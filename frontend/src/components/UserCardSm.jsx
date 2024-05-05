import { Avatar, Box, Typography } from "@mui/material";
import { useTheme } from "@mui/material/styles";
import Image from "../assets/photo.svg";
import React from "react";

export default function UserCardSm({ ppSize, cardSize, isMenuCard, role }) {
  const theme = useTheme();
  const ppSizeMap = {
    sm: "30px",
    md: "70px",
  };
  const cardSizeMap = {
    sm: "225px",
    md: "350px",
  };
  const ppWidthHeight = ppSizeMap[ppSize] || ppSizeMap["sm"]; // sm is default
  const cardWidth = cardSizeMap[cardSize] || cardSizeMap["sm"]; // Also sm is default
  return (
    <Box
      sx={{
        boxShadow: theme.customShadows.card,
        display: "flex",
        borderRadius: "10px",
        alignItems: !isMenuCard ? "center" : "flex-start", // align to left if its for menu
        backgroundColor: "background.custom",
        width: cardWidth,
        color: "black",
        py: 3,
        px: 3,
        flexDirection: "column",
      }}
    >
      <Avatar
        alt="Remy Sharp"
        src={Image}
        sx={{ width: ppWidthHeight, height: ppWidthHeight }}
      />
      <Typography variant="subtitle1" sx={{ mt: 3, textDecoration: "none" }}>
        Student Name
      </Typography>
      <Typography
        variant="body2"
        color="text.secondary"
        sx={{ textDecoration: "none", fontSize: "14px" }}
      >
        200401114
      </Typography>
    </Box>
  );
}
