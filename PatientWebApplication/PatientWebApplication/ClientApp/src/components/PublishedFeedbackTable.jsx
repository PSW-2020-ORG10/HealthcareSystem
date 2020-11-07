import React, { Component } from "react"
import { loadedPublishedFeedback } from "../actions/actions"
import { connect } from "react-redux"

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
                        <div className="check-flag">
                            <span className="small-text-label">Name and Surname</span>
                            <span className="small-text-label hours">{this.formatDate(f.date)}</span>
                            <span className="check-flag-label">{f.isAnonymous ? "ANONYMOUS" : [f.patient.firstName, ' ', f.patient.secondName].join('')}</span>
                            <textarea className="check-flag-textarea" disabled rows={3}>{f.message}</textarea>
                        </div>
                    </div>
                ))}

            

            </div>
            

        );
    }

    formatDate(dateString) {
        var date = new Date(Date.parse(dateString));
        return date.getDate() + "/" + date.getMonth() + "/" + date.getFullYear();
    }        
}

const mapStateToProps = (state) => 
    
    ({ publishedFeedbackList: state.reducer.publishedFeedbackList})

export default connect(mapStateToProps, { loadedPublishedFeedback })(PublishedFeedbackTable);