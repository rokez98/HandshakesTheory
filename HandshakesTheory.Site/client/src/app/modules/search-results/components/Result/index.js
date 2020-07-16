import React, { useState } from 'react'
import { Box, Avatar, Typography, Fade, withStyles } from '@material-ui/core'

import Accordion from '@material-ui/core/Accordion'
import AccordionSummary from '@material-ui/core/AccordionSummary'
import AccordionDetails from '@material-ui/core/AccordionDetails'

import ExpandMoreIcon from '@material-ui/icons/ExpandMore'
import VkUser from '../../../shared/components/VkUser'
import VkUserDetails from '../../../shared/components/VkUserDetails'
import styles from './styles'

const Result = ({ classes, result }) => {
  const [expanded, setExpanded] = useState(false)

  const onExpand = () => {
    setExpanded(!expanded)
  }

  return (
    <Accordion onChange={onExpand}>
      <AccordionSummary
        className={classes.summary}
        title={expanded ? 'Hide details' : 'Show details'}
        expandIcon={<ExpandMoreIcon />}
        style={{
          margin: 0
        }}
      >
        <Box display='flex' alignItems='center' justifyContent='center'>
          {result.map((item, index) => (
            <Fade key={index} in={true} timeout={(index + 1) * 250}>
              <div>
                <VkUser
                  key={item.Id}
                  index={index}
                  showName={false}
                  {...item}
                />
              </div>
            </Fade>
          ))}
        </Box>
      </AccordionSummary>
      <AccordionDetails style={{ overflowX: 'auto' }}>
        <Box display='flex' justifyContent='space-between' alignItems='center' flexGrow={1} >
          {result.map((item, index) => (
            <div style={{ marginRight: 8 }}>
              <VkUserDetails key={index} Id={item.Id} />
            </div>
          ))}
        </Box>
      </AccordionDetails>
    </Accordion>
  )
}

export default withStyles(styles)(Result)