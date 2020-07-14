const makeGetUserRequestUrl = (id) => {
  return 'https://api.vk.com/method/users.get?v=5.120&access_token=7eba5ce87eba5ce87eba5ce8387edb972177eba7eba5ce824130ea25655c2066c78261d&user_ids=' + id + '&fields=bdate,photo_100,education&callback=?';
}

export const getUser = async (id) => {
  return new Promise((resolve) => {
    $.getJSON(
      makeGetUserRequestUrl(id),
      function (result) {
        if (result.error || !result.response.length) {
          return resolve(undefined)
        }
        else {
          const user = result.response[0]

          resolve({
            Id: user.id,
            FirstName: user.first_name,
            LastName: user.last_name,
            PhotoUrl: user.photo_100
          })
        }
      })
  })
}