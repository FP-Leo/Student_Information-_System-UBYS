import { Box, Modal, Typography } from "@mui/material";
import DetayGoruntule from "./Pages/DetayGoruntule";
import SinifListeGoruntule from "./Pages/SinifListeGoruntule";

export default function IslemModal({ openModal, handleModalClose , course ,title }) {


    const allModals = {
        "Detayları Görüntüle" : <DetayGoruntule course={course}/>,
        "Sınıf Listesini Görüntüle" : <SinifListeGoruntule/>,
    }
  return (
    <Modal
      sx={{
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        flexDirection: "column",
      }}
      open={openModal}
      onClose={handleModalClose}
    >
      <Box sx={{
        backgroundColor:"#DFDFDF",
        width:"75%",
        height:"75%",
        border : "1px solid black",
        borderRadius:"20px",
        boxShadow:"7px 7px 5px black",
        display:"flex",
        flexDirection:"column",
        alignItems:"center",
        }}>
        <Typography py={5} fontWeight={600} fontSize={20}>{title}</Typography>

        {allModals[title]}

      </Box>
    </Modal>
  );
}
