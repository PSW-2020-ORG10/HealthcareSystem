import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';
import { Route, Redirect } from 'react-router';

interface Props {
	Component: React.FC<RouteComponentProps>
	path: string;
	exact?: boolean;
};

export const AuthRoutePatient = ({ Component, path, exact = false }: Props): JSX.Element => {
	const isAuthed = !!localStorage.getItem("token");
    const isPatient = localStorage.getItem('role') === 'patient'
	const message = 'Please log in to view this page'
	return (
		<Route
			exact={exact}
			path={path}
			render={(props: RouteComponentProps) =>
				isAuthed && isPatient ? (
					<Component {...props} />
				) : (
					localStorage.getItem('role') === 'admin' ? <Redirect
					to={{
						pathname: "/admin-feedback",
						state: { 
							message, 
							requestedPath: path
						}
					}}
				/> : <Redirect
				to={{
					pathname: "",
					state: { 
						message, 
						requestedPath: path
					}
				}}
			/> 
				)
			}
		/>
	);
};