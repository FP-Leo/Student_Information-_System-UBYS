import { Box, styled, alpha } from "@mui/material";

export const AuthBackground = styled(Box)(({ theme }) => ({
  height: "650px",
  alignItems: "center",
  display: "flex",
  width: "70%",
  borderRadius: "12px",
  backgroundColor: alpha(theme.palette.background.default, 0.5),
}));
