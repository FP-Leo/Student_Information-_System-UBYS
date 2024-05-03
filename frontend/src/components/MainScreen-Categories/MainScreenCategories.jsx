import { Container, Grid } from "@mui/material";
import React from "react";
import UserCardSm from "../MainScreen-UserInfo/UserCardSm";
import CategoryItem from "./CategoryItem";

export default function MainScreenCategories() {

  return (

    
    <Container  sx={{display:"flex", flexDirection:"column",alignItems:"center"}}>
      <UserCardSm shadowAvailable={true} ppSize={"md"} cardSize={"md"} backgroundAvailable={true} />
    <Grid container spacing={5} sx={{my:6}}>
        <CategoryItem title={"Derslerim"}/>
        <CategoryItem title={"Takvim"}/>
        <CategoryItem title={"Ders Seçimi"}/>
        <CategoryItem title={"Belge Talebi"}/>
    </Grid> 
    </Container>

  );
}
