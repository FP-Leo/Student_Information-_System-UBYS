import * as XLSX from "xlsx";

import { saveAs } from "file-saver";

import { Button } from "@mui/material";

import ExcelIcon from "assets/excel-icon";

const DownloadAsExcel = ({ data }) => {
  const s2ab = (s) => {
    const buf = new ArrayBuffer(s.length);
    const view = new Uint8Array(buf);
    for (let i = 0; i < s.length; i++) view[i] = s.charCodeAt(i) & 0xff;
    return buf;
  };

  const handleDownload = () => {
    const wb = XLSX.utils.book_new();
    const ws = XLSX.utils.aoa_to_sheet(data);

    XLSX.utils.book_append_sheet(wb, ws, "SheetJS");
    const wbout = XLSX.write(wb, { bookType: "xlsx", type: "binary" });

    const blob = new Blob([s2ab(wbout)], { type: "application/octet-stream" });
    saveAs(blob, "students.xlsx");
  };

  return (
    <Button
      sx={{ height: "45px" }}
      startIcon={<ExcelIcon color="#ffffff" />}
      variant="contained"
      onClick={handleDownload}
    >
      Listeyi Excel olarak al.
    </Button>
  );
};

export default DownloadAsExcel;
