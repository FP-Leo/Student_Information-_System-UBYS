const ListItemButton = (theme) => {
  return {
    MuiListItemButton: {
      styleOverrides: {
        custom: {
          "&:hover": {
            backgroundColor: theme.palette.primary.light,
            borderRight: `4px solid ${theme.palette.primary.main}`,
          },
        },
      },
    },
  };
};

export default ListItemButton;
