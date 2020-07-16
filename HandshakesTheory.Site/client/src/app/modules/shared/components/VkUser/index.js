import React, { useState, useRef } from 'react'
import { Box, Typography, Avatar, Fade, Popper } from '@material-ui/core'
import VkUserDetails from '../VkUserDetails'

let timeoutId

const UserPopper = ({ anchorEl, children }) => {
  return (
    <Popper open={true} anchorEl={anchorEl} placement='top-start' transition>
      {({ TransitionProps }) => (
        <Fade {...TransitionProps} timeout={500}>
          <div>
            {children}
          </div>
        </Fade>
      )}
    </Popper>
  )
}

const VkUser = ({
  index,
  Id,
  FirstName,
  LastName,
  PhotoUrl,
  Role,
  onSelect,
  showName = true
}) => {
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
    <Box
      ref={elementRef}
      display='flex'
      flexDirection='column'
      alignItems='center'
      maxWidth={150}
      m={0.5}
      onClick={onSelect}
      onMouseEnter={onMouseEnter}
      onMouseLeave={onMouseLeave}
    >
      <Avatar style={{ width: 32, height: 32 }} src={PhotoUrl} alt={`${FirstName} ${LastName}`} />
      {showName &&
        <>
          <Typography variant='body1'>{`${FirstName} ${LastName}`}</Typography>
          <Typography variant='body2'>{Role}</Typography>
        </>
      }

      {showDetails &&
        <UserPopper anchorEl={elementRef.current}>
          <VkUserDetails Id={Id} />
        </UserPopper>
      }
    </Box>
  )
}

export default VkUser