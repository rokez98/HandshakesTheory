import { handleActions, combineActions } from 'redux-actions'
import { searchResultsActions } from '..'
import { searchFormActions } from '../../search-form'

const defaultState = false

export default handleActions(
  {
    [searchFormActions.sendSearchSuccess](state, action) {
      return true
    },
    [combineActions(
      searchFormActions.sendSearchFailed,
      searchFormActions.sendSearchRequest,
      searchResultsActions.resetSearchResults
    )](state, action) {
      return false
    },
  },
  defaultState
)
