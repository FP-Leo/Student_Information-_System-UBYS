// third-party
import { configureStore } from "@reduxjs/toolkit";
import { logger } from "redux-logger";
// project import
import { rootReducer } from "./root-reducer";

export const store = configureStore({
  reducer: rootReducer,
  middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(logger),
});
