import axios from "axios";
import { Box } from "@mui/material";
import _ from "lodash";
import moment from "moment";

import { Scheduler } from "@aldabil/react-scheduler";
import { useState, useEffect } from "react";
import { useSelector } from "react-redux";
import { selectUserToken } from "store/user/user.selector";
import { selectProgram } from "store/program/program.selector";
import { v4 as uuidv4 } from "uuid";

const PORT = 5158;

const createUniqueKey = () => {
  return uuidv4();
};

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
  const addExtra = () => {
    events.map((event, index) => {
      for (let i = 1; i < 5; i++) {
        if (i === 4) {
          events.push({
            event_id: createUniqueKey(),
            title: event.title,
            start: new Date(moment(event.start).subtract("1", "weeks")),
            end: new Date(moment(event.end).subtract("1", "weeks")),
          });
        } else {
          events.push({
            event_id: createUniqueKey(),
            title: event.title,
            start: new Date(moment(event.start).add(`${i * 1}`, "weeks")),
            end: new Date(moment(event.end).add(`${i * 1}`, "weeks")),
          });
        }
      }
    });
  };
  addExtra();

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
