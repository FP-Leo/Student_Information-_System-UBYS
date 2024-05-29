import { Box } from "@mui/material";

import InfoBox from "components/Info-Box";

const Aciklama = () => {
  return (
    <Box
      sx={{
        width: "100%",
        display: "flex",
        flexDirection: "column",

        marginTop: "30px",
        paddingX: "10px",
      }}
    >
      <InfoBox description="(*) ile işaretli dersler kredi veya Ders Saati toplamlarına katılmaz." />
      <InfoBox description="(**) ile işaretli derslerin Uzaktan Eğitim olarak verilen şubesi vardır. Kayıt yaptırmak istediğiniz şubeyi seçebilirsiniz. Uzaktan Eğitim, Öğretim Elemanı ve öğrencinin aynı ortamda bulunma zorunluluğu olmaksızın elektronik ortamda internet üzerinden verilen eğitim biçimidir.*" />
      <InfoBox
        heading=":: Seçili Dersler ::"
        description="Sol taraftaki seçili dersler paneli daha önceden aldığınız ancak geçemediğiniz zorunlu dersler ile otomatik olarak doldurulmuş şekilde gelmektedir. AKTS/NZS'nize göre bu derslerin üzerine almak istediğiniz dersleri yukarıdaki tablolardaki dersler içerisinden seçip ekleyebilirsiniz."
      />{" "}
      <InfoBox
        heading=":: Zorunlu Dersler ::"
        description="Zorunlu dersler tabında döneminize açılmış veya daha önceki dönemlerinizde kaldığınız dersler yer almaktadır. (Önceki dönemde kaldığınız ders şu an kayıtlandığınız dönemde açılmışsa otomatik kayıtlanır ve o dersi kaldıramazsınız.) Mezuniyet olabilmek için tamamlaması zorunlu derslerdir."
      />{" "}
      <InfoBox
        heading=":: Üst Dönem Dersleri ::"
        description="Üst dönem dersleri tabında üst döneminize ait dersler bulunmaktadır."
      />{" "}
      <InfoBox
        heading=":: Başarılı Olunan Dersler ::"
        description="Başarılı olunan derslerim tabında daha önce aldığınız ve başarılı olduğunuz dersler yer almaktadır. Not yükseltme amacı ile bu derslerden seçebilirsiniz."
      />{" "}
      <InfoBox
        heading=":: Seçmeli Dersler ::"
        description="Seçmeli dersler tabında seçmeli dersleriniz yer almaktadır. Mezuniyet için zorunlu değildir fakat mezuniyet için gerekli krediyi tamamlayabilmek için seçmeli ders almalısınız."
      />{" "}
      <InfoBox
        heading=":: Program Dışı Dersler ::"
        description="Burada da bölümünüzün kayıtabileceğiniz dersler bulunmaktadır. Kendi biriminizde açılmayan dersler başka birimde açılabilir. Öğrenci işlerine danışmadan dış birimden ders almayınız."
      />
    </Box>
  );
};

export default Aciklama;
