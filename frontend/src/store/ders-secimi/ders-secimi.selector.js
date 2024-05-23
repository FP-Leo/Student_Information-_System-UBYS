export const selectSelectedSubjects = (state) =>
  state.selectedSubjects.selectedSubjects;

export const selectFetchedSubjects = (state) =>
  state.selectedSubjects.fetchedSubjects;

export const selectedSubjectsAkts = (state) =>
  state.selectedSubjects.selectedSubjects.reduce(
    (acc, item) => acc + Math.floor(item.akts),
    0
  );
