import { createAction } from 'redux-actions'

export const sendSearchRequest = createAction('SEND_SEARCH_REQUEST')
export const sendSearchFailed = createAction('SEND_SEARCH_FAILED')
export const sendSearchSuccess = createAction('SEND_SEARCH_SUCCESS')