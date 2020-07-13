import React from 'react'
import { connect } from 'react-redux'
import { withRouter  } from 'react-router'

const App = (props) => {
  return (
    <>
      <div>
      </div>
    </>
  )
}

const mapStateToProps = state => ({
})

export default withRouter(connect(mapStateToProps)(App))
