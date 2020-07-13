import axios from 'axios'
import _ from 'lodash'

function getHeaders (method, accessToken, customHeaders = {}) {
  let headers = {
    'Content-Type': 'application/json',
    ...customHeaders
  }

  if (_.isEqual('post', _.lowerCase(method))) {
    headers['Accept'] = 'application/json'
  }

  if (_.isString(accessToken)) {
    headers['Authorization'] = `Bearer ${accessToken}`
  }

  if (_.isNull(customHeaders.Authorization)) {
    headers = _.omit(headers, ['Authorization'])
  }

  return headers
}

export default (paramsObj) => {
  const {hostName, accessToken, data} = paramsObj
  return axios({
    ...data,
    headers: getHeaders(data.method, accessToken, data.headers),
    url: (data.url && data.url.indexOf('http') === 0) ? data.url : `${hostName}${data.url}`
  }).then((response) => {
    return response
  }).catch((error) => {
    const {statusText, status} = error.response || {}

    const errorObj = {statusText, status, response: error.response}
    console.error('paramsObj:', paramsObj, '; errorObj:', errorObj)
    throw errorObj
  })
}
