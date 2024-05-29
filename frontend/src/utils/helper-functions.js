export const removeSpacesAndLowerCase = (str) => {
  return str.replace(/\s/g, "").toLowerCase();
};

export const getArrayFromObject = (input) =>
  input.map(function (obj) {
    return Object.keys(obj)
      .sort()
      .map(function (key) {
        return obj[key];
      });
  });

export const checkIfUserIsLoggedIn = () => {
  const user = localStorage.getItem("user");
  return user ? JSON.parse(user) : null;
};

export const getToken = () => {
  const token = localStorage.getItem("token");
  return token ? token : null;
};

export const calculateSubjectsPoint = (midTerm, final) => {
  return (midTerm * 0.4 + final * 0.6).toFixed(2);
};

export const calculateSubjectsHBN = (points) => {
  if (points >= 90) {
    return "AA";
  } else if (points >= 85) {
    return "BA";
  } else if (points >= 80) {
    return "BB";
  } else if (points >= 70) {
    return "CB";
  } else if (points >= 60) {
    return "CC";
  } else if (points >= 55) {
    return "DC";
  } else if (points >= 50) {
    return "DD";
  } else if (points >= 40) {
    return "FD";
  } else if (points < 40) {
    return "FF";
  } else {
    return "FS";
  }
};
