import React from 'react'
import { Typography, Paper, withStyles, Fade } from '@material-ui/core'

import styles from './styles'

const Success = ({ classes }) => {
  return (
    <Fade in={true} timeout={500}>
      <Paper className={classes.banner}>
        <Typography variant='h4' align='center'>
          Success
      </Typography>
        <Typography variant='body1' align='center'>
          See results below
      </Typography>
      </Paper>
    </Fade>
  )
}

export default withStyles(styles)(Success)