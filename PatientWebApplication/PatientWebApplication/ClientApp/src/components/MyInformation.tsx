import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as CounterStore from '../store/Counter';
import Header from './Header';
import CheckPersonalInformationTable from './CheckPersonalInformationTable';

type CounterProps =
    CounterStore.CounterState &
    typeof CounterStore.actionCreators &
    RouteComponentProps<{}>;

class MyInformation extends React.PureComponent<CounterProps> {
    public render() {
        return (
            <React.Fragment>
                <Header title="My Information" description="See my information." />
                <CheckPersonalInformationTable />
            </React.Fragment>
        );
    }
};

export default connect(
    (state: ApplicationState) => state.counter,
    CounterStore.actionCreators
)(MyInformation);
