import MainScreenCategories from "pages/MainScreenCategories";
import EditProfile from "pages/edit-profile/EditProfile";
import Lecturers from "pages/administrator/lecturers/Lecturers";

const AdministratorRoutes = [
  {
    path: "",
    element: <MainScreenCategories />,
  },

  {
    path: "lecturers",
    element: <Lecturers />,
  },
  {
    path: "edit-profile",
    element: <EditProfile />,
  },
];

export default AdministratorRoutes;
