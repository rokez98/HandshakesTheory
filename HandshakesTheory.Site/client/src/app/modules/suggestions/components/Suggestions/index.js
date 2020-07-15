import React from 'react'
import { Box, Typography } from '@material-ui/core'

import { suggestions } from '../../constants'

import VkUser from '../../../shared/components/VkUser'

const Suggestions = ({ onSelect }) => {
  return (
    <Box display='flex' flexDirection='column' alignItems='center'>
      <Typography variant='h5'>
        Can't choose? Let us help you
      </Typography>
      <Box display='flex' alignItems='center' justifyContent='center' flexWrap='wrap'>
        {suggestions.map((item, index) =>
          <VkUser key={item.Id} index={index} {...item} onSelect={() => onSelect(item)} />
        )}
      </Box>
    </Box>
  )
}

export default Suggestions