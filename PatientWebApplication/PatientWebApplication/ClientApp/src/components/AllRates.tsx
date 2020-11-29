import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as CounterStore from '../store/Counter';
import Header from './Header';
import AllRatingTable from './AllRatingTable';

type CounterProps =
    CounterStore.CounterState &
    typeof CounterStore.actionCreators &
    RouteComponentProps<{}>;

class AllRates extends React.PureComponent<CounterProps> {
    public render() {
        return (
            <React.Fragment>
                <Header title="General reviews" description="See what other users think about our hospital." />
                <AllRatingTable />
            </React.Fragment>
        );
    }
};

export default connect(
    (state: ApplicationState) => state.counter,
    CounterStore.actionCreators
)(AllRates);
