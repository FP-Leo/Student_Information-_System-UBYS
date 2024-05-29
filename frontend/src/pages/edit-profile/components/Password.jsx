import { useState } from "react";

import { useTheme } from "@mui/material/styles";
import InputLabel from "@mui/material/InputLabel";
import IconButton from "@mui/material/IconButton";
import FormControl from "@mui/material/FormControl";
import Visibility from "@mui/icons-material/Visibility";
import OutlinedInput from "@mui/material/OutlinedInput";
import { Box, Typography, Button } from "@mui/material";
import InputAdornment from "@mui/material/InputAdornment";
import VisibilityOff from "@mui/icons-material/VisibilityOff";

import PasswordHeaderIcon from "assets/password-header-icon";

const Password = () => {
  const theme = useTheme();

  const [showPassword, setShowPassword] = useState(false);

  const handleClickShowPassword = () => setShowPassword((show) => !show);

  const handleMouseDownPassword = (event) => {
    event.preventDefault();
  };

  return (
    <Box
      sx={{
        marginTop: "40px",
      }}
    >
      <Box
        sx={{
          display: "flex",
          alignItems: "center",
        }}
      >
        <Box
          sx={{
            marginRight: "36px",
            borderRadius: "50%",
            width: "80px",
            height: "80px",
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            boxShadow: theme.customShadows.card,
          }}
        >
          <PasswordHeaderIcon />
        </Box>
        <Typography variant="subtitle1">Change Password</Typography>
      </Box>
      <Box
        sx={{
          marginTop: "40px",
          display: "flex",
          flexDirection: "column",
        }}
      >
        <FormControl
          sx={{
            width: "80%",
            marginY: "15px",
          }}
          variant="outlined"
        >
          <InputLabel htmlFor="outlined-adornment-password">
            Old Password
          </InputLabel>
          <OutlinedInput
            sx={{
              borderRadius: "10px",
            }}
            id="outlined-adornment-password"
            type={showPassword ? "text" : "password"}
            endAdornment={
              <InputAdornment position="end">
                <IconButton
                  aria-label="toggle password visibility"
                  onClick={handleClickShowPassword}
                  onMouseDown={handleMouseDownPassword}
                  edge="end"
                >
                  {showPassword ? <VisibilityOff /> : <Visibility />}
                </IconButton>
              </InputAdornment>
            }
            label="Password"
          />
        </FormControl>{" "}
        <FormControl
          sx={{
            width: "80%",
            marginY: "15px",
          }}
          variant="outlined"
        >
          <InputLabel htmlFor="outlined-adornment-password">
            New Password
          </InputLabel>
          <OutlinedInput
            sx={{
              borderRadius: "10px",
            }}
            id="outlined-adornment-password"
            type={showPassword ? "text" : "password"}
            label="Password"
          />
        </FormControl>{" "}
        <FormControl
          sx={{
            width: "80%",
            marginY: "15px",
          }}
          variant="outlined"
        >
          <InputLabel htmlFor="outlined-adornment-password">
            Re-type new password
          </InputLabel>
          <OutlinedInput
            sx={{
              borderRadius: "10px",
            }}
            id="outlined-adornment-password"
            type={showPassword ? "text" : "password"}
            label="Password"
          />
        </FormControl>
        <Button
          sx={{
            width: "25%",
            margin: "20px 0",
            borderRadius: "10px",
          }}
          color="primary"
          size="large"
          type="submit"
          variant="contained"
        >
          Change Password
        </Button>
      </Box>
    </Box>
  );
};

export default Password;
