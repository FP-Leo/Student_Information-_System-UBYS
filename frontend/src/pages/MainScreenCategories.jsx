import { Container, Grid } from "@mui/material";
import React from "react";
import UserCardSm from "components/UserCardSm";
import DerslerimIcon from "assets/derslerim-icon";
import CalendarIcon from "assets/calendar-icon";
import LinkCard from "components/link-card";
import BelgeIcon from "assets/belge-icon";
import Pages from "./pages";
import { useSelector } from "react-redux";
import { selectCurrentUser } from "store/user/user.selector";

export default function MainScreenCategories() {
  const currentUser = useSelector(selectCurrentUser);
  const PAGES = Pages(currentUser.role);
  return (
    <Container
      sx={{
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        marginTop: "50px",
      }}
    >
      <UserCardSm
        shadowAvailable={true}
        ppSize={"md"}
        cardSize={"md"}
        backgroundAvailable={true}
      />
      <Grid justifyContent="center" container sx={{ my: 6 }}>
        {PAGES.map((page, index) => (
          <LinkCard key={index} title={page.title}>
            {page.icon}
          </LinkCard>
        ))}
      </Grid>
    </Container>
  );
}
