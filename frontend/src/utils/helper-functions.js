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
