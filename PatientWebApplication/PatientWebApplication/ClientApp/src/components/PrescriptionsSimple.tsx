import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as CounterStore from '../store/Counter';
import Header from './Header';
import PrescriptionsSearchSimpleTable from './PrescriptionsSearchSimpleTable';

type CounterProps =
    CounterStore.CounterState &
    typeof CounterStore.actionCreators &
    RouteComponentProps<{}>;


class PrescriptionsSimple extends React.PureComponent<CounterProps> {
    public render() {
        return (
            <React.Fragment>
                <Header title="Simple Prescriptions Search" description="Search prescriptions." />
                <PrescriptionsSearchSimpleTable />
            </React.Fragment>
        );
    }
};

export default connect(
    (state: ApplicationState) => state.counter,
    CounterStore.actionCreators
)(PrescriptionsSimple);