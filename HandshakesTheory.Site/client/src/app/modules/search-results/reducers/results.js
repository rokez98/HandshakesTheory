import { handleActions, combineActions } from 'redux-actions'
import { searchResultsActions } from '..'
import { searchFormActions } from '../../search-form'

const defaultState = []

export default handleActions(
  {
    [searchFormActions.sendSearchSuccess](state, action) {
      return action.response.data
    },
    [combineActions(
      searchFormActions.sendSearchRequest,
      searchResultsActions.resetSearchResults
    )](state, action) {
      return defaultState
    },
  },
  defaultState
)
