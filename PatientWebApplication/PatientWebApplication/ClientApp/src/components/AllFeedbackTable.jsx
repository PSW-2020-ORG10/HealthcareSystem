import React, { Component } from "react"
import { loadedAllFeedback } from "../actions2/actions"
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
                            <th>Id of feedback</th>
                            <th>Message</th>
                            <th>IsPublic</th>
                            <th>IsAnonymous</th>
                            <th>Button</th>
                        </tr>
                    </thead>
                    {feedbackList.map((f) => (
                        <tbody key={f.id}>
                            <tr key={f.id}>
                                <td  >{f.id}</td >
                                <td  >{f.message}</td >
                                <td  >{f.isPublic ? "true" : "false"}</td >
                                <td  >{f.isAnonymous ? "ANONYMOUS" : f.patientId}</td >
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