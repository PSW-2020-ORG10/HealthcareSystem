import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as CounterStore from '../store/Counter';
import AppointmentReportSimpleSearchTable from './AppointmentReportSimpleSearchTable'
import Header from './Header';

type CounterProps =
    CounterStore.CounterState &
    typeof CounterStore.actionCreators &
    RouteComponentProps<{}>;

class AppointmentReportSimpleSearch extends React.PureComponent<CounterProps> {
    public render() {
        return (
            <React.Fragment>
                <Header title="Simple Appointments Search" description="Search appointments." />
                <AppointmentReportSimpleSearchTable/>
            </React.Fragment>
        );
    }
};

export default connect(
    (state: ApplicationState) => state.counter,
    CounterStore.actionCreators
)(AppointmentReportSimpleSearch);