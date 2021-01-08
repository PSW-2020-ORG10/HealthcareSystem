import React, { Component } from 'react';
import { Button } from 'reactstrap';
import { userLoggedIn } from '../actions/actions'
import { connect } from "react-redux"
import { checkEmailFormat, showErrorToastEmail, showUnsuccessfulLoginToast } from "../utilities/Utilities"

class Login extends Component {
    state = { 
        email: "",
        password: ""
    }

    handleChange = (event) => {
        var { name, value, type, checked } = event.target
        type === "checkbox" ? this.setState({
            [name]: checked
        }) : this.setState({
            [name]: value
        })
    }

    async login() {
        debugger;
        if (this.state.email !== "" && checkEmailFormat(this.state.email)){
            showErrorToastEmail();
            return;
        }
        var successful = false;
        successful = await this.props.userLoggedIn(this.state);
        if(successful === true){
            if(localStorage.getItem("role") === 'admin'){
                window.location.href = "http://localhost:3000/admin-feedback";
            }else if(localStorage.getItem("role") === 'patient') {
                window.location.href = "http://localhost:3000/patient-homepage";
            }
            return;
        }
        showUnsuccessfulLoginToast();
        return;
    }

    render() { 
        return ( 
            <div>
                <div className="field-wrap row d-flex justify-content-center mt-5">
                    <label className="label text-left mr-2 pt-3" htmlFor="">
                        Email:
                    </label>
                    <input
                        id="email"
                        className="field-center"
                        type="text"
                        value={this.state.email}
                        name="email"
                        onChange={(e) => this.handleChange(e)}
                    />
                </div>

                <div className="field-wrap row d-flex justify-content-center">
                    <label className="label mr-2 pt-3" htmlFor="">
                        Password:
                    </label>
                    <input
                        id="password"
                        className="field-center2"
                        type="password"
                        value={this.state.password}
                        name="password"
                        onChange={(e) => this.handleChange(e)}
                    />
                </div>

                <div className="field-wrap row d-flex justify-content-center">
                    <Button id="submit" className="btn btn-lg btn-primary btn-block button-wrap" disabled={this.state.email === '' || this.state.password === ''} onClick={this.login.bind(this)}>Login</Button>
                </div>

                <div className="field-wrap row d-flex justify-content-center mt-5">
                    <label className="label mr-2 pl-5">
                        Not a member?
                    </label>
                    <a href = "http://localhost:3000/register-patient" className="pl-2">Sign up now.</a>
                </div>
            </div>
        );
    }
}
 
const mapStateToProps = (state) => ({

});

export default connect(mapStateToProps, { userLoggedIn })(Login);