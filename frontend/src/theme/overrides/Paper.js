import { alpha } from "@mui/material/styles";

const Paper = (theme) => {
  return {
    MuiPaper: {
      styleOverrides: {
        root: {
          boxShadow: theme.customShadows.z4,
          backgroundColor: alpha(theme.palette.background.default, 0.9),
          backdropFilter: "blur(20px)",
        },
      },
    },
  };
};

export default Paper;
