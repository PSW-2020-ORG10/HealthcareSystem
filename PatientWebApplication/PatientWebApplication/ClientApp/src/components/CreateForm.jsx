import React, { Component } from "react"
import { feedbackCreated } from "../actions2/actions"
import { connect } from "react-redux"

class CreateForm extends Component {
    state = {
        message: "",
        isAnonymous: false,
        isPublic: false
    };

    constructor() {
        super();
    }

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
                <form>
                    <input
                        type="text"
                        value={this.state.message}
                        name="message"
                        placeholder="Message"
                        onChange={this.handleChange}
                    />
                    <br />

                    <label>
                        <input
                            type="checkbox"
                            name="isAnonymous"
                            checked={this.state.isAnonymous}
                            onChange={this.handleChange}
                        /> Is anonymous?
                    </label>

                    <br />

                    <label>
                        <input
                            type="checkbox"
                            name="isPublic"
                            checked={this.state.isPublic}
                            onChange={this.handleChange}
                        /> Is public?
                </label>

                    <br />
                    <button className="btn btn-primary btn-lg" onClick={() => this.props.createFeedback(this.state.message, this.state.isAnonymous, this.state.isPublic)}>Create</button>
                </form>
            </div>
        )

    }
}

const mapStateToProps = (state) => ({

});

export default connect(mapStateToProps, { feedbackCreated })(CreateForm);