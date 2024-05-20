import { Box, Typography, Button, Avatar } from "@mui/material";
import React from 'react'
import avatarPhoto from "../../../../assets/avatar1.png" 

export default function MyStudentsItem() {
    return (
        <Box>
          <Box
            sx={{
              width: "100%",
              display: "grid",
              height: "75px",
              gridTemplateRows: "1fr 1fr 1fr 1fr",
              gridTemplateColumns: "1fr 1.5fr 2fr 4fr 2fr 1fr 1fr 1fr 1fr 1fr 1fr",
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
               200401012
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
                Muhammet Eren Nokta
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
                Mühendislik Fakültesi - Bilgisayar Mühendisliği
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
                Kayıt Tamamlandı
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
                    3.Sınıf
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
                -
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
                Aktif
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
                Ders Onayı Bekleniyor
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
                2.82
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
                <Button>
                    İşlemler
                </Button>
              </Typography>
            </Box>

            

          </Box>
        </Box>
      );
}
