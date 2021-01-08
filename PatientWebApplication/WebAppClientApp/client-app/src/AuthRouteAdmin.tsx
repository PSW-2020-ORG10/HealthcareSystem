import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';
import { Route, Redirect } from 'react-router';

interface Props {
	Component: React.FC<RouteComponentProps>
	path: string;
	exact?: boolean;
};

export const AuthRouteAdmin = ({ Component, path, exact = false }: Props): JSX.Element => {
	console.log("Usao u AuthRouteAdmin")
	const isAuthed = !!localStorage.getItem("token");
    const isAdmin = localStorage.getItem('role') === 'admin'
	const message = 'Please log in to view this page'
	return (
		<Route
			exact={exact}
			path={path}
			render={(props: RouteComponentProps) =>
				isAuthed && isAdmin ? (
					<Component {...props} />
				) : (
					localStorage.getItem('role') === 'patient' ? <Redirect
					to={{
						pathname: "/my-appointments",
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