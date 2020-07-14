export default (theme) => {
  const margin = theme.spacing()

  return {
    banner: {
      backgroundColor: theme.palette.success.main,
      backgroundImage: 'url("content/PeopleChain.png")',
      backgroundSize: 'cover',
      backgroundRepeat: 'no-repeat',
      backgroundPosition: 'center',
      backgroundBlendMode: 'soft-light',
      color: theme.palette.success.contrastText,
      minHeight: 150,
      width: '100%',
      display: 'flex',
      flexDirection: 'column',
      alignItems: 'stretch',
      color: theme.palette.primary.contrastText,
      justifyContent: 'center',
      marginTop: margin,
      marginBottom: margin
    }
  }
}