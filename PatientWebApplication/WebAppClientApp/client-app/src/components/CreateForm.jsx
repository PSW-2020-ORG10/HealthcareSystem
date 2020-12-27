import React, { Component } from "react"
import { feedbackCreated } from "../actions/actions"
import { connect } from "react-redux"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'; 
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
                            /> Anonymous
                        </label>
                    </div>

                    <div className="field-wrap">
                        <label className="label">
                            <input
                                type="checkbox"
                                name="isPublic"
                                checked={this.state.isPublic}
                                onChange={this.handleChange}
                            /> Public
                        </label>
                     </div>

                    <div className="btn-wrap align-right">
                        <button disabled={!this.state.message || this.state.message.length > 140} className="btn btn-block btn-lg btn-primary" onClick={this.createFeedback.bind(this)}>Create</button>
                    </div>
            </div>
        )

    }

    createFeedback() {
        toast.configure();

        toast.success("Feedback successfully created!", {
            position: toast.POSITION.TOP_RIGHT
        });
        this.props.feedbackCreated(this.state);
        this.setState({
            message: '',
            isAnonymous: false,
            isPublic: false
        })
    }

}

const mapStateToProps = (state) => ({

});

export default connect(mapStateToProps, { feedbackCreated })(CreateForm);