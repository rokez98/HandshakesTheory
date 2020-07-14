import React from 'react'
import { connect } from 'react-redux'
import { withRouter  } from 'react-router'

import Navbar from '../modules/navbar'
import SearchForm from '../modules/search-form'
import SearchResults from '../modules/search-results'

const UI = (props) => {
  return (
    <>
      {/* <Navbar /> */}
      <SearchForm />
      <SearchResults />
    </>
  )
}

const mapStateToProps = state => ({
})

export default withRouter(connect(mapStateToProps)(UI))
