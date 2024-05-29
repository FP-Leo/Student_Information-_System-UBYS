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
