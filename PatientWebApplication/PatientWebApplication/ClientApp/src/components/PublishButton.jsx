import React, { Component } from "react"
import { feedbackPublished } from "../actions2/actions"
import { connect } from "react-redux"

class PublishButton extends Component {
    render() {
        return (
            <button className="btn btn-secondary" onClick={() => this.props.feedbackPublished(this.props.feedbackId)}>Publish</button>
        )
    }
}

const mapStateToProps = (state) => ({

});

export default connect(mapStateToProps, { feedbackPublished })(PublishButton);