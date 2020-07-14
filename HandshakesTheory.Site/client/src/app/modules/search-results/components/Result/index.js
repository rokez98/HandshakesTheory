import React from 'react'
import { Box, Avatar, Typography } from '@material-ui/core'

import Accordion from '@material-ui/core/Accordion'
import AccordionSummary from '@material-ui/core/AccordionSummary'
import AccordionDetails from '@material-ui/core/AccordionDetails'

import ExpandMoreIcon from '@material-ui/icons/ExpandMore'

const Result = ({ result }) => {
  return (
    <Accordion>
      <AccordionSummary title='Expand results' expandIcon={<ExpandMoreIcon />}>
        <Box display='flex' alignItems='center' justifyContent='center'>
          {result.map(item => (
            <Avatar style={{ width: 75, height: 75 }} src={item.PhotoUrl} />
          ))}
        </Box>
      </AccordionSummary>
      <AccordionDetails>
        <Box display='flex' flexDirection='column' alignItems='center'>
          {result.map(item => (
            <Box display='flex' flexDirection='column' alignItems='center' justifyContent='center'>
              <Avatar style={{ width: 50, height: 50 }} src={item.PhotoUrl} />
              <Typography
                component='a'
                variant='body2'
                href={`https://vk.com/id${item.Id}`}>{item.FirstName} {item.LastName}
              </Typography>
            </Box>)
          )}
        </Box>
      </AccordionDetails>
    </Accordion>
  )
}

export default Result