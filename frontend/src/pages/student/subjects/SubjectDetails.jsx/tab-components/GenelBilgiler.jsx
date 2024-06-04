import { useTheme } from "@mui/material/styles";
import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import axios from "axios";
import { useSelector } from "react-redux";
import { selectUserToken } from "store/user/user.selector";
import { Box } from "@mui/material";
import GenelBilgilerTablo from "./components/genelBilgilerTablo";

const GenelBilgiler = () => {
  const token = useSelector(selectUserToken);
  const params = useParams();
  const theme = useTheme();
  console.log(params);
  const [data, setData] = useState([]);

  useEffect(() => {
    axios
      .get(
        "http://localhost:5158/api/University/Faculty/Department/Course/Student/Results",
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
          params: {
            courseCode: params.courseCode,
          },
        }
      )
      .then((res) => {
        setData(res.data);
      })
      .catch((err) => {
        alert(err.response.data.message);
      });
  }, []);

  console.log(data);

  return (
    <Box>
      {data.map((item, index) => {
        return <GenelBilgilerTablo key={index} data={item} />;
      })}
    </Box>
  );
};
export default GenelBilgiler;
