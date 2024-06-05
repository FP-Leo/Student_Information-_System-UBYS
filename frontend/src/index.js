import ReactDOM from "react-dom/client";
import { BrowserRouter } from "react-router-dom";
import App from "./App";
import "./index.css";
import reportWebVitals from "./reportWebVitals";

import { Provider as ReduxProvider } from "react-redux";
import { store } from "./store/root";

import { ThemeSettingProvider } from "context/theme-context/theme-settings";
import ThemeProvider from "theme/theme";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <ReduxProvider store={store}>
    <ThemeSettingProvider>
      <ThemeProvider>
        <BrowserRouter>
          <App />
        </BrowserRouter>
      </ThemeProvider>
    </ThemeSettingProvider>
  </ReduxProvider>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
