import React, { Component } from "react"
import { feedbackCreated } from "../actions2/actions"
import { connect } from "react-redux"

class CreateForm extends Component {
    render() {
        return (
            <button className="btn btn-primary btn-lg" onClick={() => this.createFeedback(this.props.message)}>Create</button>
        )

    }

    createFeedback(message) {
        console.log(message);
        this.props.feedbackCreated(message)
    }
}

const mapStateToProps = (state) => ({

});

export default connect(mapStateToProps, { feedbackCreated })(CreateForm);