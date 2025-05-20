import { Avatar, Box, Button, Typography } from "@mui/material";
import avatarPhoto from "../../../../assets/avatar1.png";

export default function MyStudentsItem({student}) {
  const {  
  attendanceFulfilled,
  complement,
  final,
  grade,
  id,
  midTerm,
  state,
  studentName,
  year,
  courseCode,
} = student

console.log(student)

    return (
        <Box>
          <Box
            sx={{
            
              width: "100%",
              display: "grid",
              height: "125px",
              gridTemplateRows: "1fr 1fr 1fr 1fr",
              gridTemplateColumns: "1fr 1fr 1fr 3fr 1fr 1fr 1fr 1fr 1fr",
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
              {id}
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
                {studentName}
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
                    {year} Year
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
                {courseCode}
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
              color={state !== null? "#22bb33" : "#bb2124"}
              >
                {state === "Attending" ? "Devamlı" : "Devamsız"}
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
              }}
            >
              <Typography>
                {(((midTerm * 0.4) + (final * 0.6) + (complement*0.6))/30).toFixed(2)}
              </Typography>
            </Box>

            

          </Box>
        </Box>
      );
}
