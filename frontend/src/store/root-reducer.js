import { combineReducers } from "redux";

import { userReducer } from "./user/user.reducer";
import subjectReducer from "./subject/subject.reducer";

export const rootReducer = combineReducers({ user: userReducer ,subject:subjectReducer});
