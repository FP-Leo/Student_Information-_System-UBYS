import React from "react";
import {
  Document,
  Page,
  Text,
  View,
  StyleSheet,
  Font,
} from "@react-pdf/renderer";

Font.register({
  family: "Ubuntu",
  fonts: [
    {
      src: "https://fonts.gstatic.com/s/questrial/v13/QdVUSTchPBm7nuUeVf7EuStkm20oJA.ttf",
    },
    {
      src: "https://fonts.gstatic.com/s/questrial/v13/QdVUSTchPBm7nuUeVf7EuStkm20oJA.ttf",
      fontWeight: "bold",
    },
    {
      src: "https://fonts.gstatic.com/s/questrial/v13/QdVUSTchPBm7nuUeVf7EuStkm20oJA.ttf",
      fontWeight: "normal",
      fontStyle: "italic",
    },
  ],
});

const styles = StyleSheet.create({
  page: {
    paddingVertical: 30,
    paddingHorizontal: 100,
    fontSize: 12,
    fontFamily: "Ubuntu",
  },
  header: {
    fontSize: 14,
    fontWeight: "bold",
    marginBottom: 10,
  },
  infoTable: {
    display: "flex",
    flexDirection: "column",
    marginBottom: 20,
  },
  infoRow: {
    display: "flex",
    justifyContent: "space-between",
    marginBottom: 5,
  },
  infoLabel: {
    fontWeight: "bold",
  },
  infoValue: {
    textAlign: "right",
  },
  sectionTitle: {
    fontSize: 14,
    fontWeight: "bold",
    marginTop: 20,
    marginBottom: 10,
  },
  documentInfo: {
    display: "flex",
    flexDirection: "column",
  },
  signature: {
    marginTop: 20,
    textAlign: "right",
  },
  headContainer: {
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    marginBottom: 20,
  },
  header2: {
    fontSize: 12,
    fontWeight: "bold",
  },
  header3: {
    textAlign: "center",
    fontSize: 14,
    fontWeight: "bold",
    marginBottom: 20,
  },
  container: {
    marginTop: 20,
    display: "flex",
    flexDirection: "row",
    justifyContent: "space-between",
    marginBottom: 20,
  },
  column1: {
    display: "flex",
    flexDirection: "column",
  },
  column2: {
    display: "flex",
    flexDirection: "column",
  },
  caption: {
    fontSize: 12,
    marginBottom: 5,
  },
  caption2: {
    fontSize: 12,
    marginBottom: 5,
  },
});

const StudentInfoPdf = ({ studentData }) => {
  const {
    tc,
    name,
    birthday,
    educationType,
    year,
    studentStatus,
    registrationDate,
    language,
    program,
    type,
  } = studentData;
  return (
    <Document>
      <Page size="A4" style={styles.page}>
        <View style={styles.headContainer}>
          <Text style={styles.header}>Çanakkale Onsekiz Mart Üniversitesi</Text>
          <Text style={styles.header2}>{program}</Text>
          <Text style={styles.header2}>{type}</Text>
        </View>
        <View style={styles.headContainer}>
          <Text style={styles.header3}>İLGİLİ MAKAMA</Text>
        </View>
        <View style={styles.container}>
          <View style={styles.column1}>
            <Text style={styles.caption}>T.C./Y.U. Numarası:</Text>
            <Text style={styles.caption}>Ad/Soyad:</Text>
            <Text style={styles.caption}>Doğum Tarihi:</Text>
            <Text style={styles.caption}>Eğitim Türü:</Text>
            <Text style={styles.caption}>Sınıfı / Eğitim Dönemi:</Text>
            <Text style={styles.caption}>Öğrencilik Durumu:</Text>
            <Text style={styles.caption}>Kayıt Tarihi:</Text>
            <Text style={styles.caption}>Öğrenim Dili:</Text>
          </View>
          <View style={styles.column2}>
            <Text style={styles.caption2}>{tc}</Text>
            <Text style={styles.caption2}>{name}</Text>
            <Text style={styles.caption2}>{birthday}</Text>
            <Text style={styles.caption2}>{educationType}</Text>
            <Text style={styles.caption2}>{year}</Text>
            <Text style={styles.caption2}>{studentStatus}</Text>
            <Text style={styles.caption2}>{registrationDate}</Text>
            <Text style={styles.caption2}>{language}</Text>
          </View>
        </View>
      </Page>
    </Document>
  );
};

export default StudentInfoPdf;
