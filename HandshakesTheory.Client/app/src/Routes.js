import React from "react";
import { Route, Switch, Redirect } from "react-router-dom";

import { urls } from "./constants/urls";
import InfoBanner from "./modules/InfoBanner/index";


export const Routes = () => (
  <Switch>
    <Route exact path={urls.root} component={InfoBanner} />

    <Redirect to={urls.notFound} />
  </Switch>
);