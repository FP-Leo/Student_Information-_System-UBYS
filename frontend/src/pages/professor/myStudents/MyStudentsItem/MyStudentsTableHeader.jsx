import TableHeader from "components/TableHeader";
import React from "react";

export default function MyStudentsTableHeader() {
  return (
    <>
      <TableHeader left={false} right={true} title="Resim" />
      <TableHeader left={false} right={false} title="Numarası" />
      <TableHeader left={true} right={true} title="Adı - Soyadı" />
      <TableHeader left={false} right={true} title="Akademik Program" />
      <TableHeader left={false} right={false} title="Kayıtlanma Aşaması" />
      <TableHeader left={true} right={false} title="Sınıfı" />
      <TableHeader left={true} right={true} title="Harç Borcu" />
      <TableHeader left={false} right={true} title="Durum" />
      <TableHeader left={false} right={false} title="Detay Durum" />
      <TableHeader left={true} right={true} title="GANO" />
      <TableHeader left={false} right={true} title="İşlemler" />
    </>
  );
}
