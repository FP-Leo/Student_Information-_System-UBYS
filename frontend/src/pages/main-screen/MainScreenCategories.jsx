import { Container, Grid } from "@mui/material";
import React from "react";
import UserCardSm from "components/UserCardSm";
import DerslerimIcon from "assets/derslerim-icon";
import CalendarIcon from "assets/calendar-icon";
import LinkCard from "components/link-card";
import BelgeIcon from "assets/belge-icon";

export default function MainScreenCategories() {
  return (
    <Container
      sx={{
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
      }}
    >
      <UserCardSm
        shadowAvailable={true}
        ppSize={"md"}
        cardSize={"md"}
        backgroundAvailable={true}
      />
      <Grid justifyContent="center" container sx={{ my: 6 }}>
        <LinkCard title="Derslerim">
          <DerslerimIcon />
        </LinkCard>
        <LinkCard title="Takvim">
          <CalendarIcon />
        </LinkCard>
        <LinkCard title="Ders Seçimi">
          <DerslerimIcon />
        </LinkCard>
        <LinkCard title="Belge Talebi">
          <BelgeIcon />
        </LinkCard>
      </Grid>
    </Container>
  );
}
