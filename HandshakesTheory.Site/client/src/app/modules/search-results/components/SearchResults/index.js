import React from 'react'
import { connect } from 'react-redux'

import { Box } from '@material-ui/core'

import Error from '../Error'
import Result from '../Result'
import Success from '../Success'
import NoLinks from '../NoLinksFound'

import { searchResultsSelectors } from '../..'

const SearchResults = ({ isError, isSuccess, results }) => {
  return (
    <Box display='flex' flexDirection='column' alignItems='stretch'>
      {isError && <Error />}
      {isSuccess && results.length && <Success />}
      {isSuccess && !results.length && <NoLinks />}
      <Box display='flex' flexDirection='column' alignItems='stretch'>
        {results.map((result, index) => <Result key={index} result={result} />)}
      </Box>
    </Box>
  )
}

const mapStateToProps = (state) => {
  return {
    isError: searchResultsSelectors.getIsError(state),
    isSuccess: searchResultsSelectors.getIsSuccess(state),
    results: searchResultsSelectors.getSearchResults(state)
  }
}

export default connect(mapStateToProps)(SearchResults)