import { Avatar, Box, Button, Typography } from "@mui/material";
import avatarPhoto from "../../../../assets/avatar1.png";

export default function MyStudentsItem({student}) {
  const {  
  ogrenciNumara,
  ogrenciAd,
  ogrenciSoyad,
  ogrenciFakulte,
  ogrenciProgram,
  kayitlanmaAsamasi,
  ogrenciSinif,
  harcBorcu,
  ogrenciDurum,
  ogrenciDurumDetay,
  GANO
} = student

    return (
        <Box>
          <Box
            sx={{
            
              width: "100%",
              display: "grid",
              height: "125px",
              gridTemplateRows: "1fr 1fr 1fr 1fr",
              gridTemplateColumns: "1fr 1fr 1fr 3fr 1fr 1fr 1fr 1fr 1fr 1fr 1fr",
              borderBottom: "1px solid #B3B3B3",
              borderLeft: "1px solid #B3B3B3",
              borderRight: "1px solid #B3B3B3",
              textAlign:"center"
            }}
          >
            <Box
              sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                gridRow: "1/5",
                borderRight:"1px solid #B3B3B3"
              }}
            >
            <Avatar alt="Ogrenci Resim" src={avatarPhoto} />
            </Box>

            <Box
              sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                gridRow: "1/5",
                borderRight:"1px solid #B3B3B3"
              }}
            >
              <Typography>
              {ogrenciNumara}
              </Typography>
            </Box>

            <Box
              sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                gridRow: "1/5",
                borderRight:"1px solid #B3B3B3",

              }}
            >
              <Typography >
                {ogrenciAd} {ogrenciSoyad}
              </Typography>
            </Box>

            <Box
              sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                gridRow: "1/5",
                borderRight:"1px solid #B3B3B3"
              }}
            >
              <Typography>
                {ogrenciFakulte} - {ogrenciProgram}
              </Typography>
            </Box>

            <Box
              sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                gridRow: "1/5",
                borderRight:"1px solid #B3B3B3"
              }}
            >
              <Typography>
                {kayitlanmaAsamasi}
              </Typography>
            </Box>

            <Box
              sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                gridRow: "1/5",
                borderRight:"1px solid #B3B3B3"
              }}
            >
              <Typography>
                    {ogrenciSinif}
              </Typography>
            </Box>

            <Box
              sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                gridRow: "1/5",
                borderRight:"1px solid #B3B3B3"
              }}
            >
              <Typography>
                {harcBorcu > 0 ? harcBorcu : "-"}
              </Typography>
            </Box>

            <Box
              sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                gridRow: "1/5",
                borderRight:"1px solid #B3B3B3"
              }}
            >
              <Typography
              color={ogrenciDurum ? "#22bb33" : "#bb2124"}
              >
                {ogrenciDurum ? "Başarılı" : "Başarısız"}
              </Typography>
            </Box>

            <Box
              sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                gridRow: "1/5",
                borderRight:"1px solid #B3B3B3"
              }}
            >
              <Typography>
                {ogrenciDurumDetay}
              </Typography>
            </Box>

            <Box
              sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                gridRow: "1/5",
                borderRight:"1px solid #B3B3B3"
              }}
            >
              <Typography>
                {GANO}
              </Typography>
            </Box>

            <Box
              sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                flexDirection:"column",
                gridRow: "1/5",
                borderRight:"1px solid #B3B3B3"
              }}
            >
              <Typography>
                <Button 
                sx={{bgcolor:"#D3D1D1"}}>
                    İşlemler
                </Button>
              </Typography>

            </Box>

            

          </Box>
        </Box>
      );
}
