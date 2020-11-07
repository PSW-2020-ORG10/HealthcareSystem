import React, { Component } from "react"
import { loadedAllFeedback } from "../actions/actions"
import { connect } from "react-redux"
import PublishButton from "./PublishButton";

class AllFeedbackTable extends Component {
    componentDidMount() {
        debugger;
        this.props.loadedAllFeedback();
    }
    render() {
        debugger;
        if (this.props.feedbackList === undefined) {

            return null;
        }
        const feedbackList = this.props.feedbackList;
        return (

            <div>
                <table className='table allFeedback'>
                    <thead>
                        <tr>
                            <th>Message</th>
                            <th>Created</th>
                            <th>Patient</th>
                            <th> </th>
                        </tr>
                    </thead>
                    {feedbackList.map((f) => (
                        <tbody key={f.id}>
                            <tr key={f.id}>
                                <td  >{f.message}</td >
                                <td  > </td >
                                <td  >{f.isAnonymous ? "ANONYMOUS" : [f.patient.firstName, ' ', f.patient.secondName].join('')}</td >
                                <td  ><PublishButton feedback={f}> </PublishButton></td >
                            </tr>
                        </tbody>
                    ))}
                </table>

            </div>


        );
    }

}


const mapStateToProps = (state) =>

    ({ feedbackList: state.reducer.feedbackList })

export default connect(mapStateToProps, { loadedAllFeedback })(AllFeedbackTable);