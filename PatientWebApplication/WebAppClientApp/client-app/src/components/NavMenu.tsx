import * as React from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink, Button } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export default class NavMenu extends React.PureComponent<{}, { isOpen: boolean }> {
    public state = {
        isOpen: false
    };

    public logout(){
        localStorage.setItem('token', '');
        localStorage.setItem('patientId', '');
        localStorage.setItem('role', '');
        window.location.href = "http://localhost:3000";
    }

    public render() {
        return (
            <header>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow" light>
                    <Container>                     
                        <NavbarToggler onClick={this.toggle} className="mr-2"/>
                        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={this.state.isOpen} navbar>
                            <ul className="navbar-nav flex-grow">
                                <NavItem>
                                    {localStorage.getItem("role") === "patient" ? (<NavLink tag={Link} className="text-dark" to="/patient-homepage">Homepage</NavLink>) : null                                          
                                    }                                    
                                </NavItem>
                                <NavItem>
                                    {localStorage.getItem("role") === "admin" ? (<NavLink tag={Link} className="text-dark" to="/admin-feedback">Homepage</NavLink>) : null                                          
                                    }                                                                 
                                </NavItem>
                                {/*<NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/patient-feedback">Feedback</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/admin-feedback">Admin Feedback</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/create-feedback">Create feedback</NavLink>
                                </NavItem>*/}
                                <NavItem>
                                    {localStorage.getItem("role") === "patient" ? (<NavLink tag={Link} className="text-dark" to="/prescriptions-simple">Prescriptions Search</NavLink>) : null                                          
                                    }                                    
                                </NavItem>
                                <NavItem>
                                    {localStorage.getItem("role") === "patient" ? (<NavLink tag={Link} className="text-dark" to="/reports-simple">Appointment Reports Search</NavLink>) : null                                          
                                    }                                   
                                </NavItem>
                                {/*<NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/register-patient">Patient Registration</NavLink>
                                </NavItem>*/}
                                <NavItem>
                                    {localStorage.getItem("role") === "patient" ? (<NavLink tag={Link} className="text-dark" to="/my-information">My Information</NavLink>) : null                                          
                                    }                                                                 
                                </NavItem>
                                {/*<NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/create-survey">Create Survey</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/rates-doctor">Doctors Rating</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/rates-general">Hospital Rating</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/prescriptions-advanced">Advanced Prescriptions Search</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/appointments-advanced">Advanced Appointments Search</NavLink>
                                </NavItem>*/}
                                <NavItem>
                                    {localStorage.getItem("role") === "admin" ? (<NavLink tag={Link} className="text-dark" to="/rates-doctor">Doctors Rating</NavLink>) : null                                          
                                    }                                                                 
                                </NavItem>
                                <NavItem>
                                    {localStorage.getItem("role") === "admin" ? (<NavLink tag={Link} className="text-dark" to="/rates-general">Hospital Rating</NavLink>) : null                                          
                                    }                                                                 
                                </NavItem>
                                <NavItem>
                                    {localStorage.getItem("role") === "patient" ? (<NavLink tag={Link} className="text-dark" to="/my-appointments">My Appointments</NavLink>) : null                                          
                                    }                                                                   
                                </NavItem>
                                <NavItem>
                                    {localStorage.getItem("role") === "patient" ? (<NavLink tag={Link} className="text-dark" to="/create-feedback">My Feedback</NavLink>) : null                                          
                                    }
                                </NavItem>
                                <NavItem>
                                    {localStorage.getItem("role") === "admin" ? (<NavLink tag={Link} className="text-dark" to="/malicious-patient">Malicious patient</NavLink>) : null                                          
                                    }
                                </NavItem>                     
                                {/*<NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/malicious-patient">Malicious patient</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/schedule-appointment">Schedule appointments</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/choose-appointment-type">Schedule Appointment</NavLink>
                                </NavItem>*/}
                                <NavItem>
                                    {localStorage.getItem("token") === "" ? null : 
                                        (<Button className="btn btn-lg btn-primary" onClick={this.logout.bind(this)}>Logout</Button>)
                                    }
                                </NavItem>
                            </ul>
                        </Collapse>
                    </Container>
                </Navbar>
            </header>
        );
    }

    private toggle = () => {
        this.setState({
            isOpen: !this.state.isOpen
        });
    }
}
