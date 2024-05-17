import { lazy } from "react";

import MainScreenCategories from "pages/MainScreenCategories";
import Subjects from "pages/student/subjects/subjects";
import SubjectsSelection from "pages/student/subjects-selection/SubjectsSelection";
import EditProfile from "pages/edit-profile/EditProfile";
import Calendar from "pages/student/calendar/Calendar";

import ProtectedRoute from "../ProtectedRoute";

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
];

export default StudentRoutes;
