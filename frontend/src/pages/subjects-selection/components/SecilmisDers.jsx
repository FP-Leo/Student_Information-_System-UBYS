
import { Box, Button, IconButton, Typography } from "@mui/material";
import { useDispatch, useSelector } from "react-redux";
import {
  add_available_subject,
  add_selected_subject,
  remove_from_available,
  remove_from_selected_subject,
} from "store/subject/subject.reducer";

import DeleteIcon from '@mui/icons-material/Delete';
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const SecilmisDers = ({ state, item ,index}) => {
  const dispatch = useDispatch();
  const isEnabled =
    useSelector((state) => state.subject.kalanAkts) === 0 ? false : true;
  const stateColorMap = {
    success: "success.light",
    error: "error.light",
    info: "info",
    other: "warning.light",
  };

  const dersEkle = async () => {
    // daha iyi bir chaining yapılabilir
    if (state === "info") {
      try {
        dispatch(add_selected_subject(item));
      } catch (error) {
        toast.error(error.message,{
          autoClose : 2500,
        });
        return;
      }
      dispatch(remove_from_available(item.id));
    }
  };

  const dersCikar = () => {
    dispatch(remove_from_selected_subject(item))
    dispatch(add_available_subject(item))
  }

  return (
    <>

    <Box
      sx={{
        backgroundColor: stateColorMap[state],
        height: "50px",
        width: "100%",
        display: "grid",
        gridTemplateColumns:
        state === "info" ? "1.25fr 1fr 2.75fr 1fr 1fr 1fr" : "1fr 1.75fr 4fr 1fr 1fr",
        gridTemplateRows: "1fr",
        alignItems: "center",
        paddingLeft: 2,
        borderRadius: state === "info" ? "5px" : "0px",
        mb: state === "info" ? "10px" : "3px",
        boxShadow: state === "info" ? "5px 4px 10px grey" : "",
      }}
    >
      {state === "info" && (
        <Button
          disabled={!isEnabled}
          onClick={dersEkle}
          variant="contained"
          color="success"
          sx={{ color: "#ffffff", width: "100px", height: "35px" }}
        >
          Ders Ekle
        </Button>
      )}  {/* Sağ tarafa ekle butonu koyduk */}
      {state !== "info" &&(
      <Typography>{index}</Typography>
      )}
      <Typography color="info.main" variant="body2">
        BML2002
      </Typography>
      <Typography sx={{maxWidth:"150px"}} variant="body2">Programlama Dilleri Kavramları</Typography>
      <Typography variant="body2">{item.akts}</Typography>
      {state === "info" && (
        <> 
          <Typography variant="body2">Şube</Typography>
          <Typography variant="body2">Alabilir</Typography>
        </>
      )} {/* Sağ taraftaki dersler için ekstra bilgiler koyduk */}
      {state !== "info" && (
      <IconButton 
      onClick={dersCikar}
      aria-label="delete" sx={{color:"#36454F"}}>
        <DeleteIcon/>
      </IconButton>
      )}

    </Box>
  <ToastContainer />
  </>
  );
};

export default SecilmisDers;
