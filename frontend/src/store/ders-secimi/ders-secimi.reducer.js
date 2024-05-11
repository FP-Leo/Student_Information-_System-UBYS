import { DERS_SECIMI_ACTIONS } from "./ders-secimi.types";

const INITIAL_STATE = {
  selectedSubjects: [],
};

export const selectedSubjectsReducer = (state = INITIAL_STATE, action) => {
  const { payload, type } = action;
  switch (type) {
    case DERS_SECIMI_ACTIONS.SET_SELECTED_SUBJECTS:
      return { ...state, selectedSubjects: payload };
    default:
      return state;
  }
};
