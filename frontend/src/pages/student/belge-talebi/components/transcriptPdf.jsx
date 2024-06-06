import React from "react";
import {
  Page,
  Text,
  View,
  Document,
  StyleSheet,
  PDFViewer,
} from "@react-pdf/renderer";

const styles = StyleSheet.create({
  page: {
    flexDirection: "column",
    backgroundColor: "#E4E4E4",
    padding: 10,
  },
  section: {
    margin: 10,
    padding: 10,
    flexGrow: 1,
  },
  table: {
    display: "table",
    width: "auto",
    borderStyle: "solid",
    borderWidth: 1,
    borderRightWidth: 0,
    borderBottomWidth: 0,
  },
  tableRow: {
    margin: "auto",
    flexDirection: "row",
  },
  tableColHeader: {
    width: "20%",
    borderStyle: "solid",
    borderWidth: 1,
    borderLeftWidth: 0,
    borderTopWidth: 0,
  },
  tableCol: {
    width: "20%",
    borderStyle: "solid",
    borderWidth: 1,
    borderLeftWidth: 0,
    borderTopWidth: 0,
  },
  tableCellHeader: {
    margin: "auto",
    marginTop: 5,
    fontSize: 12,
    fontWeight: "bold",
  },
  tableCell: {
    margin: "auto",
    marginTop: 5,
    fontSize: 10,
  },
});

const TranscriptPdf = ({ data }) => (
  <Document>
    <Page style={styles.page}>
      <View style={styles.section}>
        <Text>{`TC: ${data.studentInfo.tc}`}</Text>
        <Text>{`SSN: ${data.studentInfo.ssn}`}</Text>
        <Text>{`Name: ${data.studentInfo.firstName} ${data.studentInfo.lastName}`}</Text>
      </View>
      <View style={styles.section}>
        <Text>{`Registration Date: ${data.departmentInfo.registrationDate}`}</Text>
        <Text>{`Faculty: ${data.departmentInfo.facultyName}`}</Text>
        <Text>{`Department: ${data.departmentInfo.departmentName}`}</Text>
        <Text>{`Type: ${data.departmentInfo.type}`}</Text>
        <Text>{`Language: ${data.departmentInfo.language}`}</Text>
      </View>
      {data.semesters.map((semester, i) => (
        <View key={i} style={styles.section}>
          <Text>{`Semester: ${semester.semester}`}</Text>
          <View style={styles.table}>
            <View style={styles.tableRow}>
              <View style={styles.tableColHeader}>
                <Text style={styles.tableCellHeader}>Course Code</Text>
              </View>
              <View style={styles.tableColHeader}>
                <Text style={styles.tableCellHeader}>Course Name</Text>
              </View>
              <View style={styles.tableColHeader}>
                <Text style={styles.tableCellHeader}>Kredi</Text>
              </View>
              <View style={styles.tableColHeader}>
                <Text style={styles.tableCellHeader}>AKTS</Text>
              </View>
              <View style={styles.tableColHeader}>
                <Text style={styles.tableCellHeader}>Grade</Text>
              </View>
            </View>
            {semester.courses.map((course, j) => (
              <View key={j} style={styles.tableRow}>
                <View style={styles.tableCol}>
                  <Text style={styles.tableCell}>{course.courseCode}</Text>
                </View>
                <View style={styles.tableCol}>
                  <Text style={styles.tableCell}>{course.courseName}</Text>
                </View>
                <View style={styles.tableCol}>
                  <Text style={styles.tableCell}>{course.kredi}</Text>
                </View>
                <View style={styles.tableCol}>
                  <Text style={styles.tableCell}>{course.akts}</Text>
                </View>
                <View style={styles.tableCol}>
                  <Text style={styles.tableCell}>{course.grade}</Text>
                </View>
              </View>
            ))}
          </View>
        </View>
      ))}
    </Page>
  </Document>
);

export default TranscriptPdf;
