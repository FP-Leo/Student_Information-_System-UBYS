import { useState } from "react";

import { alpha } from "@mui/material/styles";
import { Box, Tabs, Tab } from "@mui/material";
import { useTheme } from "@mui/material/styles";

import CustomTabPanel from "components/CustomTabPanel";

import SecmeliDersler from "pages/student/subjects-selection/components/tab-components/SecmeliDersler";
import ZorunluDersler from "pages/student/subjects-selection/components/tab-components/ZorunluDersler";
import UstDonemDersler from "pages/student/subjects-selection/components/tab-components/UstDonemDersler";
import ProgramDisiDersler from "pages/student/subjects-selection/components/tab-components/ProgramDisiDersler";
import BasariliOnunanDersler from "pages/student/subjects-selection/components/tab-components/BasariliOnunanDersler";

const SelectSubjects = () => {
  const theme = useTheme();
  const [value, setValue] = useState(0);

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  return (
    <Box
      sx={{
        paddingBottom: "15px",
        maxWidth: "100%",
        minWidth: "1000px",
        marginY: "15px",
        backgroundColor: "white",
        height: "auto",
        boxShadow: theme.customShadows.card,
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
      }}
    >
      <Box
        sx={{
          width: "100%",
          marginY: "5px",
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
        }}
      >
        <Tabs
          TabIndicatorProps={{
            style: {
              height: "100%",
              borderRadius: "10px",
              backgroundColor: alpha(theme.palette.primary.main, 0.1),
            },
          }}
          value={value}
          onChange={handleChange}
        >
          <Tab label="Zorunlu Dersler" />
          <Tab label="Üst Dönem Dersler" />
          <Tab label="Başarılı Olunan Dersler" />
          <Tab label="Seçmeli Dersler" />
          <Tab label="Program Dışı Dersler" />
        </Tabs>

        <CustomTabPanel value={value} index={0}>
          <ZorunluDersler />
        </CustomTabPanel>
        <CustomTabPanel value={value} index={1}>
          <UstDonemDersler />
        </CustomTabPanel>
        <CustomTabPanel value={value} index={2}>
          <BasariliOnunanDersler />
        </CustomTabPanel>
        <CustomTabPanel value={value} index={3}>
          <SecmeliDersler />
        </CustomTabPanel>
        <CustomTabPanel value={value} index={4}>
          <ProgramDisiDersler />
        </CustomTabPanel>
      </Box>
    </Box>
  );
};

export default SelectSubjects;
