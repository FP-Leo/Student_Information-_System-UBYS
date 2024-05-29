import { createContext, useReducer } from "react";

// Initial Theme settings these can be changed based on requirements
const INITIAL_SETTINGS = {
  themeMode: "light",
  themeColorPresets: "blue",
};

const SETTING_ACTIONS = {
  SET_THEME_MODE: "SET_THEME_MODE",
  SET_THEME_COLOR_PRESETS: "SET_THEME_COLOR_PRESETS",
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
    default:
      return state;
  }
};

export const ThemeSettingProvider = ({ children }) => {
  const [{ themeMode, themeColorPresets }, dispatch] = useReducer(
    settingsReducer,
    INITIAL_SETTINGS
  );

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

  const value = {
    themeMode,
    changeThemeMode,
    themeColorPresets,
    changeThemeColorPresets,
  };

  return (
    <ThemeSettingsContext.Provider value={value}>
      {children}
    </ThemeSettingsContext.Provider>
  );
};
