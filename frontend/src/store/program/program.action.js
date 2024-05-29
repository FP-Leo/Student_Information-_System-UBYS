import { createAction } from "utils/reducer";
import { PROGRAM_ACTION_TYPES } from "./program.types";

export const setProgram = (program) =>
  createAction(PROGRAM_ACTION_TYPES.SET_PROGRAM, program);
