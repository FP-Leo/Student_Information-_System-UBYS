import { combineReducers } from "redux";

import { userReducer } from "./user/user.reducer";
import { selectedSubjectsReducer } from "./ders-secimi/ders-secimi.reducer";
import { programReducer } from "./program/program.reducer";

export const rootReducer = combineReducers({
  user: userReducer,
  selectedSubjects: selectedSubjectsReducer,
  program: programReducer,
});
