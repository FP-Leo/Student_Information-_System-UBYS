import FilterAltOutlinedIcon from '@mui/icons-material/FilterAltOutlined';
import { Box, Button, FormControl, MenuItem, Select, Typography } from '@mui/material';
import TableHeader from 'components/TableHeader';
import { useState } from 'react';
import ProfessorSubjectItem from './ProfessorSubjectItem/ProfessorSubjectItem';

export default function ProfessorSubjects() {

    const [yil,setYil] = useState(2024);
    const [donem,setDonem] = useState("Bahar")
    const yillar = [2024,2023,2022,2021]
    const donemler = ["Bahar","Güz"]

    const [tabloBaslik,setTabloBaslik] = useState(yil + "-" + donem)

    const handleSetYear = (event) =>{
        setYil(event.target.value)
    }
    const handleSetDonem = (event)=>{
        setDonem(event.target.value)
    }
    const onClickFilter = ()=>{
        setTabloBaslik(yil + "-" + donem)
    }


  return (
    <Box sx={{width:"100%",display:"flex",flexDirection:"column",}}>
        <Box sx={{display:"flex",alignItems:"flex-start",justifyContent:"space-evenly"}} my={5}>
        <FormControl size="small" sx={{ minWidth: 400 }} id="yilSelect">
            <Select
              value={yil}
              sx={{ fontSize: "12px", fontWeight: "500" }}
              onChange={handleSetYear}
              displayEmpty
              inputProps={{ "aria-label": "Without label" }}
            >
              {yillar.map((yil) => (
                <MenuItem value={yil}>{yil}</MenuItem>
              ))}
            </Select>
          </FormControl>
        <FormControl size="small" sx={{ minWidth: 400 }} id="donemSelect">
            <Select
              value={donem}
              sx={{ fontSize: "12px", fontWeight: "500" }}
              onChange={handleSetDonem}
              inputProps={{ "aria-label": "Without label" }}
            >
              {donemler.map((donem) => (
                <MenuItem value={donem}>{donem}</MenuItem>
              ))}
            </Select>
          </FormControl>
          <Button 
          onClick={onClickFilter}
          sx={{minWidth:400 ,bgcolor:"#1769aa",color:"white",":hover":{backgroundColor:"#1769aa"}}} 
          startIcon={<FilterAltOutlinedIcon/>}>
            Filtrele
          </Button>
        </Box>

        <Box
        sx={{
        width: "100%",
        height: "auto",
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "center",
      }}
    >
      <Box
        px={10}
        sx={{
          width: "100%",
          minWidth: "auto",
          marginTop: "50px",
          borderRadius: "10px",
          paddingBottom: "30px",
          marginBottom: "50px"
        }}
      >
        <Box
          sx={{
            marginY: "20px",
            marginX: "35px",
          }}
        >
          <Typography variant="subtitle1">{tabloBaslik}</Typography>
        </Box>
        <Box
          sx={{
            width: "100%",
            display: "grid",
            gridTemplateColumns: "1.25fr 1.75fr 1.5fr 2.5fr 1.5fr 2.5fr 2fr",
            borderLeft: "1px solid #B3B3B3",
            borderRight: "1px solid #B3B3B3",
          }}
        >
          <TableHeader left={false} right={true} title="Seç" />
          <TableHeader left={false} right={false} title="Ders Birimi" />
          <TableHeader left={true} right={true} title="Ders Kodu" />
          <TableHeader left={false} right={true} title="Ders Adı" />
          <TableHeader left={false} right={false} title="Ders Yılı" />
          <TableHeader left={true} right={false} title="Ders Dönemi" />
          <TableHeader left={true} right={true} title="Ders İşlemleri" />
        </Box>
        <ProfessorSubjectItem yil={yil} donem={donem}/>
        <ProfessorSubjectItem yil={yil} donem={donem}/>
        <ProfessorSubjectItem yil={yil} donem={donem}/>
        <ProfessorSubjectItem yil={yil} donem={donem}/>
      </Box>
    </Box>
    </Box>
  )
}
