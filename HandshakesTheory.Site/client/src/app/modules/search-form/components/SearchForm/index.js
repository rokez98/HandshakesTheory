import React, { useState } from 'react'
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'

import { Slider, Button, Typography, Paper, Box } from '@material-ui/core'

import Suggestions from '../../../suggestions'

import { searchFormActions } from '../..'

import UserField from '../UserField'

const SearchForm = ({ searchFormActions: { sendSearchRequest } }) => {
  const [firstUser, setFirstUser] = useState(null)
  const [secondUser, setSecondUser] = useState(null)
  const [maxPathLength, setMaxPathLength] = useState(7)

  const onSubmit = () => {
    sendSearchRequest({
      FirstUser: firstUser,
      SecondUser: secondUser,
      MaxPathLength: maxPathLength
    })
  }

  return (
    <Box mt={1} mb={1}>
      <form>
        <Paper>
          <Box p={2}>
            <Typography variant='h5' align='center'>
              Try it yourself
          </Typography>
            <Typography variant='body1'>
              Enter vk IDs, between which you are looking for link
          </Typography>
            <UserField label='Start user url' user={firstUser} onChange={setFirstUser} />
            <UserField label='End user url' user={secondUser} onChange={setSecondUser} />
            <Typography>
              Set maximal path length (affects work speed)
            </Typography>
            <Slider
              defaultValue={maxPathLength}
              valueLabelDisplay='auto'
              step={1}
              marks
              min={3}
              max={7}
            />
            <Button color='primary' variant='contained' onClick={onSubmit}>
              submit
          </Button>
          </Box>
        </Paper>
      </form>
      <Suggestions onSelect={setSecondUser} />
    </Box>
  )
}

const mapDispatchToProps = (dispatch, props) => ({
  searchFormActions: bindActionCreators(searchFormActions, dispatch)
})

export default connect(null, mapDispatchToProps)(SearchForm)