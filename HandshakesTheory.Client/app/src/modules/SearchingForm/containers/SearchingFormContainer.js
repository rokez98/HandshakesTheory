import React from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { change, formValueSelector } from "redux-form";
import PropTypes from "prop-types";

import SearchingForm from "./../components/index";
import Auth from "./../../../../services/Auth";

import * as loginActions from "./../actions/LoginActions";
import { getIsValidating } from "./../selectors/LoginFormSelectors";

class SearchingFormContainer extends React.Component {
  render() {
    const props = {
    };
    return <SearchingForm {...props} />;
  }
}

SearchingFormContainer.propTypes = {
};

const mapStateToProps = state => ({
});

const mapDispatchToProps = dispatch => ({
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(SearchingFormContainer);