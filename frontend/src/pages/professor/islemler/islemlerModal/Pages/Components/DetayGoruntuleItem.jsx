import { Box, Typography } from '@mui/material'
import React from 'react'

export default function DetayGoruntuleItem({title,desc}) {
  return (
    
    <Box display={"flex"}>
    <Typography fontWeight={600} pr={1}>{title}</Typography>
    <Typography>{desc}</Typography>
    </Box>
  )
}
