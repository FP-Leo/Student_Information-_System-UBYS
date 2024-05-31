import { useState } from "react";

import { alpha } from "@mui/material/styles";
import { Box, Tabs, Tab } from "@mui/material";
import { useTheme } from "@mui/material/styles";

import CustomTabPanel from "components/CustomTabPanel";

import Aciklama from "./tab-components/Aciklama";
import SecmeliDersler from "./tab-components/SecmeliDersler";
import ZorunluDersler from "./tab-components/ZorunluDersler";
import UstDonemDersler from "./tab-components/UstDonemDersler";
import ProgramDisiDersler from "./tab-components/ProgramDisiDersler";
import BasariliOnunanDersler from "./tab-components/BasariliOnunanDersler";

const SecDersler = ({ data }) => {
  const theme = useTheme();
  const [value, setValue] = useState(0);

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  const {
    currentSemesterCourses,
    failedCourses,
    overHeadCourses,
    partiallyPassedCourses,
    passedCourses,
  } = data;
  const optionalCourses = currentSemesterCourses?.filter(
    (course) => course.courseType === "Optional"
  );
  const requiredCourses = currentSemesterCourses?.filter(
    (course) => course.courseType === "Mandatory"
  );

  return (
    <Box
      sx={{
        paddingBottom: "15px",
        maxWidth: "1000px",
        minWidth: "1000px",
        marginLeft: "15px",
        marginY: "15px",
        borderRadius: "10px",
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
          <Tab label="Açıklama" />
          <Tab label="Zorunlu Dersler" />
          <Tab label="Üst Dönem Dersler" />
          <Tab label="Başarılı Olunan Dersler" />
          <Tab label="Seçmeli Dersler" />
          <Tab label="Program Dışı Dersler" />
        </Tabs>
        <CustomTabPanel value={value} index={0}>
          <Aciklama />
        </CustomTabPanel>{" "}
        <CustomTabPanel value={value} index={1}>
          <ZorunluDersler
            courses={{ required: requiredCourses, failed: failedCourses }}
          />
        </CustomTabPanel>
        <CustomTabPanel value={value} index={2}>
          <UstDonemDersler courses={overHeadCourses} />
        </CustomTabPanel>
        <CustomTabPanel value={value} index={3}>
          <BasariliOnunanDersler courses={passedCourses} />
        </CustomTabPanel>
        <CustomTabPanel value={value} index={4}>
          <SecmeliDersler courses={optionalCourses} />
        </CustomTabPanel>
        <CustomTabPanel value={value} index={5}>
          <ProgramDisiDersler />
        </CustomTabPanel>
      </Box>
    </Box>
  );
};

export default SecDersler;
