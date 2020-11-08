import React, { Component } from "react"
import { loadedPublishedFeedback } from "../actions/actions"
import { connect } from "react-redux"
import { formatDate } from "../utilities/Utilities"

class PublishedFeedbackTable extends Component {
    componentDidMount() {
        debugger;
        this.props.loadedPublishedFeedback();       
    }
    render() {
        debugger;
        if (this.props.publishedFeedbackList === undefined) {
            
            return null;
        }
        const feedbackList = this.props.publishedFeedbackList;       
        return (

            <div className="wrap">
                {feedbackList.map((f) => (
                    <div key={f.Id} className="item-row">
                        <div key={f.Id} className="check-flag">
                            <span className="small-text-label">Name and Surname</span>
                            <span className="small-text-label hours">{ formatDate(f.date) }</span>
                            <span className="check-flag-label">{f.isAnonymous ? "ANONYMOUS" : [f.patient.firstName, ' ', f.patient.secondName].join('')}</span>
                            <textarea className="check-flag-textarea" disabled rows={3} value={f.message}></textarea>
                        </div>
                    </div>
                ))}
            </div>
            

            
            

        );
    }   
}

const mapStateToProps = (state) => 
    
    ({ publishedFeedbackList: state.reducer.publishedFeedbackList})

export default connect(mapStateToProps, { loadedPublishedFeedback })(PublishedFeedbackTable);