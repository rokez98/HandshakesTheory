import { call, put, takeEvery } from 'redux-saga/effects'
import { apiRootUrl } from '../../../constants'
import _ from 'lodash'

import ApiService from '../../services/API'
import ApiRequests from '../../services/api/requests'


function * callAPI (action) {
  const data = ApiRequests[_.camelCase(action.type)](action.payload)
  try {
    const response = yield call(ApiService, {
      hostName: apiRootUrl,
      data
    })

    const newType = action.type.replace('_REQUEST', '_SUCCESS')
    yield put({type: newType, response, payload: action.payload})
  } catch (e) {
    const errorModel = {
      type: action.type.replace('_REQUEST', '_FAILED'),
      payload: action.payload,
      message: e.statusText,
      status: e.status,
      response: e.response
    }
    console.error(errorModel)
    yield put(errorModel)
  }
}

export default function * watchRequest () {
  yield takeEvery((action) => /^.*_REQUEST$/.test(action.type), callAPI)
}
