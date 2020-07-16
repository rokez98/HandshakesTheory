export default (theme) => {
  console.log(theme)

  return {
    card: {
      maxWidth: 150
    },
    header: {
      padding: theme.spacing()
    },
    content: {
      padding: theme.spacing()
    },
    icon: {
      fontSize: 12,
      marginRight: theme.spacing() / 2 
    }
  }
}