import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as CounterStore from '../store/Counter';
import EventStatisticsTable from './EventStatisticsTable';
import Header from './Header';

type CounterProps =
    CounterStore.CounterState &
    typeof CounterStore.actionCreators &
    RouteComponentProps<{}>;

class EventStatistics extends React.PureComponent<CounterProps> {
    public render() {
        return (
            <React.Fragment>
                <Header title="Fill survey" description="Please rate us." />
                <EventStatisticsTable />
            </React.Fragment>
        );
    }
};

export default connect(
    (state: ApplicationState) => state.counter,
    CounterStore.actionCreators
)(EventStatistics);
