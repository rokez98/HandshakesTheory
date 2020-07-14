import React from 'react'
import { Box, Typography, Avatar } from '@material-ui/core'

const Suggestion = ({ Id, FirstName, LastName, PhotoUrl, Role, onSelect }) => {
  return (
    <Box display='flex' flexDirection='column' alignItems='center' maxWidth={150} m={2} onClick={onSelect}>
      <Avatar style={{ width: 100, height: 100 }} src={PhotoUrl} alt={Id} />
      <Typography variant='body1'>{`${FirstName} ${LastName}`}</Typography>
      <Typography variant='body2'>{Role}</Typography>
    </Box>
  )
}

export default Suggestion