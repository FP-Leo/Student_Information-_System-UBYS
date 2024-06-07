import { Box, Modal, Typography } from "@mui/material";
import DetayGoruntule from "./Pages/DetayGoruntule";
import SinifListeGoruntule from "./Pages/SinifListeGoruntule";

export default function IslemModal({
  openModal,
  handleModalClose,
  course,
  title,
  faculty,
  department,
  courseSize,
}) {
  const allModals = {
    "Detayları Görüntüle": (
      <DetayGoruntule
        courseSize={courseSize}
        course={course}
        faculty={faculty}
        department={department}
      />
    ),
    "Sınıf Listesini Görüntüle": (
      <SinifListeGoruntule
        courseCode={course.courseCode}
        courseSize={courseSize}
        type={"Sınıf Görüntüle"}
      />
    ),
    "Vize Sınav Sonuç Raporu Görüntüle": (
      <SinifListeGoruntule
        courseCode={course.courseCode}
        courseSize={courseSize}
        type={"Vize Sınav"}
      />
    ),
    "Final Sınav Sonuç Raporu Görüntüle": (
      <SinifListeGoruntule
        courseCode={course.courseCode}
        courseSize={courseSize}
        type={"Final Sınav"}
      />
    ),
    "Bütünlemeye Girmek İsteyen Öğrenci Listesi Görüntüle": (
      <SinifListeGoruntule
        courseCode={course.courseCode}
        courseSize={courseSize}
        type={"Bütünleme Listesi"}
      />
    ),
    "Not Giriş Ekranını Göster": (
      <SinifListeGoruntule
        courseCode={course.courseCode}
        courseSize={courseSize}
        type={"Not Giriş"}
      />
    ),
    "Vize Sınav Yoklama Listesi Görüntüle": (
      <SinifListeGoruntule
        courseCode={course.courseCode}
        courseSize={courseSize}
        type={"Vize Yoklama"}
      />
    ),
    "Final Sınav Yoklama Listesi Görüntüle": (
      <SinifListeGoruntule
        courseCode={course.courseCode}
        courseSize={courseSize}
        type={"Final Yoklama"}
      />
    ),
    "Öğrenci Not Listesi Görüntüle": (
      <SinifListeGoruntule
        courseCode={course.courseCode}
        courseSize={courseSize}
        type={"Öğrenci Not Listesi"}
      />
    ),
    "Devam Listesi Görüntüle": (
      <SinifListeGoruntule
        courseCode={course.courseCode}
        courseSize={courseSize}
        type={"Devam Listesi"}
      />
    ),
  };
  return (
    <Modal
      sx={{
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        flexDirection: "column",
      }}
      open={openModal}
      onClose={handleModalClose}
    >
      <Box
        sx={{
          backgroundColor: "#DFDFDF",
          width: "75%",
          height: "75%",
          border: "1px solid black",
          borderRadius: "20px",
          boxShadow: "7px 7px 5px black",
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
        }}
      >
        <Typography py={5} fontWeight={600} fontSize={20}>
          {title}
        </Typography>

        {allModals[title]}
      </Box>
    </Modal>
  );
}
