import { PROGRAM_ACTION_TYPES } from "./program.types";

const INITIAL_STATE = {
  program: null,
};

export const programReducer = (state = INITIAL_STATE, action) => {
  const { payload, type } = action;
  switch (type) {
    case PROGRAM_ACTION_TYPES.SET_PROGRAM:
      return { ...state, program: payload };
    default:
      return state;
  }
};
