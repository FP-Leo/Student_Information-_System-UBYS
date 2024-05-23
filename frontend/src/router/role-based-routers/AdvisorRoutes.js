import MainScreenCategories from "pages/MainScreenCategories";
import EditProfile from "pages/edit-profile/EditProfile";
import AdvisorStudents from "pages/advisor/students/AdvisorStudents";
import StudentTranscript from "pages/advisor/students/detail-pages/student-transcript/StudentTranscript";
import StudentDetails from "pages/advisor/students/StudentDetails";
import HistoricalDocument from "pages/advisor/students/detail-pages/historical-document/HistoricalDocument";
import StudentsInformation from "pages/advisor/students/detail-pages/student-information/StudentsInformation";
import SubjectsRegistration from "pages/advisor/students/detail-pages/subjects-registration.jsx/SubjectsRegistration";
import RegistrationControl from "pages/advisor/students/detail-pages/registration-control/RegistrationControl";

const AdvisorRoutes = [
  {
    path: "",
    element: <MainScreenCategories />,
  },
  {
    path: "edit-profile",
    element: <EditProfile />,
  },
  {
    path: "advisor-students",
    element: <AdvisorStudents />,
  },

  {
    path: "transcript/:id",
    element: <StudentTranscript />,
  },
  {
    path: "historical-document/:id",
    element: <HistoricalDocument />,
  },
  {
    path: "students-information/:id",
    element: <StudentsInformation />,
  },
  {
    path: "subjects-registration/:id",
    element: <SubjectsRegistration />,
  },
  {
    path: "registration-control/:id",
    element: <RegistrationControl />,
  },
];

export default AdvisorRoutes;
