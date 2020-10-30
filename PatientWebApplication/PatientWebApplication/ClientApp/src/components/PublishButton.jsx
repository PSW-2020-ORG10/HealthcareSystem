import React, { Component } from "react";
import { feedbackPublished } from "../actions/actions";
import { connect } from "react-redux";

class PublishButton extends Component {
    render() {
        return (
            <button className="btn btn-info btn-lg" onClick={() => this.logProp(this.props.feedbackId)}>Publish</button>    
        )
    }

    logProp(id) {
        console.log(id);
        this.props.feedbackPublished(id)
    }
}

const mapStateToProps = (state) => ({

});

export default connect(mapStateToProps, { feedbackPublished })(PublishButton);