import React, { useState, useEffect } from 'react'
import { Typography, Fade, Popper, Box, Avatar, Divider, Card, CardHeader, CardMedia, CardContent, CardActions, IconButton } from '@material-ui/core'
import LocationCity from '@material-ui/icons/LocationCity'
import People from '@material-ui/icons/People'

import { getUser } from '../../services'

const VkUserDetails = ({ Id, anchorEl }) => {
  const [isLoading, setIsLoading] = useState(true)
  const [user, setUser] = useState()

  useEffect(() => {
    const getUserData = async (id) => {
      const data = await getUser(id)

      setUser(data)
      setIsLoading(false)
    }

    getUserData(Id)
  }, [])


  return (
    !isLoading && user &&
    <Popper open={true} anchorEl={anchorEl} placement={'top-start'} transition>
      {({ TransitionProps }) => (
        <Fade {...TransitionProps} timeout={350}>
          <Card>
            <CardHeader titleTypographyProps={{ variant: 'body1' }} title={`${user.FirstName} ${user.LastName}`} subheader={user.Status} />
            <Divider />
            <CardMedia>
              <Avatar style={{ width: 200, height: 200 }} variant='square' src={user.LargePhotoUrl} />
            </CardMedia>
            <CardContent>
              {user.Location &&
                <Box title='Location' display='flex' alignItems='center'>
                  <LocationCity />
                  <Typography variant='body2'>{user.Location}</Typography>
                </Box>
              }
              {user.Followers !== undefined &&
                <Box title='Followers count' display='flex' alignItems='center'>
                  <People />
                  <Typography variant='body2'>{user.Followers} followers</Typography>
                </Box>
              }
              {user.Friends !== undefined &&
                <Box title='Friends count' display='flex' alignItems='center'>
                  <People />
                  <Typography variant='body2'>{user.Friends} friends</Typography>
                </Box>
              }
            </CardContent>
            <Divider />
            <CardActions>
              {user.Vk && <IconButton size='small' href={user.Vk} target='_blank' title={'VK link'} ><img style={{ width: 20, height: 20 }} src='content/social/vk.svg' /></IconButton>}
              {user.Facebook && <IconButton size='small' href={user.Facebook} title={'Facebook link'}><img style={{ width: 20, height: 20 }} src='content/social/facebook.svg' /></IconButton>}
              {user.Skype && <IconButton size='small' href={user.Skype} title={'Skype link'}><img style={{ width: 20, height: 20 }} src='content/social/skype.svg' /></IconButton>}
              {user.Instagram && <IconButton size='small' href={user.Instagram} title={'Instagram link'}><img style={{ width: 20, height: 20 }} src='content/social/instagram.svg' /></IconButton>}
              {user.Twitter && <IconButton size='small' href={user.Twitter} title={'Twitter link'}><img style={{ width: 20, height: 20 }} src='content/social/twitter.svg' /></IconButton>}
            </CardActions>
          </Card>
        </Fade>
      )}
    </Popper>
  )
}

export default VkUserDetails