import MainScreenCategories from "pages/MainScreenCategories";
import EditProfile from "pages/edit-profile/EditProfile";
import ProfessorCalendar from "pages/professor/calendar/ProfessorCalendar";
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
    path:"mystudents",
    element:<ProfessorsStudents/>
  },
  {
    path:"mycalendar",
    element:<ProfessorCalendar/>
  },
  {
    path: "mystudents",
    element: <ProfessorsStudents />,
  },

];

export default LecturerRoutes;
