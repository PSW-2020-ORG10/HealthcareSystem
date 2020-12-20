import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as CounterStore from '../store/Counter';
import AllPatientsAppointmentsTable from './AllPatientsAppointmentsTable'
import Header from './Header';

type CounterProps =
    CounterStore.CounterState &
    typeof CounterStore.actionCreators &
    RouteComponentProps<{}>;

class AllPatientsAppointments extends React.PureComponent<CounterProps> {
    public render() {
        return (
            <React.Fragment>
                <Header title="My Appointments" description="All of my appointments." />
                <AllPatientsAppointmentsTable />
            </React.Fragment>
        );
    }
};

export default connect(
    (state: ApplicationState) => state.counter,
    CounterStore.actionCreators
)(AllPatientsAppointments);