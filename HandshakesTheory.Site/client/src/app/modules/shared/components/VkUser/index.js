import React, { useState, useRef } from 'react'
import { Box, Typography, Avatar, Fade } from '@material-ui/core'
import VkUserDetails from '../VkUserDetails'

let timeoutId

const VkUser = ({ index, Id, FirstName, LastName, PhotoUrl, Role, onSelect }) => {
  const elementRef = useRef()

  const [showDetails, setShowDetails] = useState(false)

  const onMouseEnter = () => {
    timeoutId = setTimeout(() => setShowDetails(true), 500)
  }

  const onMouseLeave = () => {
    setShowDetails(false)

    if (timeoutId) {
      clearTimeout(timeoutId)
    }
  }

  return (
    <Fade in={true} timeout={(index + 1) * 250}>
      <Box
        ref={elementRef}
        display='flex'
        flexDirection='column'
        alignItems='center'
        maxWidth={150}
        m={2}
        onClick={onSelect}
        onMouseEnter={onMouseEnter}
        onMouseLeave={onMouseLeave}
      >
        <Avatar style={{ width: 100, height: 100 }} src={PhotoUrl} alt={`${FirstName} ${LastName}`} />
        <Typography variant='body1'>{`${FirstName} ${LastName}`}</Typography>
        <Typography variant='body2'>{Role}</Typography>

        {showDetails && <VkUserDetails anchorEl={elementRef.current} Id={Id} />}
      </Box>
    </Fade>
  )
}

export default VkUser