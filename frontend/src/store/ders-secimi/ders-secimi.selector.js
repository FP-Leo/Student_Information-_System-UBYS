export const selectSelectedSubjects = (state) =>
  state.selectedSubjects.selectedSubjects;

export const selectFetchedSubjects = (state) =>
  state.selectedSubjects.fetchedSubjects;

export const selectedSubjectsAkts = (state) =>
  state.selectedSubjects.selectedSubjects?.reduce(
    (acc, item) => acc + Math.floor(item.akts),
    0
  );

export const selectCourseCodes = (state) => {
  const list = [];
  state.selectedSubjects.selectedSubjects.map((subject) => {
    list.push(subject.courseCode);
  });
  return list;
};
