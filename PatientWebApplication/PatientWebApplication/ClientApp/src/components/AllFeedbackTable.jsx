import React, { Component } from "react"
import { loadedAllFeedback } from "../actions/actions"
import { connect } from "react-redux"
import PublishButton from "./PublishButton";
import { wrap } from "module";
import { formatDate } from "../utilities/Utilities"



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
                <table className='table allFeedback' >
                    <thead>
                        <tr>
                            <th style={{ textAlign: "left" , width: '35%' }}> Message</th>
                            <th style={{ textAlign: "center" }}>Created</th>
                            <th style={{ textAlign: "center" }}>Patient</th>
                            <th> </th>
                        </tr>
                    </thead>
                    {feedbackList.map((f) => (
                        <tbody key={f.id}>
                            <tr key={f.id}>
                                <td style={{ flexWrap: "wrap", wordWrap: "break-word", wordBreak: "break-word", width: '35%' }}>{f.message}</td >
                                <td style={{ textAlign: "center" }} > {formatDate(f.date)}</td >
                                <td style={{ textAlign: "center" }}>{f.isAnonymous ? "ANONYMOUS" : [f.patient.firstName, ' ', f.patient.secondName].join('')}</td >
                                <td style={{ textAlign: "center" }} ><PublishButton feedback={f}> </PublishButton></td >
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