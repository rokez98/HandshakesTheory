import React, { useState } from 'react'

import { TextField, Typography, Box, InputAdornment } from '@material-ui/core'
import Close from '@material-ui/icons/Close'
import Check from '@material-ui/icons/Check'

import { searchFormService } from '../..'

const UserField = ({ label, user, onChange }) => {
  const handleChange = async e => {
    const result = await searchFormService.getUser(e.target.value)

    onChange(result)
  }

  return (
    <Box mt={1} mb={1} display='flex'>
      <TextField
        fullWidth
        variant='outlined'
        size='small'
        label={label}
        onChange={handleChange}
        InputProps={{
          startAdornment: (
            <Typography>vk.com/</Typography>
          ),
          endAdornment: (
            <InputAdornment position='end'>
              {user ?
                <Box display='flex' alignItems='center'>
                  <Typography>{`${user.FirstName} ${user.LastName}`}</Typography>
                  <Check />
                </Box> :
                <Close color='error' />
              }
            </InputAdornment>
          )
        }}
      />
    </Box>
  )
}

export default UserField