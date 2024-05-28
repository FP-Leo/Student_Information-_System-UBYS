import MainScreenCategories from "pages/MainScreenCategories";
import EditProfile from "pages/edit-profile/EditProfile";
import ProfessorsStudents from "pages/professor/myStudents/ProfessorsStudents";
import ProfessorSubjects from "pages/professor/subjects/ProfessorSubjects";

const LecturerRoutes = [
  {
    path: "",
    element: <MainScreenCategories />,
  },
  {
    path: "edit-profile",
    element: <EditProfile />,
  },
  {
    path: "mycourses",
    element: <ProfessorSubjects />,
  },
  {
    path: "mystudents",
    element: <ProfessorsStudents />,
  },
];

export default LecturerRoutes;
