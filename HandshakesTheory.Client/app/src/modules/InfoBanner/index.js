import React from "react";
import PropTypes from "prop-types";

import { withStyles } from "@material-ui/core/styles";

import styles from "./styles";

const InfoBanner = ({ classes }) => (
    <div class="text-center what-do-we-offer" style="padding: 0px 10px;">
        <h1>About app</h1>
        <div class="text-info about-information" style="font-size: 15px;">
            <p>
                We invite you to check how many people you are connected
                to the desired person via the social network VK.
            </p>
        </div>
    </div>
);

InfoBanner.propTypes = {
  classes: PropTypes.object.isRequired
};

export default withStyles(styles)(InfoBanner);