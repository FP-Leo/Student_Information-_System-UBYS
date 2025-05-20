import TableHeader from "components/TableHeader";
import React from "react";

export default function MyStudentsTableHeader() {
  return (
    <>
      <TableHeader left={false} right={true} title="Resim" />
      <TableHeader left={false} right={true} title="Numarası" />
      <TableHeader left={false} right={true} title="Adı - Soyadı" />
      <TableHeader left={false} right={true} title="Akademik Program" />
      <TableHeader left={false} right={true} title="Sınıfı" />
      <TableHeader left={false} right={true} title="Ders Kodu" />
      <TableHeader left={false} right={true} title="Durum" />
      <TableHeader left={false} right={true} title="Detay Durum" />
      <TableHeader left={false} right={false} title="GANO" />
    </>
  );
}
