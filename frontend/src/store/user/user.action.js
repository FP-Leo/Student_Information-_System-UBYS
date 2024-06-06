import { USER_ACTION_TYPES } from "./user.types";
import { createAction } from "../../reducer";

export const setUserToken = (user) =>
  createAction(USER_ACTION_TYPES.SET_USER_TOKEN, user);

export const setUserData = (user) =>
  createAction(USER_ACTION_TYPES.SET_USER_DATA, user);
