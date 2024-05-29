import React from "react";

import { Grid, Typography } from "@mui/material";

export default function ClassComponent() {
  return (
    <Grid
      container
      display={"flex"}
      sx={{ py: 2, px: 2, border: "1px solid black" }}
    >
      <Grid
        item
        xs={8}
        display={"flex"}
        alignItems={"center"}
        justifyContent={"space-evenly"}
      >
        {" "}
        {/* Left Grid */}
        <Grid item xs={2}>
          <Typography>BLM-3002</Typography>
        </Grid>
        <Grid item xs={2}>
          <Typography>Programlama Dilleri Kavramları</Typography>
        </Grid>
        <Grid item xs={2}>
          <Typography>3.0</Typography>
        </Grid>
        <Grid item xs={2}>
          <Typography>5.0</Typography>
        </Grid>
        <Grid item xs={4}>
          <Typography>Ders Kordinaatörlüğü</Typography>
        </Grid>
      </Grid>

      <Grid
        container
        xs={4}
        display={"flex"}
        flexDirection={"column"}
        alignItems={"center"}
      >
        {" "}
        {/* Right Grid */}
        <Grid
          container
          display={"flex"}
          justifyContent={"space-between"}
          alignItems={"center"}
        >
          <Grid item xs={3}>
            <Typography>Devamlı</Typography>
          </Grid>
          <Grid item xs={3}>
            <Typography>90.00</Typography>
          </Grid>
          <Grid item xs={3}>
            <Typography>AA</Typography>
          </Grid>
          <Grid item xs={3}>
            <Typography>Başarılı</Typography>
          </Grid>
        </Grid>
        <Grid
          item
          display={"flex"}
          flexDirection={"column"}
          alignItems={"center"}
        >
          <Typography>Vize : 90.00</Typography>
          <Typography>Final : 90.00</Typography>
          <Typography>Bütünleme : -</Typography>
        </Grid>
      </Grid>
    </Grid>
  );
}
