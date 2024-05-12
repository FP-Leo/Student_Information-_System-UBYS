import { Box } from "@mui/material";

const CustomTabPanel = (props) => {
  const { children, value, index, ...other } = props;

  return (
    <Box
      width="100%"
      role="tabpanel"
      hidden={value !== index}
      id={`simple-tabpanel-${index}`}
      aria-labelledby={`simple-tab-${index}`}
      {...other}
    >
      {value === index && <Box>{children}</Box>}
    </Box>
  );
};

export default CustomTabPanel;
