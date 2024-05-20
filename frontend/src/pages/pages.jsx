import { useSelector } from "react-redux";
import { ROLE_TYPES } from "router/role.types";
import { selectCurrentUser } from "store/user/user.selector";

import DerslerimIcon from "assets/derslerim-icon";
import CalendarIcon from "assets/calendar-icon";
import BelgeIcon from "assets/belge-icon";

const STUDENT_PAGES = [
  { title: "Derslerim", icon: <DerslerimIcon /> },
  { title: "Takvim", icon: <CalendarIcon /> },
  { title: "Ders Seçimi", icon: <DerslerimIcon /> },
  { title: "Belge Talebi", icon: <BelgeIcon /> },
];

const PROFESSOR_PAGES = [
  { title: "My Courses", icon: <DerslerimIcon /> },
  { title: "My Calendar", icon: <CalendarIcon /> },
  { title: "My Students", icon: <DerslerimIcon /> },
];

const Pages = (role) => {
  switch (role) {
    case ROLE_TYPES.STUDENT:
      return STUDENT_PAGES;
    case ROLE_TYPES.LECTURER:
      return PROFESSOR_PAGES;
    default:
      return "No pages available for this role.";
  }
};

export default Pages;
