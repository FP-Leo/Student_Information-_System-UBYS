import EditProfile from "pages/edit-profile/EditProfile";
import MainScreenCategories from "pages/MainScreenCategories";
import ProfessorSubjects from "pages/professor/subjects/ProfessorSubjects";
import ProfessorsStudents from "pages/professor/myStudents/ProfessorsStudents";

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
