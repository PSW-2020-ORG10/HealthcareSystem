import React, { Component } from "react"
import { loadedPublishedFeedback } from "../actions2/actions"
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
                            <span className="small-text-label">Id</span>
                            <span className="small-text-label hours">Message</span>
                            <span className="check-flag-label">{f.id}</span>
                            <span className="check-flag-label">{f.message}</span>
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