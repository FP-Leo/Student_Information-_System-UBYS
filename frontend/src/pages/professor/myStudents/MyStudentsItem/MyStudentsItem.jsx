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
  console.log(student);

    return (
        <Box>
          <Box
            sx={{
            
              width: "100%",
              display: "grid",
              height: "125px",
              gridTemplateRows: "1fr 1fr 1fr 1fr",
              gridTemplateColumns: "1fr 1fr 1fr 3fr 1fr 1fr 1fr 1fr 1fr 1fr",
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
              {student.ssn}
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
                {student.studentName}
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
               {student.state === "Attending" ? "Kayıt Başarılı" : "Kayıt Süreci Devam Ediyor"}
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
                    {student.year}.Sınıf
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
              color={student.attendanceFulfilled !== null? "#22bb33" : "#bb2124"}
              >
                {student.attendanceFulfilled !== null ? "Başarılı" : "Başarısız"}
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
                {(((student.midTerm * 0.4) + (student.final * 0.6) + (student.complement*0.6))/30).toFixed(2)}
              </Typography>
            </Box>

            

          </Box>
        </Box>
      );
}
