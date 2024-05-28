// src/TranscriptTable.js
import React from "react";
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Box,
  Typography,
} from "@mui/material";

import { useTheme, alpha } from "@mui/material/styles";

const TranscriptTable = ({ data }) => {
  const theme = useTheme();
  // Sample data
  console.log(data);

  return (
    <Box
      sx={{
        marginY: 2,
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "center",
        width: "80%",
        padding: 2,
        boxShadow: theme.customShadows.z8,
        backgroundColor: theme.palette.common.white,
        borderRadius: 2,
      }}
    >
      <Box
        sx={{
          width: "100%",
          display: "flex",
          marginY: 1,
        }}
      >
        <Typography variant="subtitle1">{data.year}</Typography>
        <Typography
          variant="subtitle1"
          sx={{
            marginX: 1,
          }}
        >
          -
        </Typography>
        <Typography variant="subtitle1">{data.semester}</Typography>
      </Box>
      <TableContainer
        sx={{
          boxShadow: "none",
        }}
        component={Paper}
      >
        <Table
          sx={{
            border: `1px solid ${theme.palette.divider}`,
          }}
        >
          <TableHead
            sx={{
              backgroundColor: alpha(theme.palette.grey[300], 0.5),
            }}
          >
            <TableRow colSpan={8}>
              <TableCell colSpan={1}>Ders Kodu</TableCell>
              <TableCell colSpan={4}>Ders Adı</TableCell>
              <TableCell colSpan={1}>Kredi</TableCell>
              <TableCell colSpan={1}>AKTS</TableCell>
              <TableCell colSpan={1}>HBN</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {data.subjects.map((row) => (
              <TableRow
                colSpan={8}
                sx={{
                  "&:nth-of-type(odd)": {
                    backgroundColor: theme.palette.background.paper,
                  },
                }}
                key={row.dersKodu}
              >
                <TableCell colSpan={1}>{row.dersKodu}</TableCell>
                <TableCell colSpan={4}>{row.dersAdi}</TableCell>
                <TableCell colSpan={1}>{row.kredi}</TableCell>
                <TableCell colSpan={1}>{row.akts}</TableCell>
                <TableCell colSpan={1}>{row.hbn}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      <TableContainer
        sx={{
          boxShadow: "none",
          marginY: 2,
        }}
        component={Paper}
      >
        <Table
          sx={{
            border: `1px solid ${theme.palette.divider}`,
          }}
        >
          <TableHead
            sx={{
              backgroundColor: alpha(theme.palette.grey[300], 0.3),
            }}
          >
            <TableRow>
              <TableCell
                sx={{
                  borderRight: `1px solid ${theme.palette.divider}`,
                }}
                colSpan={3}
              />
              <TableCell
                sx={{ borderRight: `1px solid ${theme.palette.divider}` }}
                align="center"
              >
                Alınan Kredi
              </TableCell>
              <TableCell
                sx={{ borderRight: `1px solid ${theme.palette.divider}` }}
                align="center"
              >
                Tamamlanan Kredi
              </TableCell>
              <TableCell
                align="center"
                sx={{ borderRight: `1px solid ${theme.palette.divider}` }}
              >
                Puan
              </TableCell>
              <TableCell
                align="center"
                sx={{ borderRight: `1px solid ${theme.palette.divider}` }}
              >
                YNO
              </TableCell>
              <TableCell
                align="center"
                sx={{ borderRight: `1px solid ${theme.palette.divider}` }}
              >
                GNO
              </TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            <TableRow>
              <TableCell
                sx={{
                  width: "50%",
                  borderRight: `1px solid ${theme.palette.divider}`,
                }}
                align="right"
                colSpan={3}
              >
                Yıllık:
              </TableCell>
              <TableCell
                sx={{ borderRight: `1px solid ${theme.palette.divider}` }}
                align="center"
              >
                13
              </TableCell>
              <TableCell
                sx={{ borderRight: `1px solid ${theme.palette.divider}` }}
                align="center"
              >
                13
              </TableCell>
              <TableCell
                align="center"
                sx={{ borderRight: `1px solid ${theme.palette.divider}` }}
              >
                4.0
              </TableCell>
              <TableCell
                align="center"
                sx={{ borderRight: `1px solid ${theme.palette.divider}` }}
              >
                4.0
              </TableCell>
              <TableCell
                align="center"
                sx={{ borderRight: `1px solid ${theme.palette.divider}` }}
              >
                -
              </TableCell>
            </TableRow>
            <TableRow
              sx={{
                backgroundColor: theme.palette.background.paper,
              }}
            >
              <TableCell
                sx={{
                  width: "50%",
                  borderRight: `1px solid ${theme.palette.divider}`,
                }}
                align="right"
                colSpan={3}
              >
                Birikimli:
              </TableCell>
              <TableCell
                sx={{ borderRight: `1px solid ${theme.palette.divider}` }}
                align="center"
              >
                13
              </TableCell>
              <TableCell
                sx={{ borderRight: `1px solid ${theme.palette.divider}` }}
                align="center"
              >
                13
              </TableCell>
              <TableCell
                align="center"
                sx={{ borderRight: `1px solid ${theme.palette.divider}` }}
              >
                4.0
              </TableCell>
              <TableCell
                align="center"
                sx={{ borderRight: `1px solid ${theme.palette.divider}` }}
              >
                -
              </TableCell>
              <TableCell
                align="center"
                sx={{ borderRight: `1px solid ${theme.palette.divider}` }}
              >
                4.0
              </TableCell>
            </TableRow>
          </TableBody>
        </Table>
      </TableContainer>
    </Box>
  );
};

export default TranscriptTable;
