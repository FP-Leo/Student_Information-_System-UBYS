import { ROLE_TYPES } from "router/role.types";

import DerslerimIcon from "assets/derslerim-icon";
import CalendarIcon from "assets/calendar-icon";
import BelgeIcon from "assets/belge-icon";
import StudentIcon from "assets/student-icon";

const STUDENT_PAGES = [
  { title: "Derslerim", link: "derslerim", icon: <DerslerimIcon /> },
  { title: "Takvim", link: "takvim", icon: <CalendarIcon /> },
  { title: "Ders Seçimi", link: "ders-secimi", icon: <DerslerimIcon /> },
  { title: "Belge Talebi", link: "belgetalebi", icon: <BelgeIcon /> },
];

const ADVISOR_PAGES = [
  {
    title: "Danışmanı Olduğum Öğrenciler",
    link: "advisor-students",
    icon: <StudentIcon />,
  },
];

//!~ --------------------- This Needs to be updated --------------------- ~!//
const PROFESSOR_PAGES = [
  { title: "My Courses", link: "mycourses", icon: <DerslerimIcon /> },
  { title: "My Calendar", link: "mycalendar", icon: <CalendarIcon /> },
  { title: "My Students", link: "mystudents", icon: <DerslerimIcon /> },
];

const Pages = (role) => {
  switch (role) {
    case ROLE_TYPES.STUDENT:
      return STUDENT_PAGES;
    case ROLE_TYPES.LECTURER:
      return PROFESSOR_PAGES;
    case ROLE_TYPES.ADVISOR:
      return ADVISOR_PAGES;
    default:
      return "No pages available for this role.";
  }
};

export default Pages;
