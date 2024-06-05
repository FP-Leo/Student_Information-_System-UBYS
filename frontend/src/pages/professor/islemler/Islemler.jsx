import { CancelOutlined } from "@mui/icons-material";
import { Box, Button, Fade } from "@mui/material";
import { useState} from "react";
import IslemButton from "./islemlerButton/IslemButton";
import IslemModal from "./islemlerModal/IslemModal";

export default function Islemler({ setIslemler,course,show , faculty,department ,courseSize}) {

  const [openModal,setOpenModal] = useState(false)
  const [title,setTitle] = useState("")

  const handleModalOpen = () =>{
    setOpenModal(true)
  }
  const handleModalClose = () =>{
    setOpenModal(false)
  }
  

  const handleButtonClick = (event) =>{
    setTitle(event.target.innerText)
    handleModalOpen()
  }


  return (
   <Fade in={show}>
 <Box
        sx={{

            width: "100%",
            display: "grid",
            height: "125px",
            backgroundColor:"#ECECEC",
            borderRadius : "10px",
            gridTemplateColumns: "1fr 1fr 1fr 1fr 1fr 1fr 1fr 1fr 1fr 1fr 1fr 1.75fr",
            borderBottom: "1px solid #B3B3B3",
            borderLeft: "1px solid #B3B3B3",
            borderRight: "1px solid #B3B3B3",
            textAlign:"center",
            fontSize:"15px"
        }}
    >
            <IslemModal 
            courseSize={courseSize}
            faculty={faculty}
            department={department}
            title={title} 
            openModal={openModal} 
            handleModalClose={handleModalClose} 
            course={course}/>
      <Box
          sx={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            gridRow: "1/5",
          }}
        >
          <Button
              onClick={()=>{setIslemler(false)}}
              inputProps={{ 'aria-label': 'controlled' }}
              color="success"
              size="medium"
              sx={{
                ":hover":{backgroundColor:"#DFDFDF"},
                minWidth:"75px",
                minHeight:"75px",
              }}
              
          ><CancelOutlined sx={{
            color:"red"
        }}/></Button>
          
        </Box>
        <IslemButton handleButtonClick={handleButtonClick} title={"Detayları Görüntüle"}/>
        <IslemButton handleButtonClick={handleButtonClick} title={"Not Giriş Ekranını Göster"}/>
        <IslemButton handleButtonClick={handleButtonClick} title={"Sınıf Listesini Görüntüle"}/>
        <IslemButton handleButtonClick={handleButtonClick} title={"Vize Sınav Yoklama Listesi Görüntüle"}/>
        <IslemButton handleButtonClick={handleButtonClick} title={"Yoklama Raporu Görüntüle / Yükle"}/>
        <IslemButton handleButtonClick={handleButtonClick} title={"Devam Listesi Görüntüle"}/>
        <IslemButton handleButtonClick={handleButtonClick} title={"Vize Sınav Sonuç Raporu Görüntüle"}/>
        <IslemButton handleButtonClick={handleButtonClick} title={"Final Sınav Yoklama Listesi Görüntüle"}/>
        <IslemButton handleButtonClick={handleButtonClick} title={"Final Sınav Sonuç Raporu Görüntüle"}/>
        <IslemButton handleButtonClick={handleButtonClick} title={"Öğrenci Not Listesi Görüntüle"}/>
        <IslemButton handleButtonClick={handleButtonClick} title={"Bütünlemeye Girmek İsteyen Öğrenci Listesi Görüntüle"}/>
    </Box>
   </Fade>
  );
}
