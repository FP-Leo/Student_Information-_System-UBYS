import { DERS_SECIMI_ACTIONS } from "./ders-secimi.types";

const INITIAL_STATE = {
  selectedSubjects: [],
  fetchedSubjects: [],
};

export const selectedSubjectsReducer = (state = INITIAL_STATE, action) => {
  const { payload, type } = action;
  switch (type) {
    case DERS_SECIMI_ACTIONS.SET_SELECTED_SUBJECTS:
      return { ...state, selectedSubjects: payload };
    case DERS_SECIMI_ACTIONS.SET_FETCHED_SUBJECTS:
      return { ...state, fetchedSubjects: payload };
    default:
      return state;
  }
};
