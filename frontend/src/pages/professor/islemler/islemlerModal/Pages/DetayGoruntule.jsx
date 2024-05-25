import { Box, Typography } from '@mui/material'
import React from 'react'

export default function DetayGoruntule({course}) {
    const {
        dersAdi,
        dersFakulte,
        dersBirimi,
        dersKodu,
    } = course
  return (
    <Box display={"flex"} flexDirection={"column"}  py={10} >
    <Box display={"flex"}>
    <Typography fontWeight={600} pr={1}>Ders Adı : </Typography>
    <Typography>{dersAdi}</Typography>
    </Box>

    <Box display={"flex"}>
    <Typography fontWeight={600} pr={1}>Ders Fakülte : </Typography>
    <Typography>{dersFakulte}</Typography>
    </Box>

    <Box display={"flex"}>
    <Typography fontWeight={600} pr={1}>Ders Bölüm : </Typography>
    <Typography>{dersBirimi}</Typography>
    </Box>

    <Box display={"flex"}>
    <Typography fontWeight={600} pr={1}>Ders Kodu : </Typography>
    <Typography>{dersKodu}</Typography>
    </Box>

    <Box display={"flex"}>
    <Typography fontWeight={600} pr={1}>Ders AKTS : </Typography>
    <Typography>5 </Typography>
    </Box>

    <Box display={"flex"}>
    <Typography fontWeight={600} pr={1}>Kayıtlı Öğrenci : </Typography>
    <Typography>80</Typography>
    </Box>
</Box>
  )
}
