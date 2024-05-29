import { DERS_SECIMI_ACTIONS } from "./ders-secimi.types";
import { createAction } from "../../utils/reducer";

const addSubject = (subjectsSelected, subjectToAdd) => {
  const existingSubject = subjectsSelected.find(
    (subject) => subject.subjectCode === subjectToAdd.subjectCode
  );

  if (existingSubject) {
    return [...subjectsSelected];
  }
  return [...subjectsSelected, subjectToAdd];
};

const removeSubject = (subjectsSelected, subjectToRemove) => {
  return subjectsSelected.filter(
    (subject) => subject.subjectCode !== subjectToRemove.subjectCode
  );
};

export const addSubjectToStore = (subjectsSelected, subjectToAdd) => {
  const newCartItems = addSubject(subjectsSelected, subjectToAdd);
  return setSelectedSubjects(newCartItems);
};

export const removeSubjectFromStore = (subjectsSelected, subjectToRemove) => {
  const newCartItems = removeSubject(subjectsSelected, subjectToRemove);
  return setSelectedSubjects(newCartItems);
};

export const setSelectedSubjects = (newCartItems) =>
  createAction(DERS_SECIMI_ACTIONS.SET_SELECTED_SUBJECTS, newCartItems);

export const setFetchedSubjects = (fetchedSubjects) =>
  createAction(DERS_SECIMI_ACTIONS.SET_FETCHED_SUBJECTS, fetchedSubjects);
