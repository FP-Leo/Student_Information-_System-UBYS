import Calendar from "pages/student/calendar/Calendar";
import Subjects from "pages/student/subjects/subjects";
import EditProfile from "pages/edit-profile/EditProfile";
import MainScreenCategories from "pages/MainScreenCategories";
import SubjectsSelection from "pages/student/subjects-selection/SubjectsSelection";

import BelgeTablebi from "pages/student/belge-talebi/BelgeTalebi";
import SubjectDetails from "pages/student/subjects/SubjectDetails.jsx/SubjectDetails";

// ==============================|| Student Routing ||============================== //

const StudentRoutes = [
  {
    path: "",
    element: <MainScreenCategories />,
  },
  {
    path: "derslerim",
    element: <Subjects />,
  },
  {
    path: "derslerim/:id",
    element: <SubjectDetails />,
  },
  {
    path: "ders-secimi",
    element: <SubjectsSelection />,
  },
  {
    path: "edit-profile",
    element: <EditProfile />,
  },
  {
    path: "takvim",
    element: <Calendar />,
  },
  {
    path: "belgetalebi",
    element: <BelgeTablebi />,
  },
];

export default StudentRoutes;
