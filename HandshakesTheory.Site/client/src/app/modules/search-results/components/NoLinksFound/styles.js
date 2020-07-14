export default (theme) => {
  const margin = theme.spacing()
  
  return {
    banner: {
      backgroundColor: theme.palette.warning.light,
      backgroundImage: 'url("content/ReachingHands.png")',
      backgroundSize: 'cover',
      backgroundRepeat: 'no-repeat',
      backgroundPosition: 'center',
      backgroundBlendMode: 'soft-light',
      color: theme.palette.warning.contrastText,
      minHeight: 150,
      width: '100%',
      display: 'flex',
      flexDirection: 'column',
      alignItems: 'stretch',
      justifyContent: 'center',
      marginTop: margin,
      marginBottom: margin
    }
  }
}