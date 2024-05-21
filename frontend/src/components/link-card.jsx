import { Box, Typography } from "@mui/material";
import { Link, useNavigate } from "react-router-dom";
import { useTheme } from "@mui/material/styles";
import { removeSpacesAndLowerCase } from "utils/helper-functions";

import { motion } from "framer-motion";

const LinkCard = ({ children, title }) => {
  const theme = useTheme();

  return (
    <Box
      mx={2}
      width="200px"
      component={Link}
      to={
        title === "Ders Seçimi"
          ? "ders-secimi"
          : removeSpacesAndLowerCase(title)
      }
      variant="custom"
      sx={{
        backgroundColor: "background.neutral",
        boxShadow: theme.customShadows.card,
        borderRadius: "8px",
        textDecoration: "none",
        transition: "ease .25s",
        "&:hover": {
          backgroundColor: theme.palette.action.hover,
          "& h6": {
            color: theme.palette.primary.main,
          },
        },
      }}
    >
      <Box
        sx={{
          display: "flex",
          alignItems: "center",
          justifyContent: "center",
          width: "100%",
          height: "150px",
        }}
        component={motion.div}
        whileHover={{ scale: 1.1 }}
      >
        {children}
      </Box>
      <Typography
        textAlign="center"
        variant="subtitle2"
        color="text.primary"
        padding={2}
        backgroundColor="background.neutral"
        sx={{
          borderRadius: "0 0 8px 8px",
        }}
      >
        {title}
      </Typography>
    </Box>
  );
};

export default LinkCard;
