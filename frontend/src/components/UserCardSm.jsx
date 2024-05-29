import React from "react";

import { useTheme } from "@mui/material/styles";
import { Avatar, Box, Typography, Button } from "@mui/material";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import InputLabel from "@mui/material/InputLabel";
import MenuItem from "@mui/material/MenuItem";
import FormControl from "@mui/material/FormControl";
import Select, { SelectChangeEvent } from "@mui/material/Select";

import DialogTitle from "@mui/material/DialogTitle";

import { ROLE_TYPES } from "utils/constants";

import { useDispatch } from "react-redux";

import { useSelector } from "react-redux";
import { selectUserData } from "store/user/user.selector";
import { selectProgram } from "store/program/program.selector";
import { setProgram } from "store/program/program.action";

import Image from "../assets/photo.svg";

export default function UserCardSm({ ppSize, cardSize, isMenuCard }) {
  const currentUser = useSelector(selectUserData);
  const dispatch = useDispatch();
  const program = useSelector(selectProgram);
  const { firstName, lastName, role, departments } = currentUser;
  const theme = useTheme();

  const isStudent = currentUser.role === ROLE_TYPES.STUDENT;

  const [open, setOpen] = React.useState(program === null ? true : false);
  const [userProgram, setUserProgram] = React.useState("");

  const handleChange = (event) => {
    setUserProgram(event.target.value);
  };

  const handleSelect = (event) => {
    event.preventDefault();
    dispatch(setProgram(userProgram));
    localStorage.setItem("program", userProgram);
    setOpen(false);
  };

  const handleChangeProgram = (e) => {
    e.preventDefault();
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const ppSizeMap = {
    sm: "30px",
    md: "70px",
  };
  const cardSizeMap = {
    sm: "225px",
    md: "350px",
  };
  const ppWidthHeight = ppSizeMap[ppSize] || ppSizeMap["sm"]; // sm is default
  const cardWidth = cardSizeMap[cardSize] || cardSizeMap["sm"]; // Also sm is default
  return (
    <Box
      sx={{
        boxShadow: theme.customShadows.card,
        display: "flex",
        borderRadius: "10px",
        alignItems: !isMenuCard ? "center" : "flex-start",
        backgroundColor: "background.neutral",
        width: cardWidth,
        color: "black",
        py: 3,
        px: 3,
        flexDirection: "column",
      }}
    >
      <Avatar
        alt="Remy Sharp"
        src={Image}
        sx={{ width: ppWidthHeight, height: ppWidthHeight }}
      />
      <Typography variant="subtitle1" sx={{ mt: 3, textDecoration: "none" }}>
        {currentUser ? firstName + " " + lastName : "User Name"}
      </Typography>
      <Typography
        variant="body2"
        color="text.secondary"
        sx={{ textDecoration: "none", fontSize: "14px" }}
      >
        {role}
      </Typography>
      {isStudent ? (
        <>
          <Box
            sx={{
              width: "100%",
              display: "flex",
              flexDirection: "column",
              justifyContent: "center",
              alignItems: "center",
            }}
          >
            <Typography
              sx={{
                marginBottom: 3,
              }}
              variant="subtitle2"
            >
              {program ? program : "No Program Selected"}
            </Typography>
            <Button
              onClick={handleChangeProgram}
              variant="outlined"
              size="small"
            >
              Change Program
            </Button>
          </Box>
          <Dialog
            open={open}
            onClose={handleClose}
            aria-labelledby="alert-dialog-title"
            aria-describedby="alert-dialog-description"
          >
            <DialogTitle id="alert-dialog-title">
              {"Program Selection"}
            </DialogTitle>
            <DialogContent
              sx={{
                display: "flex",
                flexDirection: "column",
                alignItems: "center",
                justifyContent: "center",
              }}
            >
              <DialogContentText id="alert-dialog-description">
                Select the program you want to use for the account.
              </DialogContentText>
              <FormControl
                size="small"
                sx={{
                  width: "50%",
                  marginTop: 3,
                }}
                fullWidth
              >
                <InputLabel id="demo-simple-select-label">Program</InputLabel>
                <Select
                  labelId="demo-simple-select-label"
                  id="demo-simple-select"
                  value={userProgram}
                  label="Program"
                  onChange={handleChange}
                >
                  {departments.map((department) => (
                    <MenuItem value={department.departmentName}>
                      {department.departmentName}
                    </MenuItem>
                  ))}
                </Select>
              </FormControl>
            </DialogContent>
            <DialogActions>
              <Button
                onClick={handleSelect}
                variant="contained"
                sx={{ color: "#fff" }}
                color="success"
              >
                Select
              </Button>
            </DialogActions>
          </Dialog>
        </>
      ) : null}
    </Box>
  );
}
