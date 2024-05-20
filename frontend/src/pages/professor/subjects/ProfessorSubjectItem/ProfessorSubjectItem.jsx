import { Box, Checkbox, Typography } from "@mui/material";
import { useState } from "react";


export default function ProfessorSubjectItem({yil,donem}) {
    const [selectedSubject ,setSelectedSubject] = useState(false)

    const handleSelectedSubject = () =>{
        setSelectedSubject(!selectedSubject)
    }
    return (
      <Box >
        <Box
          sx={{
            width: "100%",
            display: "grid",
            height: "75px",
            gridTemplateRows: "1fr 1fr 1fr 1fr",
            gridTemplateColumns: "1.25fr 1.75fr 1.5fr 2.5fr 1.5fr 2.5fr 2fr",
            borderBottom: "1px solid #B3B3B3",
            borderLeft: "1px solid #B3B3B3",
            borderRight: "1px solid #B3B3B3",
          }}
        >
          <Box
            sx={{
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              gridRow: "1/5",
              borderRight: "1px solid #B3B3B3",
            }}
          >
            <Checkbox
                checked={selectedSubject}
                onChange={handleSelectedSubject}
                inputProps={{ 'aria-label': 'controlled' }}
                color="success"
                size="large"
            />
          </Box>
          <Box
            sx={{
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              gridRow: "1/5",
            }}
          >
            <Typography variant="body2" sx={{ textAlign: "center" }}>
              Mühendislik Fakültesi - Bilgisayar Mühendisliği 
            </Typography>
          </Box>
          <Box
            
            sx={{
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              gridRow: "1/5",
              borderRight: "1px solid #B3B3B3",
              borderLeft: "1px solid #B3B3B3",
              textAlign:"center"
            }}
          >
            <Typography  variant="body2">BLM-3031</Typography>
          </Box>
          <Box
            sx={{
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              gridRow: "1/5",
              borderRight: "1px solid #B3B3B3",
            }}
          >
            <Typography variant="body2">Nesneye Dayalı Analiz Ve Tasarım (NDAT)</Typography>
          </Box>
          <Box
            sx={{
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              gridRow: "1/5",
            }}
          >
            <Typography variant="body2">{yil}</Typography>
          </Box>
          <Box
            sx={{
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              gridRow: "1/5",
              borderLeft : "1px solid #B3B3B3",
            }}
          >
            <Typography variant="body2">{donem}</Typography>
          </Box>
          <Box
            sx={{
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              gridRow: "1/5",
              borderLeft : "1px solid #B3B3B3",
              
            }}
          >
            <Typography variant="body2">İşlemler</Typography>
          </Box>






        </Box>
      </Box>
    );
}



