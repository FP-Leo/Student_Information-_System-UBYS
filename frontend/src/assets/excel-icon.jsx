import React from "react";

function ExcelIcon({ color }) {
  return (
    <svg
      xmlns="http://www.w3.org/2000/svg"
      width="24"
      height="24"
      viewBox="0 0 48 48"
    >
      <defs>
        <mask id="ipTExcel0">
          <g fill="none" stroke="#fff" strokeLinecap="round" strokeWidth="3">
            <path
              strokeLinejoin="round"
              d="M8 15V6a2 2 0 012-2h28a2 2 0 012 2v36a2 2 0 01-2 2H10a2 2 0 01-2-2v-9"
            ></path>
            <path d="M31 15h3m-6 8h6m-6 8h6"></path>
            <path fill="#555" strokeLinejoin="round" d="M4 15h18v18H4z"></path>
            <path strokeLinejoin="round" d="M10 21l6 6m0-6l-6 6"></path>
          </g>
        </mask>
      </defs>
      <path fill={color} d="M0 0h48v48H0z" mask="url(#ipTExcel0)"></path>
    </svg>
  );
}

export default ExcelIcon;
