export const SAMPLE_DATA = [
  {
    fakülte: "Engineering",
    bölümler: [
      {
        bölümAdı: "Computer Science",
        dersler: [
          {
            subjectCode: "CS101",
            dersAdı: "Computer Science",
            dönem: "Fall",
            kredi: 3,
            AKTS: 5,
          },
          {
            subjectCode: "CS102",
            dersAdı: "Data Structures",
            dönem: "Spring",
            kredi: 3,
            AKTS: 5,
          },
        ],
      },
      {
        bölümAdı: "Electrical Engineering",
        dersler: [
          {
            subjectCode: "EE101",
            dersAdı: "Circuit Analysis",
            dönem: "Fall",
            kredi: 4,
            AKTS: 6,
          },
          {
            subjectCode: "EE102",
            dersAdı: "Electromagnetics",
            dönem: "Spring",
            kredi: 4,
            AKTS: 6,
          },
        ],
      },
    ],
  },
  {
    fakülte: "Science",
    bölümler: [
      {
        bölümAdı: "Mathematics",
        dersler: [
          {
            subjectCode: "MATH201",
            dersAdı: "Calculus II",
            dönem: "Spring",
            kredi: 4,
            AKTS: 6,
          },
          {
            subjectCode: "MATH202",
            dersAdı: "Linear Algebra",
            dönem: "Fall",
            kredi: 3,
            AKTS: 5,
          },
        ],
      },
      {
        bölümAdı: "Physics",
        dersler: [
          {
            subjectCode: "PHY101",
            dersAdı: "General Physics I",
            dönem: "Fall",
            kredi: 4,
            AKTS: 6,
          },
          {
            subjectCode: "PHY102",
            dersAdı: "General Physics II",
            dönem: "Spring",
            kredi: 4,
            AKTS: 6,
          },
        ],
      },
    ],
  },
  {
    fakülte: "Humanities",
    bölümler: [
      {
        bölümAdı: "History",
        dersler: [
          {
            subjectCode: "HIST101",
            dersAdı: "World History",
            dönem: "Fall",
            kredi: 3,
            AKTS: 5,
          },
          {
            subjectCode: "HIST102",
            dersAdı: "Modern History",
            dönem: "Spring",
            kredi: 3,
            AKTS: 5,
          },
        ],
      },
      {
        bölümAdı: "Philosophy",
        dersler: [
          {
            subjectCode: "PHIL101",
            dersAdı: "Introduction to Philosophy",
            dönem: "Fall",
            kredi: 3,
            AKTS: 5,
          },
          {
            subjectCode: "PHIL102",
            dersAdı: "Ethics",
            dönem: "Spring",
            kredi: 3,
            AKTS: 5,
          },
        ],
      },
    ],
  },
];

export const getFaculties = () => {
  return SAMPLE_DATA.map((faculty) => faculty.fakülte);
};

export const getDepartments = () => {
  const toBeReturned = [];

  SAMPLE_DATA.map((faculty) =>
    faculty.bölümler.map((department) => toBeReturned.push(department.bölümAdı))
  );
  return toBeReturned;
};

export const getDepartmentsByFaculty = (faculty) => {
  const toBeReturned = [];
  SAMPLE_DATA.map((facultyData) => {
    if (facultyData.fakülte === faculty) {
      facultyData.bölümler.map((department) =>
        toBeReturned.push(department.bölümAdı)
      );
    }
  });
  return toBeReturned;
};

export const getSubjects = () => {
  const toBeReturned = [];

  SAMPLE_DATA.map((faculty) =>
    faculty.bölümler.map((department) =>
      department.dersler.map((subject) => toBeReturned.push(subject))
    )
  );
  return toBeReturned;
};

export const filteredSubjects = (faculty, department) => {
  const toBeReturned = [];
  for (let i = 0; i < SAMPLE_DATA.length; i++) {
    if (SAMPLE_DATA[i].fakülte === faculty) {
      for (let j = 0; j < SAMPLE_DATA[i].bölümler.length; j++) {
        if (SAMPLE_DATA[i].bölümler[j].bölümAdı === department) {
          SAMPLE_DATA[i].bölümler[j].dersler.map((ders) =>
            toBeReturned.push(ders)
          );
        }
      }
    }
  }
  return toBeReturned;
};
