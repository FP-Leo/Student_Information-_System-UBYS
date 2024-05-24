import TableHeader from "components/TableHeader";
import React from "react";

export default function ProfessorSubjectsTableHeader({ sortByHeader }) {
  return (
    <>
      <TableHeader
        left={false}
        right={true}
        title="Seç"
        onClick={sortByHeader}
      />
      <TableHeader
        left={false}
        right={false}
        title="Ders Birimi"
        onClick={sortByHeader}
      />
      <TableHeader
        left={true}
        right={true}
        title="Ders Kodu"
        onClick={sortByHeader}
      />
      <TableHeader
        left={false}
        right={true}
        title="Ders Adı"
        onClick={sortByHeader}
      />
      <TableHeader
        left={false}
        right={false}
        title="Ders Yılı"
        onClick={sortByHeader}
      />
      <TableHeader
        left={true}
        right={false}
        title="Ders Dönemi"
        onClick={sortByHeader}
      />
      <TableHeader
        left={true}
        right={true}
        title="Ders İşlemleri"
        onClick={sortByHeader}
      />
    </>
  );
}
