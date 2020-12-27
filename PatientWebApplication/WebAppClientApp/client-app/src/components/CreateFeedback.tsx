import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as CounterStore from '../store/Counter';
import Header from './Header';
import CreateForm from './CreateForm';
import PublishedFeedbackTable from './PublishedFeedbackTable'

type CounterProps =
    CounterStore.CounterState &
    typeof CounterStore.actionCreators &
    RouteComponentProps<{}>;

class PatientFeedback extends React.PureComponent<CounterProps> {
    public render() {
        return (
            <React.Fragment>
                <Header title="Send feedback" description="Send your personal feedback." />
                <CreateForm />
                <br/>
                <PublishedFeedbackTable />
            </React.Fragment>
        );
    }
};

export default connect(
    (state: ApplicationState) => state.counter,
    CounterStore.actionCreators
)(PatientFeedback);
