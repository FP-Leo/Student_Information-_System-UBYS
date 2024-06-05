import { TextField, Typography } from "@mui/material";
import React from "react";

export default function SearchInput({setSearchInputArray,initialArray }) {

    // burada 2 tane veri yollanmalı 1.si inital array = bu array tüm datanın bulunduğu ve değişmeyen o array
    // bir de setSearchInputArray var bu set methodu da üstünde değişiklik yaptığımız Array'i temsil ediyor.

   // Yani kullanırken bir tane harici array oluşturup başlangıç değerini initial array'e eşitle
   // Daha sonra bu oluşturduğun array üstünde değişiklik Yap 
  const handleSearchBar = (event) => {
    setSearchInputArray(
      initialArray.filter(
        (item) =>
          item.studentName
            .toLowerCase()
            .includes(event.target.value.toLowerCase().trim())
      )
    );
  };

  return (
    <>
      <Typography mx={2}>Bul:</Typography>
      <TextField
        onChange={handleSearchBar}
        label="İsim giriniz"
        variant="outlined"
      />
    </>
  );
}
