import { Scheduler } from "@aldabil/react-scheduler";
import { Box } from "@mui/material";
const Calendar = () => {
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
        events={[
          {
            event_id: 1,
            title: "Event 1",
            start: new Date("2024/05/18 12:30"),
            end: new Date("2024/05/18 13:30"),
          },
          {
            event_id: 2,
            title: "Event 2",
            start: new Date("2024/05/19 12:30"),
            end: new Date("2024/05/19 13:30"),
          },
        ]}
      />
    </Box>
  );
};

export default Calendar;
