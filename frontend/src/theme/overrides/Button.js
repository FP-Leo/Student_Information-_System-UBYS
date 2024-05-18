import { alpha } from "@mui/material/styles";

// ----------------------------------------------------------------------

export default function Button(theme) {
  return {
    MuiButton: {
      styleOverrides: {
        root: {
          "&:hover": {
            boxShadow: "none",
          },
        },

        text: {
          color: theme.palette.text.primary,
          "&:hover": {
            backgroundColor: theme.palette.action.hover,
          },
        },

        sizeLarge: {
          height: 48,
        },

        containedInherit: {
          color: theme.palette.grey[800],
          boxShadow: theme.customShadows.z8,
          "&:hover": {
            backgroundColor: theme.palette.grey[400],
          },
        },
        containedPrimary: {
          "&:hover": {
            boxShadow: theme.customShadows.primary,
          },
          color: theme.palette.common.white,
        },
        containedError: {
          "&:hover": {
            boxShadow: theme.customShadows.error,
          },
          color: theme.palette.common.white,
        },

        containedSecondary: {
          boxShadow: theme.customShadows.secondary,
        },

        outlinedInherit: {
          border: `1px solid ${alpha(theme.palette.grey[400], 0.32)}`,
          "&hover": {
            backgroundColor: "white",
          },
        },

        textInherit: {
          "&:hover": {
            backgroundColor: theme.palette.action.hover,
          },
        },

        textSecondary: {
          color: theme.palette.text.secondary,
          justifyContent: "flex-start",
          fontWeight: 400,
          "&:hover": {
            backgroundColor: theme.palette.action.hover,
          },
        },
      },
    },
  };
}
