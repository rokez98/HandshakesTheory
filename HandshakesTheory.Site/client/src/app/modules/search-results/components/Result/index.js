import React from 'react'
import { Box, Avatar, Typography } from '@material-ui/core'

import Accordion from '@material-ui/core/Accordion'
import AccordionSummary from '@material-ui/core/AccordionSummary'
import AccordionDetails from '@material-ui/core/AccordionDetails'

import ExpandMoreIcon from '@material-ui/icons/ExpandMore'
import VkUser from '../../../shared/components/VkUser'

const Result = ({ result }) => {
  return (
    <Accordion>
      <AccordionSummary title='Expand results' expandIcon={<ExpandMoreIcon />}>
        <Box display='flex' alignItems='center' justifyContent='space-between' flexGrow={1}>
          {result.map((item, index) => (
            <VkUser key={item.Id} index={index} {...item} />
          ))}
        </Box>
      </AccordionSummary>
      <AccordionDetails>
        <Box display='flex' justifyContent='space-between' alignItems='center' flexGrow={1}>
          {result.map(item => (
            <Box display='flex' flexDirection='column' alignItems='center' justifyContent='space-between'>
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