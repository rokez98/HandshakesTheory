import React from 'react'
import { Box, Typography, Avatar, Fade } from '@material-ui/core'

const Suggestion = ({ index, Id, FirstName, LastName, PhotoUrl, Role, onSelect }) => {
  return (
    <Fade key={Id} in={true} timeout={(index + 1) * 250}>
      <Box display='flex' flexDirection='column' alignItems='center' maxWidth={150} m={2} onClick={onSelect}>
        <Avatar style={{ width: 100, height: 100 }} src={PhotoUrl} alt={`${FirstName} ${LastName}`} />
        <Typography variant='body1'>{`${FirstName} ${LastName}`}</Typography>
        <Typography variant='body2'>{Role}</Typography>
      </Box>
    </Fade>
  )
}

export default Suggestion