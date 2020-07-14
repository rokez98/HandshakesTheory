import Suggestions from './components/Suggestions'
import * as suggestionsActions from './actions'
import suggestionsReducer from './reducers'
import suggestionsSagas from './sagas'
import suggestionsSelectors from './selectors'

export default Suggestions

export {
  suggestionsActions,
  suggestionsReducer,
  suggestionsSagas,
  suggestionsSelectors
}