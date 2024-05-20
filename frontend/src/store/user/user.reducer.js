import { USER_ACTION_TYPES } from './user.types';

const INITIAL_STATE = {
  currentUser: {
    createdAt : "2005-05-06T21:34:42",
    firstName : "Erlindi",
    id : 16,
    lastName : "Isaj",
    role : "Professor",
    tc : 99399599530
  }
};

export const userReducer = (state = INITIAL_STATE, action) => {
  const { payload, type } = action;
  switch (type) {
    case USER_ACTION_TYPES.SET_CURRENT_USER:
      return { ...state, currentUser: payload };
    default:
      return state;
  }
};
