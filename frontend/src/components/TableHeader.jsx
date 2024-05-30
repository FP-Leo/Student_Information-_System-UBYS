/* eslint-disable no-restricted-globals */
import { Box, Typography } from "@mui/material";

const TableHeader = ({ title, right, left, onClick }) => {
  return (
    <Box
      sx={{
        borderTop: "1px solid #B3B3B3",
        borderRight: right ? "1px solid #B3B3B3" : "none",
        borderBottom: "1px solid #B3B3B3",
        borderLeft: left ? "1px solid #B3B3B3" : "none",
        display: "flex",
        height: "50px",
        alignItems: "center",
        justifyContent: "center",
        backgroundColor: "#EEEFF0",
        cursor: onClick !== null ? "pointer" : "default",
      }}
      onClick={onClick}
    >
      <Typography variant="subtitle1">{title}</Typography>
    </Box>
  );
};

export default TableHeader;
