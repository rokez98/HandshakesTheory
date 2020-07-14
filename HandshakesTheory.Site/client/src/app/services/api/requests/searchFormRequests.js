export const sendSearchRequest = (data) => ({
  url: `api/vk/search`,
  method: 'post',
  data
})