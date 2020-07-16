import React, { useState, useEffect } from 'react'
import { Typography, Box, Avatar, Divider, Card, CardHeader, CardMedia, CardContent, CardActions, IconButton, withStyles } from '@material-ui/core'
import LocationCity from '@material-ui/icons/LocationCity'
import People from '@material-ui/icons/People'

import { getUser } from '../../services'

import styles from './styles'

const VkUserDetails = ({ classes, Id }) => {
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
    <Card className={classes.card}>
      <CardHeader className={classes.header} titleTypographyProps={{ variant: 'body2' }} title={`${user.FirstName} ${user.LastName}`} subheader={user.Status} />
      <Divider />
      <CardMedia>
        <Avatar style={{ width: 150, height: 150 }} variant='square' src={user.LargePhotoUrl} />
      </CardMedia>
      <CardContent className={classes.content}>
        {user.Location &&
          <Box title='Location' display='flex' alignItems='center'>
            <LocationCity className={classes.icon} />
            <Typography variant='caption'>{user.Location}</Typography>
          </Box>
        }
        {user.Followers !== undefined &&
          <Box title='Followers count' display='flex' alignItems='center'>
            <People className={classes.icon}  />
            <Typography variant='caption'>{user.Followers} followers</Typography>
          </Box>
        }
        {user.Friends !== undefined &&
          <Box title='Friends count' display='flex' alignItems='center'>
            <People className={classes.icon} />
            <Typography variant='caption'>{user.Friends} friends</Typography>
          </Box>
        }
      </CardContent>
      <Divider />
      <CardActions>
        {user.Vk && <IconButton size='small' href={user.Vk} target='_blank' title={'VK link'} ><img style={{ width: 20, height: 20 }} src='content/social/vk.svg' /></IconButton>}
        {user.Facebook && <IconButton size='small' href={user.Facebook} target='_blank' title={'Facebook link'}><img style={{ width: 20, height: 20 }} src='content/social/facebook.svg' /></IconButton>}
        {user.Skype && <IconButton size='small' href={user.Skype} target='_blank' title={'Skype link'}><img style={{ width: 20, height: 20 }} src='content/social/skype.svg' /></IconButton>}
        {user.Instagram && <IconButton size='small' href={user.Instagram} target='_blank' title={'Instagram link'}><img style={{ width: 20, height: 20 }} src='content/social/instagram.svg' /></IconButton>}
        {user.Twitter && <IconButton size='small' href={user.Twitter} target='_blank' title={'Twitter link'}><img style={{ width: 20, height: 20 }} src='content/social/twitter.svg' /></IconButton>}
      </CardActions>
    </Card>
  )
}

export default withStyles(styles)(VkUserDetails)