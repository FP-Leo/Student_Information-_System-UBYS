import ClassComponent from "components/ClassComponent";
import React from "react";

export default function Derslerim() {
  const totalClasses = [1, 2, 3, 4, 5];
  return (
    <>
      {totalClasses.map((item) => {
        return <ClassComponent />;
      })}
    </>
  );
}
