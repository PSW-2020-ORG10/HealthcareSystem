import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as CounterStore from '../store/Counter';
import Header from './Header';
import PrescriptionsSearchSimpleTable from './PrescriptionsSearchSimpleTable';
import PrescriptionsSearchAdvancedTable from './PrescriptionsSearchAdvancedTable';

type CounterProps =
    CounterStore.CounterState &
    typeof CounterStore.actionCreators &
    RouteComponentProps<{}>;


class PrescriptionsSimple extends React.PureComponent<CounterProps> {
    state = {
        showSimple: true
    };

    public render() {
        return (
            <React.Fragment>
                <Header title="Prescriptions Search" description="Search prescriptions." />
                <br />
                {this.state.showSimple ? <button className="btn-lg btn-primary" onClick={this.showAdvanced.bind(this)}>Advanced Search</button> : <button className="btn-lg btn-primary" onClick={this.showSimple.bind(this)}>Simple Search</button>}
                {this.state.showSimple ? <PrescriptionsSearchSimpleTable /> : <PrescriptionsSearchAdvancedTable />}
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
)(PrescriptionsSimple);