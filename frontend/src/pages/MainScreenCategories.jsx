import { Container, Grid } from "@mui/material";
import React from "react";
import UserCardSm from "components/UserCardSm";
import DerslerimIcon from "assets/derslerim-icon";
import CalendarIcon from "assets/calendar-icon";
import LinkCard from "components/link-card";
import BelgeIcon from "assets/belge-icon";

import { useSelector } from "react-redux";
import { selectCurrentUser } from "store/user/user.selector";

const STUDENT_PAGES = [
  { title: "Derslerim", icon: <DerslerimIcon /> },
  { title: "Takvim", icon: <CalendarIcon /> },
  { title: "Ders Seçimi", icon: <DerslerimIcon /> },
  { title: "Belge Talebi", icon: <BelgeIcon /> },
];

const PROFESSOR_PAGES = [
  { title: "My Courses", icon: <DerslerimIcon /> },
  { title: "My Calendar", icon: <CalendarIcon /> },
  { title: "My Students", icon: <DerslerimIcon /> },
];

export default function MainScreenCategories() {
  const currentUser = useSelector(selectCurrentUser);
  const isStudent = currentUser?.role === "Student";
  const isProfessor = currentUser?.role === "Professor";

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
        {isStudent
          ? STUDENT_PAGES.map((page, index) => (
              <LinkCard key={index} title={page.title}>
                {page.icon}
              </LinkCard>
            ))
          : isProfessor
          ? PROFESSOR_PAGES.map((page, index) => (
              <LinkCard key={index} title={page.title}>
                {page.icon}
              </LinkCard>
            ))
          : null}
      </Grid>
    </Container>
  );
}
