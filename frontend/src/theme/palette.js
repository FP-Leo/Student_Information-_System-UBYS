import { alpha } from "@mui/material/styles";

const GREY_LIGHT = {
  0: "#ffffff",
  100: "#F9FAFB",
  200: "#F4F6F8",
  300: "#DFE3E8",
  400: "#C4CDD5",
  500: "#919EAB",
  600: "#637381",
  700: "#454F5B",
  800: "#212B36",
  900: "#161C24",
};

const GREY_DARK = {
  0: "#000000",
  100: "#161C24",
  200: "#212B36",
  300: "#454F5B",
  400: "#637381",
  500: "#919EAB",
  600: "#C4CDD5",
  700: "#DFE3E8",
  800: "#F4F6F8",
  900: "#F9FAFB",
};

const PRIMARY_ORANGE = {
  lighter: "#FEEFCE",
  light: "#FBC16B",
  main: "#F27F0C",
  dark: "#AE4906",
  darker: "#742402",
};

const PRIMARY_RED = {
  lighter: "#FEE6D6",
  light: "#F99F85",
  main: "#EE4036",
  dark: "#AB1B2B",
  darker: "#720A27",
};
const PRIMARY_GREEN = {
  lighter: "#CAFCD4",
  light: "#60F29A",
  main: "#00D47E",
  dark: "#009879",
  darker: "#006564",
};
const PRIMARY_DARK_BLUE = {
  lighter: "#D6D7F7",
  light: "#7E7FCF",
  main: "#222362",
  dark: "#111146",
  darker: "#06062F",
};

const PRIMARY_PURPLE = {
  lighter: "#F6DAFE",
  light: "#D891FC",
  main: "#A948F8",
  dark: "#6324B2",
  darker: "#300D77",
};

const PRIMARY_BLUE = {
  lighter: "#D9E6FF",
  light: "#8EB0FF",
  main: "#4473FF",
  dark: "#2240B7",
  darker: "#0D1D7A",
};

const SECONDARY = {
  lighter: "#DAFBFA",
  light: "#8FE1EB",
  main: "#429EBD",
  dark: "#215F88",
  darker: "#0C315A",
};

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
  light: "#EADB61",
  main: "#BAA205",
  dark: "#857002",
  darker: "#594800",
};
const ERROR = {
  lighter: "#FDE0D4",
  light: "#F38B7F",
  main: "#D82D3B",
  dark: "#9B1639",
  darker: "#670832",
};

const GREY_SETTINGS = (mode) => {
  if (mode === "dark") return GREY_DARK;
  else return GREY_LIGHT;
};

const PRIMARY_SETTINGS = (presets) => {
  switch (presets) {
    case "blue":
      return PRIMARY_BLUE;
    case "darkblue":
      return PRIMARY_DARK_BLUE;
    case "orange":
      return PRIMARY_ORANGE;
    case "red":
      return PRIMARY_RED;
    case "green":
      return PRIMARY_GREEN;
    case "purple":
      return PRIMARY_PURPLE;
    default:
      return PRIMARY_ORANGE;
  }
};

const palette = (themeOptions) => {
  const { themeMode, themeColorPresets } = themeOptions;
  const GREY = GREY_SETTINGS(themeMode);
  const PRIMARY = PRIMARY_SETTINGS(themeColorPresets);
  return {
    common: { black: "#000", white: "#fff" },
    primary: PRIMARY,
    secondary: SECONDARY,
    info: INFO,
    success: SUCCESS,
    warning: WARNING,
    error: ERROR,
    grey: GREY,
    divider: alpha(GREY[500], 0.24),
    text: {
      primary: GREY[900],
      secondary: GREY[600],
      disabled: GREY[500],
    },
    background: {
      paper: GREY[200],
      default: GREY[100],
      neutral: GREY[200],
    },
    action: {
      active: GREY[600],
      hover: alpha(GREY[500], 0.08),
      selected: alpha(GREY[500], 0.16),
      disabled: alpha(GREY[500], 0.8),
      disabledBackground: alpha(GREY[500], 0.24),
      focus: alpha(GREY[500], 0.24),
      hoverOpacity: 0.08,
      disabledOpacity: 0.48,
    },
  };
};

export default palette;
