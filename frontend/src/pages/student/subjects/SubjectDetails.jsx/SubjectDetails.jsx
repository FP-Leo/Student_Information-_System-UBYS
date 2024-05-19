import { Box, Typography, Tabs, Tab } from "@mui/material";
import { useState } from "react";
import CustomTabPanel from "components/CustomTabPanel";
import { useTheme } from "@mui/material/styles";

import GenelBilgiler from "./tab-components/GenelBilgiler";
import HaftaIcerikleri from "./tab-components/HaftaIcerikleri";
import Odevler from "./tab-components/Odevler";

function a11yProps(index) {
  return {
    id: `vertical-tab-${index}`,
    "aria-controls": `vertical-tabpanel-${index}`,
  };
}

const SubjectDetails = () => {
  const [value, setValue] = useState(0);
  const theme = useTheme();

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };
  return (
    <Box
      sx={{
        marginX: 6,
        marginY: 6,
        display: "flex",
        flexDirection: "column",
        justifyContent: "center",
      }}
    >
      <Box>
        <Typography variant="subtitle1">Ders Kodu: 3003BML</Typography>
      </Box>
      <Box
        sx={{
          display: "grid",
          gridTemplateColumns: "1fr 3fr",
        }}
      >
        <Box>
          <Tabs
            sx={{
              marginTop: 0,
            }}
            orientation="vertical"
            variant="scrollable"
            value={value}
            onChange={handleChange}
            aria-label="vertical tabs"
            TabIndicatorProps={{
              style: {
                left: 0,
              },
            }}
          >
            <Tab
              data-variant="settings"
              iconPosition="start"
              label="Genel Bilgiler"
              {...a11yProps(0)}
            />
            <Tab
              data-variant="settings"
              iconPosition="start"
              label="Hafta İçerikleri"
              {...a11yProps(1)}
            />{" "}
            <Tab
              data-variant="settings"
              iconPosition="start"
              label="Ödevler"
              {...a11yProps(1)}
            />
          </Tabs>
        </Box>
        <Box
          sx={{
            backgroundColor: "background.neutral",
            boxShadow: theme.customShadows.z8,
            borderRadius: 1,
            marginTop: 3,
          }}
        >
          <CustomTabPanel value={value} index={0}>
            <GenelBilgiler />
          </CustomTabPanel>
          <CustomTabPanel value={value} index={1}>
            <HaftaIcerikleri />
          </CustomTabPanel>{" "}
          <CustomTabPanel value={value} index={2}>
            <Odevler />
          </CustomTabPanel>
        </Box>
      </Box>
    </Box>
  );
};

export default SubjectDetails;
