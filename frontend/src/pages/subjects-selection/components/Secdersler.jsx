import { Box, Button, Typography } from "@mui/material";
import { useTheme } from "@mui/material/styles";
import { useSelector } from "react-redux";
import SecilmisDers from "./SecilmisDers";


const SecDersler = () => {
  const theme = useTheme();


  
  const subjects = useSelector((state)=>state.subject.availableSubjects)


  return (
    <Box
      sx={{
        marginLeft: "15px",
        marginTop: "15px",
        borderRadius: "10px",
        backgroundColor: "white",
        height: "auto",
        boxShadow: theme.customShadows.card,
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
      }}
    >
      <Box sx={{ marginY: "5px", marginX: "15px" }}>
        <Button variant="headerButton">Aciklama</Button>

        <Button variant="headerButton">Zorunlu Dersler</Button>

        <Button variant="headerButton">Üst Dönem Dersler</Button>

        <Button variant="headerButton">Başarılı Olunan Dersler</Button>

        <Button variant="headerButton">Seçmeli Dersler</Button>

        <Button variant="headerButton">Program Dışı Dersler</Button>
      </Box>
      <Box
        sx={{
          marginY: "20px",
          height: "100%",
          width: "100%",
          borderRadius: "10px",
          // backgroundColor: theme.palette.info.light,
        }}
      >
      <Box
      sx={{
        width:"100%",
        bgcolor:"#D9D9D9",
        height:"15%",
        display:"grid",
        alignItems:"center",
        justifyContent:"center",
        gridTemplateRows:"1fr",
        gridTemplateColumns:"1.35fr 1fr 2.75fr 1fr 1fr 1fr"
      }}
      >
        <Typography ml={3}>Seç</Typography>
        <Typography>Ders Kodu</Typography>
        <Typography>Ders Adı</Typography>
        <Typography>AKTS</Typography>
        <Typography>Şube</Typography>
        <Typography>Açıklama</Typography>
      
      </Box>   
        {subjects.length !== 0 ? (
          subjects.map((item) => (
            <SecilmisDers
              state="info"
              key={item.id}
              item={item}
            />
          ))
        ) : (
          <h2 style={{textAlign:"center"}}>Seçilecek ders bulunamadı</h2>
        )}
      </Box>
    </Box>
  );
};

export default SecDersler;
