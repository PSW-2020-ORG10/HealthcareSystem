import React, { Component } from "react"
import { patientRegistered } from "../actions/actions"
import { connect } from "react-redux"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import "../css/app.css"

class RegisterPatient extends Component {
    state = {
        firstName: "",
        secondName: "",       
        gender: "Male",
        uniqueCitizensidentityNumber: "",
        dateOfBirth: "",
        phoneNumber: "",
        medicalIdNumber: "",
        allergie: "",
        city: "",
        email: "",
        password: "",
        isMarried: false,
        bornIn: "",
        parentName: "",
        exLastname: "",
        file: null
                
    };

    handleChange = (event) => {
        const { name, value, type, checked } = event.target
        type === "checkbox" ? this.setState({
            [name]: checked
        }) : this.setState({
            [name]: value
        })
    }

    handleChange2 = (event) => {
        this.setState({
            file: URL.createObjectURL(event.target.files[0])
        })
    }

    render() {
       
        return (
            <div>
                <form>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Name:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.firstName}
                            name="firstName"                          
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Surname:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.secondName}
                            name="secondName"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label">Gender: </label>

                        <select
                            className="field"
                            defaultValue={this.state.gender}
                            onChange={this.handleChange}
                            name="gender"
                        >
                            
                            <option value="Male">Male </option>
                            <option value="Female">Female </option>
                        </select>
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Medical Record ID:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.medicalIdNumber}
                            name="medicalIdNumber"
                            onChange={this.handleChange}
                        />
                    </div>
                 

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Birth date:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.dateOfBirth}
                            name="dateOfBirth"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            City:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.city}
                            name="city"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Email:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.email}
                            name="email"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                           Password:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.password}
                            name="password"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Phone:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.phoneNumber}
                            name="phoneNumber"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Born in:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.bornIn}
                            name="bornIn"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Parents name:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.parentName}
                            name="parentName"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Allergie:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.allergie}
                            name="allergie"
                            onChange={this.handleChange}
                        />
                    </div>
                   

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Unique Citizens identity Number:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.uniqueCitizensidentityNumber}
                            name="uniqueCitizensidentityNumber"
                            onChange={this.handleChange}
                        />
                    </div>

                    

                    <div className="field-wrap">
                        <label className="label">
                            <input
                                type="checkbox"
                                name="isMarried"
                                checked={this.state.isMarried}
                                onChange={this.handleChange}
                            /> Married
                        </label>
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Maiden name:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.exLastname}
                            name="exLastname"
                            disabled={((this.state.gender.toString() === "Female") && (this.state.isMarried)) ? "" : "disabled"} 
                            onChange={this.handleChange}
                        />
                    </div>

                    <div>
                        <input type="file" onChange={this.handleChange2} />
                        <img src={this.state.file} className="photo" />
                    </div>

                    
                    <div className="btn-wrap align-right">
                        <button disabled={!this.state.firstName || !this.state.secondName || !this.state.allergie || !this.state.bornIn || !this.state.city || !this.state.dateOfBirth || !this.state.email || !this.state.medicalIdNumber || !this.state.parentName || !this.state.password || !this.state.phoneNumber || !this.state.uniqueCitizensidentityNumber} className="btn btn-primary" onClick={this.createRegistration.bind(this)}>Register</button>
                    </div>
                </form>
            </div>
        )
    }

    createRegistration() {
        toast.configure();

        toast.success("Registration successful!", {
            position: toast.POSITION.TOP_RIGHT
        });



        this.props.patientRegistered(this.state)
    }

}

const mapStateToProps = (state) => ({

});

export default connect(mapStateToProps, { patientRegistered })(RegisterPatient);
