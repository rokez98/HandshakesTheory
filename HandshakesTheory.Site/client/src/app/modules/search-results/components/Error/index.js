import React from 'react'
import { Typography, Paper, withStyles, Fade } from '@material-ui/core'

import styles from './styles'

const Error = ({ classes }) => {
  return (
    <Fade in={true} timeout={500}>
      <Paper className={classes.banner}>
        <Typography variant='h4' align='center'>
          Oops! Something went wrong!
      </Typography>
        <Typography variant='body1' align='center'>
          Unfortunately, the site is in beta testing and can lag. We apologize for these inconveniences.
      </Typography>
      </Paper>
    </Fade>
  )
}

export default withStyles(styles)(Error)