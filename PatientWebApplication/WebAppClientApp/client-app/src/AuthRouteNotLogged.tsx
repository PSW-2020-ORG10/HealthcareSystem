import * as React from "react";
import { RouteComponentProps } from "react-router-dom";
import { Route, Redirect } from "react-router";

interface Props {
  Component: React.FC<RouteComponentProps>;
  path: string;
  exact?: boolean;
}

export const AuthRouteNotLogged = ({
  Component,
  path,
  exact = false,
}: Props): JSX.Element => {
  console.log("Usao u AuthRouteNotLoggedIn ");
  const isAuthed =
    localStorage.getItem("token") === "" ||
    localStorage.getItem("token") === null;
  const isNotLogged =
    localStorage.getItem("role") === "" ||
    localStorage.getItem("role") === null;
  const message = "";
  return (
    <Route
      exact={exact}
      path={path}
      render={(props: RouteComponentProps) =>
        isAuthed && isNotLogged ? (
          <Component {...props} />
        ) : localStorage.getItem("role") === "patient" ? (
          <Redirect
            to={{
              pathname: "/patient-homepage",
              state: {
                message,
                requestedPath: path,
              },
            }}
          />
        ) : (
          <Redirect
            to={{
              pathname: "/admin-feedback",
              state: {
                message,
                requestedPath: path,
              },
            }}
          />
        )
      }
    />
  );
};
