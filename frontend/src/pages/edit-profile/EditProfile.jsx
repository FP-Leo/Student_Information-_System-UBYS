import { useState } from "react";

import { Box, Tabs, Tab } from "@mui/material";
import { useTheme } from "@mui/material/styles";

import PasswordIcon from "assets/password-icon";
import SettingsIcon from "assets/settings-icon";

import Password from "./components/Password";
import GenelAyarlar from "./components/GeneralSettings";
import CustomTabPanel from "components/CustomTabPanel";

function a11yProps(index) {
  return {
    id: `vertical-tab-${index}`,
    "aria-controls": `vertical-tabpanel-${index}`,
  };
}

const EditProfile = () => {
  const theme = useTheme();
  const [value, setValue] = useState(0);

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };
  return (
    <Box
      sx={{
        display: "flex",
        justifyContent: "center",
        width: "100%",
        height: "100%",
      }}
    >
      <Box
        sx={{
          backgroundColor: "background.neutral",
          borderRadius: 3,
          boxShadow: theme.customShadows.card,
          padding: "20px",
          height: "100%",
          width: "80%",
          display: "grid",
          marginY: "50px",
          gridTemplateColumns: "1fr 3fr",
        }}
      >
        <Box
          sx={{
            marginTop: "50px",
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Tabs
            sx={{
              marginTop: "40px",
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
              icon={<SettingsIcon selected={value === 1 ? false : true} />}
              label="Genel Ayarlar"
              {...a11yProps(0)}
            />
            <Tab
              data-variant="settings"
              iconPosition="start"
              icon={<PasswordIcon selected={value === 0 ? false : true} />}
              label="Password"
              {...a11yProps(1)}
            />
          </Tabs>
        </Box>
        <Box>
          <CustomTabPanel value={value} index={0}>
            <GenelAyarlar />
          </CustomTabPanel>
          <CustomTabPanel value={value} index={1}>
            <Password />
          </CustomTabPanel>
        </Box>
      </Box>
    </Box>
  );
};

export default EditProfile;
