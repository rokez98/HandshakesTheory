import React from "react";
import PropTypes from "prop-types";

import { Paper } from "@material-ui/core";
import Divider from "@material-ui/core/Divider";
import { withStyles } from "@material-ui/core/styles";
import Typography from "@material-ui/core/Typography";

import styles from "./styles";

const Person = ({ classes, avatarUrl, name, profession }) => (
    <div className={classes.recommendedPerson} >
        <div>
            <a href="#input-form">
                <img src={avatarUrl} class="round"/>
            </a>
        </div>
        <div>
            {name}
        </div>
        <div>
            {profession}
        </div>
        <input type="hidden" class="recommended-person-id" value="navalny"/>
    </div>
);

Person.propTypes = {
  classes: PropTypes.object.isRequired,
  avatarUrl: PropTypes.string.isRequired,
  name: PropTypes.string.isRequired,
  profession: PropTypes.string.isRequired,
};

export default withStyles(styles)(Person);