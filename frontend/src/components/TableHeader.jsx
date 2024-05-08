import { Box, Typography } from "@mui/material";

const TableHeader = ({ title }) => {
  return (
    <Box
      sx={{
        border: "1px solid green",
        backgroundColor: "background.headerFill",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        paddingY: "15px",
        paddingX: "25px",
      }}
    >
      <Typography variant="h6">{title}</Typography>
    </Box>
  );
};

export default TableHeader;
