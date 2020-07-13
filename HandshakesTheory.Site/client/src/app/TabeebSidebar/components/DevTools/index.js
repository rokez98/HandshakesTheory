import React from 'react'
import {createDevTools} from 'redux-devtools'
import LogMonitor from 'redux-devtools-log-monitor'
import DockMonitor from 'redux-devtools-dock-monitor'

const DevTools = createDevTools(
  <DockMonitor
    toggleVisibilityKey='alt-h'
    changePositionKey='alt-q'
    defaultIsVisible={false}
  >
    <LogMonitor theme='tomorrow' />
  </DockMonitor>
)

export default DevTools
