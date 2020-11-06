import React, { Component } from "react"
import { feedbackCreated } from "../actions/actions"
import { connect } from "react-redux"
import "../css/app.css"

class CreateForm extends Component {
    state = {
        message: "",
        isAnonymous: false,
        isPublic: false
    };

    handleChange=(event) => {
        const { name, value, type, checked } = event.target
        type === "checkbox" ? this.setState({
            [name]: checked
        }) : this.setState({
            [name]: value
        })
    }


    render() {
        return (
            <div>
                
                    <h2>Create Feedback</h2>
                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Title:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.message}
                            name="message"
                            placeholder="Message"
                            onChange={this.handleChange}
                        />
                    </div>
                    
                    <div className="field-wrap">
                        <label className="label">
                            <input
                                type="checkbox"
                                name="isAnonymous"
                                checked={this.state.isAnonymous}
                                onChange={this.handleChange}
                            /> Is anonymous?
                        </label>
                    </div>

                    <div className="field-wrap">
                        <label className="label">
                            <input
                                type="checkbox"
                                name="isPublic"
                                checked={this.state.isPublic}
                                onChange={this.handleChange}
                            /> Is public?
                        </label>
                     </div>

                    <div className="btn-wrap align-right">
                        <button disabled={!this.state.message} className="btn btn-primary" onClick={() => this.props.feedbackCreated(this.state)}>Create</button>
                    </div>
                 
            </div>
        )

    }
}

const mapStateToProps = (state) => ({

});

export default connect(mapStateToProps, { feedbackCreated })(CreateForm);