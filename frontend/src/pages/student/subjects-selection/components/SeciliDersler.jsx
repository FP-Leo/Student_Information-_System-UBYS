import { useSelector } from "react-redux";

import { Box, Typography } from "@mui/material";
import { useTheme } from "@mui/material/styles";

import { selectedSubjectsAkts } from "store/ders-secimi/ders-secimi.selector";
import { selectSelectedSubjects } from "store/ders-secimi/ders-secimi.selector";

import SecilmisDers from "./SecilmisDers";

const SeciliDersler = () => {
  const selectedAkts = useSelector(selectedSubjectsAkts);
  const selectedSubjects = useSelector(selectSelectedSubjects);

  const theme = useTheme();
  return (
    <Box
      sx={{
        marginTop: "15px",
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
          height: "60px",
          width: "100%",
          display: "flex",
          justifyContent: "space-around",
          borderBottom: "1px solid #B3B3B3",
        }}
      >
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            justifyContent: "center",
          }}
        >
          <Typography variant="caption">En Fazla AKTS</Typography>
          <Typography variant="caption" color="red">
            35
          </Typography>
        </Box>
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            justifyContent: "center",
          }}
        >
          <Typography variant="caption">Seçili AKTS</Typography>
          <Typography variant="caption" color="red">
            {selectedAkts.toFixed(2)}
          </Typography>
        </Box>
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            justifyContent: "center",
          }}
        >
          <Typography variant="caption">Kalan AKTS</Typography>
          <Typography variant="caption" color="red">
            {(45 - selectedAkts).toFixed(2)}
          </Typography>
        </Box>
      </Box>
      <Box
        sx={{
          height: "40px",
          backgroundColor: "#E9E9EA",
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
      {selectedSubjects.map((item, index) => {
        console.log(item);
        return <SecilmisDers key={index} data={item} />;
      })}

      <Box
        mt={3}
        sx={{
          paddingX: "10px",
          height: "90px",
          display: "flex",
          flexDirection: "column",
          justifyContent: "center",
        }}
      >
        <Box
          sx={{
            display: "flex",
            alignItems: "center",
          }}
        >
          <Box
            sx={{
              marginX: "10px",
              backgroundColor: "success.light",
              height: "15px",
              width: "15px",
            }}
          />
          <Typography variant="caption2">Seçilmiş Dersler</Typography>
        </Box>
        <Box
          sx={{
            display: "flex",
            marginTop: "5px",
            alignItems: "center",
          }}
        >
          <Box
            sx={{
              marginX: "10px",
              backgroundColor: "error.light",
              height: "15px",
              width: "15px",
            }}
          />
          <Typography variant="caption2">Zorunlu Seçilmiş Dersler</Typography>
        </Box>
        <Box
          sx={{
            display: "flex",
            marginTop: "5px",
            alignItems: "center",
          }}
        >
          <Box
            sx={{
              marginX: "10px",
              backgroundColor: "warning.light",
              height: "15px",
              width: "15px",
            }}
          />
          <Typography variant="caption2">Seçmeli Havuzlar</Typography>
        </Box>
      </Box>
    </Box>
  );
};

export default SeciliDersler;
