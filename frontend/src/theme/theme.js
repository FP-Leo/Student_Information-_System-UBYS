import PropTypes from "prop-types";
import { useMemo, useContext } from "react";

import { ThemeSettingsContext } from "context/theme-context/theme-settings";

import { CssBaseline } from "@mui/material";
import {
  ThemeProvider as MUIThemeProvider,
  createTheme,
  StyledEngineProvider,
} from "@mui/material/styles";

import palette from "./palette";
import shadows from "./shadows";
import typography from "./typography";
import GlobalStyles from "./globalStyles";
import ComponentsOverrides from "./overrides";
import customShadows from "./customShadows";

// ----------------------------------------------------------------------

export default function ThemeProvider({ children }) {
  const themeOptions = useContext(ThemeSettingsContext);

  const baseThemeOptions = useMemo(
    () => ({
      palette: palette(themeOptions),
      shape: { borderRadius: 8 },
      typography,
      shadows: shadows(themeOptions),
      customShadows: customShadows(themeOptions),
    }),
    [themeOptions]
  );

  // const memoizedValue = useMemo(
  //   () => ({
  //     ...baseThemeOptions,
  //   }),
  //   [baseThemeOptions]
  // );

  const theme = createTheme(baseThemeOptions);
  theme.components = ComponentsOverrides(theme);

  return (
    <StyledEngineProvider injectFirst>
      <MUIThemeProvider theme={theme}>
        <CssBaseline />
        <GlobalStyles />
        {children}
      </MUIThemeProvider>
    </StyledEngineProvider>
  );
}

ThemeProvider.propTypes = {
  children: PropTypes.node,
};
