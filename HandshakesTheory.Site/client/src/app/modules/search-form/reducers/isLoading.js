import { handleActions, combineActions } from 'redux-actions'
import { searchFormActions } from '..'

const defaultState = false

export default handleActions(
  {
    [searchFormActions.sendSearchRequest](state, action) {
      return true
    },
    [combineActions(searchFormActions.sendSearchFailed, searchFormActions.sendSearchSuccess)](state, action) {
      return false
    },
  },
  defaultState
)
