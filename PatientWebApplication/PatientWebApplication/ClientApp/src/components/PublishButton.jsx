import React, { Component } from "react"
import { feedbackPublished } from "../actions2/actions"
import { connect } from "react-redux"

class PublishButton extends Component {

   
    render() {
        return (
            <button className="btn btn-secondary" disabled={this.props.feedback.isPublished || !this.props.feedback.isPublic} onClick={() => this.props.feedbackPublished(this.props.feedback.id)}>Publish</button>  
        )
    }

}

const mapStateToProps = (state) => ({

});

export default connect(mapStateToProps, { feedbackPublished })(PublishButton);