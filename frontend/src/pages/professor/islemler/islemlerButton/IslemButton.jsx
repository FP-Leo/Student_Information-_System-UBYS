import { Box ,Button} from '@mui/material'
import React from 'react'

export default function IslemButton({handleButtonClick,title}) {
  return (
    <Box
    sx={{
      display: "flex",
      justifyContent: "center",
      alignItems: "center",
      gridRow: "1/5",
    }}>
      <Button onClick={handleButtonClick} sx={{":hover":{backgroundColor:"#DFDFDF"}}}>{title}</Button>
    </Box>
  )
}
