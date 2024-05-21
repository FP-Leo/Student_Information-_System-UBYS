export const removeSpacesAndLowerCase = (str) => {
  return str.replace(/\s/g, "").toLowerCase();
};

export const checkIfUserIsLoggedIn = () => {
  const user = localStorage.getItem("user");
  return user ? JSON.parse(user) : null;
};

export const getToken = () => {
  const user = localStorage.getItem("user");
  return JSON.parse(user).token;
};
