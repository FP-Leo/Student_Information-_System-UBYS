import { Box } from '@mui/material'
import React from 'react'

export default function ClassComponent() {
  return (
    <Box>
        <Box display={"flex"}> 
        <h1>Col1</h1>
        <h1>Col1</h1>
        <h1>Col1</h1>
        <h1>Col1</h1>
        <h1>Col1</h1>
        </Box>
        <Box display={"flex"} flexDirection={"column"}> 
            
        </Box>
    </Box>
  )
}
