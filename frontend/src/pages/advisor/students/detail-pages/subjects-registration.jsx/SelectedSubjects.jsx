import { useSelector } from "react-redux";

import { Box, Typography } from "@mui/material";
import { useTheme } from "@mui/material/styles";

import { selectedSubjectsAkts } from "store/ders-secimi/ders-secimi.selector";
import { selectSelectedSubjects } from "store/ders-secimi/ders-secimi.selector";
import SecilmisDers from "pages/student/subjects-selection/components/SecilmisDers";

const SelectedSubjects = () => {
  const selectedAkts = useSelector(selectedSubjectsAkts);
  const selectedSubjects = useSelector(selectSelectedSubjects);

  const theme = useTheme();
  return (
    <Box
      sx={{
        marginTop: "15px",
        marginRight: "15px",
        borderRadius: "10px",
        backgroundColor: "white",
        width: "450px",
        boxShadow: theme.customShadows.card,
      }}
    >
      <Box
        sx={{
          borderRadius: "10px 10px 0 0",
          backgroundColor: "#E9E9EA",
          height: "60px",
          width: "100%",
          display: "flex",
          alignItems: "center",
          paddingLeft: 2,
          borderBottom: "1px solid #B3B3B3",
        }}
      >
        <Typography variant="subtitle1">Secili Dersler</Typography>
      </Box>

      <Box
        sx={{
          height: "40px",
          backgroundColor: theme.palette.background.paper,
          display: "grid",
          gridTemplateColumns: "0.6fr 1.25fr 2.5fr 1.4fr",
          gridTemplateRows: "1fr",
          alignItems: "center",
          paddingLeft: 2,
          borderBottom: "1px solid #B3B3B3",
        }}
      >
        <Typography variant="caption">Sıra</Typography>
        <Typography variant="caption">Ders Kodu</Typography>
        <Typography variant="caption">Ders Adı</Typography>
        <Typography variant="caption">AKTS</Typography>
      </Box>
      {selectedSubjects.map((item, index) => (
        <SecilmisDers index={index} key={index} data={item} />
      ))}
      <Box
        sx={{
          margin: 1,
          padding: 1,
          border: `1px solid ${theme.palette.divider}`,
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          backgroundColor: theme.palette.info.light,
        }}
      >
        <Typography variant="caption">Secili AKTS:</Typography>
        <Typography
          variant="caption2"
          sx={{
            marginLeft: 1,
          }}
        >
          {selectedAkts}
        </Typography>
      </Box>
    </Box>
  );
};

export default SelectedSubjects;
