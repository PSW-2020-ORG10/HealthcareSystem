import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as CounterStore from '../store/Counter';
import Header from './Header';
import RecommendedAppointmentScheduling from './RecommendedAppointmentScheduling';

type CounterProps =
    CounterStore.CounterState &
    typeof CounterStore.actionCreators &
    RouteComponentProps<{}>;

class RecommendedAppointment extends React.PureComponent<CounterProps> {
    public render() {
        return (
            <React.Fragment>
                <Header title="Recommended appointment scheduling" description="Schedule appointment." />
                <RecommendedAppointmentScheduling />
            </React.Fragment>
        );
    }
};

export default connect(
    (state: ApplicationState) => state.counter,
    CounterStore.actionCreators
)(RecommendedAppointment);
