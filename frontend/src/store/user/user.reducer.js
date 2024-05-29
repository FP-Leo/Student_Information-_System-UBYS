import { USER_ACTION_TYPES } from "./user.types";

const INITIAL_STATE = {
  userToken: null,
  userData: null,
};

export const userReducer = (state = INITIAL_STATE, action) => {
  const { payload, type } = action;
  switch (type) {
    case USER_ACTION_TYPES.SET_USER_TOKEN:
      return { ...state, userToken: payload };
    case USER_ACTION_TYPES.SET_USER_DATA:
      return { ...state, userData: payload };

    default:
      return state;
  }
};
