import React, { Component } from "react"
import { feedbackPublished } from "../actions/actions"
import { connect } from "react-redux"
import { ToastContainer, toast } from 'react-toastify'; 
import 'react-toastify/dist/ReactToastify.css'; 

class PublishButton extends Component {

   
    render() {
        return (
            <React.Fragment>
                <button className="btn btn-primary" disabled={this.props.feedback.isPublished || !this.props.feedback.isPublic} onClick={this.publishFeedback.bind(this)}>Publish</button>  
            </React.Fragment>
        )
    }

    publishFeedback() {
        toast.configure();

        toast.success("Feedback successfully published!", {
            position: toast.POSITION.TOP_RIGHT
        });

        this.props.feedbackPublished(this.props.feedback.id)
    }
}

const mapStateToProps = (state) => ({
    
});

export default connect(mapStateToProps, { feedbackPublished })(PublishButton);