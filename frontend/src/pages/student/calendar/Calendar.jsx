import axios from "axios";
import { Box } from "@mui/material";
import _ from "lodash";
import moment from "moment";

import { Scheduler } from "@aldabil/react-scheduler";
import { useState, useEffect } from "react";
import { useSelector } from "react-redux";
import { selectUserToken } from "store/user/user.selector";
import { selectProgram } from "store/program/program.selector";

const PORT = 5158;

const Calendar = () => {
  const program = useSelector(selectProgram);
  const token = useSelector(selectUserToken);
  const [dates, setDates] = useState([]);
  const events = [];

  useEffect(() => {
    axios
      .get(
        `http://localhost:${PORT}/api/University/Faculty/Department/Student/Dates`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
          params: { DepartmentName: program },
        }
      )
      .then((res) => {
        setDates(res.data.dates);
      })
      .catch((err) => {
        console.log(err);
      });
  }, []);

  const timeExtractor = (time) => {
    if (time && time.includes(":")) {
      const [hour, minute, second] = time.split(":");
      return { hour, minute, second };
    }
    return;
  };

  const getNextDay = (desiredDay) => {
    const daysOfWeek = [
      "Sunday",
      "Monday",
      "Tuesday",
      "Wednesday",
      "Thursday",
      "Friday",
      "Saturday",
    ];

    const today = moment();
    const currentDayIndex = today.day();

    const desiredDayIndex = daysOfWeek.indexOf(desiredDay);

    let daysUntilDesired = (desiredDayIndex - currentDayIndex + 7) % 7;
    if (daysUntilDesired === 0) {
      daysUntilDesired = 7;
    }

    const desiredDate = today.add(daysUntilDesired, "days");
    return desiredDate.format("YYYY-MM-DD");
  };

  const createEvents = () => {
    return dates.map((date) => {
      let title = date.courseName;
      let startTime;
      let endTime;
      date.classDates.map((classDate) => {
        for (let i = 0; i < classDate.numberOfClasses; i++) {
          let day = getNextDay(classDate.day);
          const extractedTime = timeExtractor(classDate.time);
          startTime = new Date(
            moment(day)
              .hour(extractedTime.hour)
              .minute(extractedTime.minute)
              .add(i * 1, "hours")
          );
          endTime = new Date(moment(startTime).add(55, "minutes"));
          console.log(startTime, endTime);
          events.push({
            event_id: _.uniqueId(),
            title: title,
            start: new Date(startTime),
            end: new Date(endTime),
          });
        }
      });
    });
  };

  createEvents();

  return (
    <Box
      sx={{
        margin: 5,
      }}
    >
      <Scheduler
        agenda={false}
        editable={false}
        deletable={false}
        events={events}
      />
    </Box>
  );
};

export default Calendar;
