import { createContext, useReducer } from "react";

const INITIAL_SETTINGS = {
  themeMode: "light", // 'light' | 'dark'
  themeColorPresets: "blue", // 'default' | 'blue' | 'purple' | 'darkblue' | 'orange' | 'red' | 'green'
  //   themeDirection: "ltr", //  'rtl' | 'ltr'
  //   themeContrast: "default", // 'default' | 'bold'
  //   themeLayout: "vertical", // 'vertical' | 'horizontal' | 'mini'
  //   themeStretch: false,
};

const SETTING_ACTIONS = {
  SET_THEME_MODE: "SET_THEME_MODE",
  SET_THEME_COLOR_PRESETS: "SET_THEME_COLOR_PRESETS",
  //   SET_THEME_DIRECTION: "SET_THEME_DIRECTION",
  //   SET_THEME_CONTRAST: "SET_THEME_CONTRAST",
  //   SET_THEME_LAYOUT: "SET_THEME_LAYOUT",
  //   SET_THEME_STRETCH: "SET_THEME_STRETCH",
};

export const ThemeSettingsContext = createContext({
  themeMode: "light",
  changeThemeMode: () => {},
  themeColorPresets: "orange",
  changeThemeColorPresets: () => {},
});

const settingsReducer = (state, action) => {
  const { type, payload } = action;

  switch (type) {
    case SETTING_ACTIONS.SET_THEME_MODE:
      return { ...state, themeMode: payload };
    case SETTING_ACTIONS.SET_THEME_COLOR_PRESETS:
      return { ...state, themeColorPresets: payload };
    // case SETTING_ACTIONS.SET_THEME_DIRECTION:
    //   return { ...state, themeDirection: payload };
    // case SETTING_ACTIONS.SET_THEME_CONTRAST:
    //   return { ...state, themeContrast: payload };
    // case SETTING_ACTIONS.SET_THEME_LAYOUT:
    //   return { ...state, themeLayout: payload };
    // case SETTING_ACTIONS.SET_THEME_STRETCH:
    //   return { ...state, themeStretch: payload };
    default:
      return state;
  }
};

export const ThemeSettingProvider = ({ children }) => {
  const [
    {
      themeMode,
      themeColorPresets,
      //   themeContrast,
      //   themeDirection,
      //   themeLayout,
      //   themeStretch,
    },
    dispatch,
  ] = useReducer(settingsReducer, INITIAL_SETTINGS);

  const changeThemeMode = (mode) => {
    if (themeMode === mode) return;
    dispatch({ type: SETTING_ACTIONS.SET_THEME_MODE, payload: mode });
  };

  const changeThemeColorPresets = (colorPresets) => {
    if (themeColorPresets === colorPresets) return;
    dispatch({
      type: SETTING_ACTIONS.SET_THEME_COLOR_PRESETS,
      payload: colorPresets,
    });
  };

  //   const changeThemeContrast = (contrast) => {
  //     dispatch({ type: SETTING_ACTIONS.SET_THEME_MODE, payload: contrast });
  //   };

  //   const changeThemeDirection = (direction) => {
  //     dispatch({ type: SETTING_ACTIONS.SET_THEME_MODE, payload: direction });
  //   };

  //   const changeThemeLayout = (layout) => {
  //     dispatch({ type: SETTING_ACTIONS.SET_THEME_MODE, payload: layout });
  //   };

  //   const changeThemeStretch = (stretch) => {
  //     dispatch({ type: SETTING_ACTIONS.SET_THEME_MODE, payload: stretch });
  //   };

  const value = {
    themeMode,
    changeThemeMode,
    themeColorPresets,
    changeThemeColorPresets,
    // themeContrast,
    // themeDirection,
    // themeLayout,
    // themeStretch,
  };

  return (
    <ThemeSettingsContext.Provider value={value}>
      {children}
    </ThemeSettingsContext.Provider>
  );
};
