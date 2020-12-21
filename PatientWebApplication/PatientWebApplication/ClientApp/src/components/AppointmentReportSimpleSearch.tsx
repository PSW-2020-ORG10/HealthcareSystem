import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as CounterStore from '../store/Counter';
import AppointmentReportSimpleSearchTable from './AppointmentReportSimpleSearchTable'
import Header from './Header';
import AppointmentsSearchAdvancedTable from './AppointmentsSearchAdvancedTable';

type CounterProps =
    CounterStore.CounterState &
    typeof CounterStore.actionCreators &
    RouteComponentProps<{}>;

class AppointmentReportSimpleSearch extends React.PureComponent<CounterProps> {
    state = {
        showSimple: true
    };
    public render() {
        return (
            <React.Fragment>
                <Header title="Appointments Search" description="Search appointments." />
                <br/>
                {this.state.showSimple ? <button className="btn-lg btn-primary" onClick={this.showAdvanced.bind(this)}>Advanced Search</button> : <button className="btn-lg btn-primary" onClick={this.showSimple.bind(this)}>Simple Search</button>}
                {this.state.showSimple ? <AppointmentReportSimpleSearchTable /> : <AppointmentsSearchAdvancedTable/>}
            </React.Fragment>
        );
    }

    showSimple() {
        this.setState({
            showSimple: true
        })
    }

    showAdvanced() {
        this.setState({
            showSimple: false
        })
    }
};

export default connect(
    (state: ApplicationState) => state.counter,
    CounterStore.actionCreators
)(AppointmentReportSimpleSearch);