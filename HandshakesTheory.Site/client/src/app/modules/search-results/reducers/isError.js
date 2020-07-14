import { handleActions, combineActions } from 'redux-actions'
import { searchResultsActions } from '..'
import { searchFormActions } from '../../search-form'

const defaultState = false

export default handleActions(
  {
    [searchFormActions.sendSearchFailed](state, action) {
      return true
    },
    [combineActions(
      searchFormActions.sendSearchSuccess,
      searchFormActions.sendSearchRequest,
      searchResultsActions.resetSearchResults
    )](state, action) {
      return false
    },
  },
  defaultState
)
