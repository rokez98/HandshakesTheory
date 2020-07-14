import { combineReducers } from 'redux'

import isError from './isError'
import isSuccess from './isSuccess'
import results from './results'

export default combineReducers({
  isError,
  isSuccess,
  results
})
