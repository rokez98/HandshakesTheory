import { all } from 'redux-saga/effects'

import watchRequest from './watchRequest'

function * rootSaga () {
  yield all([
    watchRequest()
  ])
}

export default rootSaga
