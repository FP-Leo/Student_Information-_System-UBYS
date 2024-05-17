import MainScreenCategories from "pages/MainScreenCategories";
import EditProfile from "pages/edit-profile/EditProfile";

const ProfessorRoutes = [
  {
    path: "",
    element: <MainScreenCategories />,
  },
  {
    path: "edit-profile",
    element: <EditProfile />,
  },
];

export default ProfessorRoutes;
