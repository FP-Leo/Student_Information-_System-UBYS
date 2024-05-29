import React from "react";

import { useSelector, useDispatch } from "react-redux";

import { Container, Grid } from "@mui/material";

import LinkCard from "components/link-card";
import UserCardSm from "components/UserCardSm";

import Pages from "./pages";
import { ROLE_TYPES } from "utils/constants";

import { selectUserData } from "store/user/user.selector";
import { selectProgram } from "store/program/program.selector";
import { setProgram } from "store/program/program.action";

export default function MainScreenCategories() {
  const dispatch = useDispatch();
  const program = useSelector(selectProgram);
  const currentUser = useSelector(selectUserData);
  const PAGES = Pages(currentUser.role);
  const isStudent = currentUser.role === ROLE_TYPES.STUDENT;

  const [open, setOpen] = React.useState(program === null ? true : false);
  const [userProgram, setUserProgram] = React.useState("");

  const handleChange = (event) => {
    setUserProgram(event.target.value);
  };

  const handleSelect = (event) => {
    event.preventDefault();
    dispatch(setProgram(userProgram));
    setOpen(false);
  };

  const handleClose = () => {
    setOpen(false);
  };

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
        program={program}
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
