import {combineReducers} from 'redux'
import { connectRouter } from 'connected-react-router'

import { searchResultsReducer as searchResults } from '../../modules/search-results'

export default history => combineReducers({
  router: connectRouter(history),
  searchResults
})
