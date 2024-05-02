const Card = () => {
  return {
    MuiPaper: {
      styleOverrides: {
        root: {
          backdropFilter: 'blur(20px)'
        }
      }
    }
  };
};

export default Card;
