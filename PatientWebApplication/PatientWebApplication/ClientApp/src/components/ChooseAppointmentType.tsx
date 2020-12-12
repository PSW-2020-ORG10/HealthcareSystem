import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as CounterStore from '../store/Counter';
import AppointmentMenu from './AppointmentMenu'
import Header from './Header';

type CounterProps =
    CounterStore.CounterState &
    typeof CounterStore.actionCreators &
    RouteComponentProps<{}>;

class ChooseAppointmentType extends React.PureComponent<CounterProps> {
    public render() {
        return (
            <React.Fragment>
                <Header title="Schedule appointment" description="Choose way of scheduling." />
                <AppointmentMenu />
            </React.Fragment>
        );
    }
};

export default connect(
    (state: ApplicationState) => state.counter,
    CounterStore.actionCreators
)(ChooseAppointmentType);