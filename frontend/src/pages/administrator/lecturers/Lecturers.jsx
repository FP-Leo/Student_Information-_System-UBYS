import {
  Box,
  Typography,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Grid,
} from "@mui/material";

const Lecturers = () => {
  return (
    <Box
      sx={{
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        marginY: 5,
      }}
    >
      <Typography variant="subtitle1">Lecturers List</Typography>
      <Box
        sx={{
          width: "80%",
          marginTop: 2,
          border: "1px solid red",
        }}
      >
        <Grid
          sx={{
            border: "1px solid red",
          }}
          container
          columns={{ md: 12 }}
          spacing={2}
        >
          <Grid item sx={2}>
            <Typography variant="caption">Lecturer ID</Typography>
          </Grid>
          <Grid item sx={2}>
            <Typography variant="caption">Name</Typography>
          </Grid>
          <Grid item sx={2}>
            <Typography variant="caption">Name</Typography>
          </Grid>
          <Grid item sx={2}>
            <Typography variant="caption">Name</Typography>
          </Grid>
          <Grid item sx={2}>
            <Typography variant="caption">Name</Typography>
          </Grid>
        </Grid>
      </Box>
    </Box>
  );
};
export default Lecturers;
