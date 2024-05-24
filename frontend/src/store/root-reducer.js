import { combineReducers } from "redux";

import { userReducer } from "./user/user.reducer";
import { selectedSubjectsReducer } from "./ders-secimi/ders-secimi.reducer";


export const rootReducer = combineReducers({
  user: userReducer,
  selectedSubjects: selectedSubjectsReducer,

});
