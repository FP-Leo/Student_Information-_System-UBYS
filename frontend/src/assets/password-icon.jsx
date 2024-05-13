import React from "react";
import { useTheme } from "@mui/material/styles";

function PasswordIcon({ selected }) {
  const theme = useTheme();
  return (
    <svg
      xmlns="http://www.w3.org/2000/svg"
      width="30"
      height="30"
      fill="none"
      viewBox="0 0 30 30"
    >
      <path
        fill={selected ? theme.palette.primary.main : "#919EAB"}
        d="M2.5 20c0-3.535 0-5.304 1.099-6.401C4.696 12.5 6.465 12.5 10 12.5h10c3.535 0 5.304 0 6.401 1.099C27.5 14.696 27.5 16.465 27.5 20c0 3.535 0 5.304-1.099 6.401C25.304 27.5 23.535 27.5 20 27.5H10c-3.535 0-5.304 0-6.401-1.099C2.5 25.304 2.5 23.535 2.5 20z"
        opacity="0.25"
      ></path>
      <path
        fill={selected ? theme.palette.primary.main : "#919EAB"}
        d="M10 21.25a1.25 1.25 0 100-2.5 1.25 1.25 0 000 2.5zm5 0a1.25 1.25 0 100-2.5 1.25 1.25 0 000 2.5zM21.25 20a1.25 1.25 0 11-2.5 0 1.25 1.25 0 012.5 0zM8.437 10a6.563 6.563 0 0113.126 0v2.505c.708.006 1.33.022 1.875.063V10a8.437 8.437 0 10-16.875 0v2.569c.624-.041 1.249-.063 1.875-.064V10z"
      ></path>
    </svg>
  );
}

export default PasswordIcon;
