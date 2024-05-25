import { Box, Grid } from '@mui/material'
import SınıfListeItem from './Components/SınıfListeItem'

export default function SinifListeGoruntule() {
  return (
    <Box
    sx={{
        display:"flex",
        flexDirection:"column",
        alignItems:"center",
        height:"50%",
    }}
    >
      <SınıfListeItem/>
      <SınıfListeItem/>
      <SınıfListeItem/>
        

    </Box>
  )
}
