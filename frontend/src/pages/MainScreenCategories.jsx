import { Container, Grid } from "@mui/material";
import React from "react";
import UserCardSm from "components/UserCardSm";
import LinkCard from "components/link-card";
import Pages from "./pages";
import { useSelector } from "react-redux";
import { selectUserData } from "store/user/user.selector";

export default function MainScreenCategories() {
  const currentUser = useSelector(selectUserData);
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
          <LinkCard key={index} link={page.link} title={page.title}>
            {page.icon}
          </LinkCard>
        ))}
      </Grid>
    </Container>
  );
}
