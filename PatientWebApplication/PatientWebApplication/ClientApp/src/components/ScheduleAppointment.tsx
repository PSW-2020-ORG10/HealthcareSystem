import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as CounterStore from '../store/Counter';
import Header from './Header';
import ScheduleAppointmentBody from './ScheduleAppointmentBody';

type CounterProps =
    CounterStore.CounterState &
    typeof CounterStore.actionCreators &
    RouteComponentProps<{}>;

class ScheduleAppointment extends React.PureComponent<CounterProps> {
    state = {
        modalShow: false
    };

    render() {
        return (
            <React.Fragment>
                <Header title="Schedule appointments" description="Schedule doctor appointment." />
                <ScheduleAppointmentBody/>
            </React.Fragment>
        );
    }

};

export default connect(
    (state: ApplicationState) => state.counter,
    CounterStore.actionCreators
)(ScheduleAppointment);
