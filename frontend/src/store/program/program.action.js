import { createAction } from "reducer";
import { PROGRAM_ACTION_TYPES } from "./program.types";

export const setProgram = (program) =>
  createAction(PROGRAM_ACTION_TYPES.SET_PROGRAM, program);
