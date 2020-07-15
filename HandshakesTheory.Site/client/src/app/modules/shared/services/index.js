const makeGetUserRequestUrl = (id) => {
  return 'https://api.vk.com/method/users.get?v=5.120&access_token=7eba5ce87eba5ce87eba5ce8387edb972177eba7eba5ce824130ea25655c2066c78261d&user_ids=' + id + '&fields=bdate,photo_100,lists,photo_200,education,city,connections,status,country,contacts,counters&callback=?';
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

          const location = []
          if (user.city) {
            location.push(user.city.title)
          }

          if (user.country) {
            location.push(user.country.title)
          }

          resolve({
            Id: user.id,
            Status: user.Status,
            FirstName: user.first_name,
            LastName: user.last_name,
            PhotoUrl: user.photo_100,
            LargePhotoUrl: user.photo_200,
            Followers: user.counters.followers,
            Friends: user.counters.friends,
            Vk: `https://vk.com/id${user.id}`,
            Skype: user.skype && `skype:${user.skype}?call`,
            Instagram: user.instagram && `https://instagram.com/${user.instagram}`,
            Twitter: user.twitter && `https://twitter.com/${user.twitter}`,
            Facebook: user.facebook && `https://twitter.com/${user.facebook}`,
            Location: location.join(', ')
          })
        }
      })
  })
}