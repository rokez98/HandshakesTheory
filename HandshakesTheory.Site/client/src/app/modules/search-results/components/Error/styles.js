export default (theme) => {
  const margin = theme.spacing()

  return {
    banner: {  
      backgroundColor: theme.palette.error.dark,
      backgroundImage: 'url("content/Error.png")',
      backgroundRepeat: 'no-repeat',
      backgroundPosition: 'center',
      backgroundBlendMode: 'soft-light',
      color: theme.palette.error.contrastText,
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