// material-ui
import { createTheme, alpha } from "@mui/material/styles";

// third-party
import { presetPalettes } from "@ant-design/colors";

// project import
import ThemeOption from "./theme";

const INFO = {
  lighter: "#C8FAF0",
  light: "#CCEEFF",
  main: "#0094A8",
  dark: "#005778",
  darker: "#002D50",
};
const SUCCESS = {
  lighter: "#DAFBD5",
  light: "#B0F7AD",
  main: "#5BD26E",
  dark: "#2db54f",
  darker: "#168246",
};
const WARNING = {
  lighter: "#FBF7CA",
  light: "#FFFF99",
  main: "#FFFF3F",
  dark: "#DBDB00",
  darker: "#B7B700",
};
const ERROR = {
  lighter: "#FDE0D4",
  light: "#F38B7F",
  main: "#D82D3B",
  dark: "#9B1639",
  darker: "#670832",
};

// ==============================|| DEFAULT THEME - PALETTE  ||============================== //

const Palette = (mode) => {
  const colors = presetPalettes;

  const greyPrimary = [
    "#ffffff",
    "#fafafa",
    "#f5f5f5",
    "#f0f0f0",
    "#d9d9d9",
    "#bfbfbf",
    "#8c8c8c",
    "#595959",
    "#262626",
    "#141414",
    "#000000",
  ];
  const greyAscent = ["#fafafa", "#bfbfbf", "#434343", "#1f1f1f"];
  const greyConstant = ["#fafafb", "#e6ebf1"];

  colors.grey = [...greyPrimary, ...greyAscent, ...greyConstant];

  const paletteColor = ThemeOption(colors);

  return createTheme({
    palette: {
      mode,
      common: {
        black: "#000",
        white: "#fff",
      },
      ...paletteColor,
      success: SUCCESS,
      info: INFO,
      warning: WARNING,
      error: ERROR,
      text: {
        primary: paletteColor.grey[700],
        secondary: paletteColor.grey[500],
        disabled: paletteColor.grey[400],
      },
      action: {
        hover: alpha(paletteColor.grey[500], 0.08),
        disabled: paletteColor.grey[300],
      },
      divider: paletteColor.grey[200],
      background: {
        header: "D9D9D9",
        neutral: "#F4F6F8",
        custom: "#F9FAFB",
        paper: paletteColor.grey[0],
        default: paletteColor.grey.A50,
      },
    },
  });
};

export default Palette;
