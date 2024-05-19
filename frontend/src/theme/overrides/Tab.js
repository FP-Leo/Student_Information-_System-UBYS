// ==============================|| OVERRIDES - TAB ||============================== //

export default function Tab(theme) {
  return {
    MuiTab: {
      styleOverrides: {
        root: {
          minHeight: 46,
          color: theme.palette.text.primary,
          transition: "0.2s",
          "&:hover": {
            backgroundColor: theme.palette.primary.lighter,
          },
          '&[data-variant="settings"]': {
            display: "flex",
            marginTop: "20px",
            justifyContent: "flex-start",
            "& > svg": {
              marginRight: "20px",
            },
          },
        },
      },
    },
  };
}
