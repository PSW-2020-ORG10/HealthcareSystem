import React, { Component } from "react"
import { loadedPublishedFeedback } from "../actions2/actions"
import { connect } from "react-redux"

class PublishedFeedback extends Component {
    componentDidMount() {
        debugger;
        this.props.loadedPublishedFeedback();
        alert("usao");
        console.log(this.props);
    }
    render() {
        debugger;
        if (this.props.publishedFeedbackList === undefined) {
            console.log("null");
            return null;
        }
        const feedbackList = this.props.publishedFeedbackList;
        console.log("dosao");
        return (

            <div>
                {feedbackList.map((f) => (
                    <div key={f.id}>
                        <div className="check-flag">
                            <span >Id</span>
                            <span >Message</span>
                            <span >{f.id}</span>
                            <span >{f.Message}</span>
                        </div>
                    </div>
                ))}



            </div>

        );
    }
        
}


const mapStateToProps = (state) => 
    
    ({ publishedFeedbackList: state.publishedFeedbackList})

export default connect(mapStateToProps, { loadedPublishedFeedback })(PublishedFeedback);