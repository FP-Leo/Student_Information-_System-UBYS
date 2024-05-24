import { USER_ACTION_TYPES } from "./user.types";
import { createAction } from "../../utils/reducer";

export const setCurrentUser = (user) =>
  createAction(USER_ACTION_TYPES.SET_CURRENT_USER, user);

export const setUserData = (user) =>
  createAction(USER_ACTION_TYPES.SET_USER_DATA, user);
