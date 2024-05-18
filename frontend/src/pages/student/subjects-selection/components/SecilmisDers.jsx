import { Box, IconButton, Typography } from "@mui/material";
import { useDispatch, useSelector } from "react-redux";

//! -------------- Erlindi --------------!//
import DeleteForeverRoundedIcon from "@mui/icons-material/DeleteForeverRounded";
import { removeSubjectFromStore } from "store/ders-secimi/ders-secimi.action";
import { selectSelectedSubjects } from "store/ders-secimi/ders-secimi.selector";

const SecilmisDers = ({ data, value, index, item }) => {
  //! -------------- Erlindi --------------!//
  const { subjectCode, subjectName, akts, state } = data;
  const dispatch = useDispatch();
  const selectedSubjects = useSelector(selectSelectedSubjects);
  const handleRemove = (e) => {
    e.preventDefault();
    dispatch(removeSubjectFromStore(selectedSubjects, data));
  };

  return (
    <Box
      sx={{
        backgroundColor: state === "success" ? "success.light" : "error.light",
        height: "50px",
        width: "100%",
        display: "grid",
        gridTemplateColumns: "1fr 1.75fr 4fr 1fr 1fr",
        gridTemplateRows: "1fr",
        alignItems: "center",
        paddingLeft: 2,
      }}
    >
      {" "}
      <Typography variant="caption">{index + 1}</Typography>
      <Typography color="info.main" variant="caption">
        {subjectCode}
      </Typography>
      <Typography variant="caption">{subjectName}</Typography>
      <Typography variant="caption">{akts}</Typography>
      <IconButton onClick={handleRemove}>
        <DeleteForeverRoundedIcon fontSize="small" color="error" />
      </IconButton>
    </Box>
  );
};

export default SecilmisDers;
