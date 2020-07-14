import React from 'react'
import { Typography, Paper, withStyles, Fade } from '@material-ui/core'

import styles from './styles'

const NoLinksFound = ({ classes }) => {
  return (
    <Fade in={true} timeout={500}>
      <Paper className={classes.banner}>
        <Typography variant='h4' align='center'>
          No links
      </Typography>
        <Typography variant='body1' align='center'>
          No links found. Try increasing maximum path length.
      </Typography>
      </Paper>
    </Fade>
  )
}

export default withStyles(styles)(NoLinksFound)