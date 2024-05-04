import { Avatar, Box, Typography } from "@mui/material";
import Image from "../../assets/photo.svg";
import React from "react";

export default function UserCardSm({
  shadowAvailable,
  ppSize,
  cardSize,
  backgroundAvailable,
  isMenuCard,
  role,
}) {
  // Means User Card Small ! we'll use it for main screen primarly.
  const shadowAttribute = shadowAvailable ? "5px 5px lightgrey" : " "; // if you want to hide box shadow , send shadowAvailable as false
  const backgroundAttribute = backgroundAvailable ? "#EFEFEF" : "transparent";

  const ppSizeMap = {
    sm: "50px",
    md: "125px",
  };
  const cardSizeMap = {
    sm: "225px",
    md: "500px",
  };
  const ppWidthHeight = ppSizeMap[ppSize] || ppSizeMap["sm"]; // sm is default
  const cardWidth = cardSizeMap[cardSize] || cardSizeMap["sm"]; // Also sm is default
  return (
    <Box
      sx={{
        display: "flex",
        alignItems: !isMenuCard ? "center" : "flex-start", // align to left if its for menu
        backgroundColor: backgroundAttribute,
        width: cardWidth,
        color: "black",
        py: 2,
        px: 2,
        boxShadow: shadowAttribute,
        flexDirection: "column",
      }}
    >
      {isMenuCard ? (
        <>
          <Box display={"flex"}>
            <Avatar
              alt="Remy Sharp"
              src={Image}
              sx={{ width: ppWidthHeight, height: ppWidthHeight ,mx:1 }}
              

            />
            <Box
              display={"flex"}
              flexDirection={"column"}

            >
              <Typography sx={{ mt: 1, textDecoration: "none" }}>
                {" "}
                Name - Surname
              </Typography>
              <Typography sx={{ textDecoration: "none", fontSize: "10px"}}>
                {role}
              </Typography>
            </Box>
          </Box>
        </>
      ) : (
        <>
          <Avatar
            alt="Remy Sharp"
            src={Image}
            sx={{ width: ppWidthHeight, height: ppWidthHeight }}
          />
          <Typography sx={{ my: 1, textDecoration: "none" }}>
            {" "}
            Name - Surname
          </Typography>
          <Typography sx={{ textDecoration: "none", fontSize: "14px" }}>
            Student Number
          </Typography>
        </>
      )}
    </Box>
  );
}
