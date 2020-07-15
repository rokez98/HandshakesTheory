import React from 'react'
import { connect } from 'react-redux'
import { withRouter  } from 'react-router'

import Navbar from '../modules/navbar'
import SearchForm from '../modules/search-form'
import SearchResults from '../modules/search-results'
import { Box } from '@material-ui/core'

const UI = (props) => {
  return (
    <Box p={1}>
      {/* <Navbar /> */}
      <SearchForm />
      <SearchResults />
    </Box>
  )
}

const mapStateToProps = state => ({
})

export default withRouter(connect(mapStateToProps)(UI))
