import SearchResults from './components/SearchResults'
import * as searchResultsActions from './actions'
import searchResultsReducer from './reducers'
import searchResultsSagas from './sagas'
import * as searchResultsSelectors from './selectors'

export default SearchResults

export {
  searchResultsActions,
  searchResultsReducer,
  searchResultsSagas,
  searchResultsSelectors
}