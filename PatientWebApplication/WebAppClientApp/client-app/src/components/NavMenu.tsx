import * as React from "react";
import {
  Collapse,
  Container,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem,
  NavLink,
  Button,
} from "reactstrap";
import { Link } from "react-router-dom";
import "./NavMenu.css";

export default class NavMenu extends React.PureComponent<
  {},
  { isOpen: boolean }
> {
  public state = {
    isOpen: false,
  };

  public logout() {
    localStorage.setItem("token", "");
    localStorage.setItem("patientId", "");
    localStorage.setItem("role", "");
    window.location.href = "" + process.env.REACT_APP_BASE_URL;
  }

  public render() {
    return (
      <header>
        <Navbar
          className="navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow"
          light
        >
          <Container>
            <NavbarToggler onClick={this.toggle} className="mr-2" />
            <Collapse
              className="d-sm-inline-flex flex-sm-row-reverse"
              isOpen={this.state.isOpen}
              navbar
            >
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  {localStorage.getItem("role") === "patient" ? (
                    <NavLink
                      tag={Link}
                      className="text-dark"
                      to="/patient-homepage"
                    >
                      Homepage
                    </NavLink>
                  ) : null}
                </NavItem>
                <NavItem>
                  {localStorage.getItem("role") === "admin" ? (
                    <NavLink
                      tag={Link}
                      className="text-dark"
                      to="/admin-feedback"
                    >
                      Homepage
                    </NavLink>
                  ) : null}
                </NavItem>
                <NavItem>
                  {localStorage.getItem("role") === "patient" ? (
                    <NavLink
                      tag={Link}
                      className="text-dark"
                      to="/prescriptions-simple"
                    >
                      Prescriptions Search
                    </NavLink>
                  ) : null}
                </NavItem>
                <NavItem>
                  {localStorage.getItem("role") === "patient" ? (
                    <NavLink
                      tag={Link}
                      className="text-dark"
                      to="/reports-simple"
                    >
                      Appointment Reports
                    </NavLink>
                  ) : null}
                </NavItem>
                <NavItem>
                  {localStorage.getItem("role") === "patient" ? (
                    <NavLink
                      tag={Link}
                      className="text-dark"
                      to="/my-information"
                    >
                      My Information
                    </NavLink>
                  ) : null}
                </NavItem>
                <NavItem>
                  {localStorage.getItem("role") === "admin" ? (
                    <NavLink
                      tag={Link}
                      className="text-dark"
                      to="/rates-doctor"
                    >
                      Doctors Rating
                    </NavLink>
                  ) : null}
                </NavItem>
                <NavItem>
                  {localStorage.getItem("role") === "admin" ? (
                    <NavLink
                      tag={Link}
                      className="text-dark"
                      to="/rates-general"
                    >
                      Hospital Rating
                    </NavLink>
                  ) : null}
                </NavItem>
                <NavItem>
                  {localStorage.getItem("role") === "patient" ? (
                    <NavLink
                      tag={Link}
                      className="text-dark"
                      to="/my-appointments"
                    >
                      My Appointments
                    </NavLink>
                  ) : null}
                </NavItem>
                <NavItem>
                  {localStorage.getItem("role") === "patient" ? (
                    <NavLink
                      tag={Link}
                      className="text-dark"
                      to="/create-feedback"
                    >
                      My Feedback
                    </NavLink>
                  ) : null}
                </NavItem>
                <NavItem>
                  {localStorage.getItem("role") === "admin" ? (
                    <NavLink
                      tag={Link}
                      className="text-dark"
                      to="/malicious-patient"
                    >
                      Malicious patient
                    </NavLink>
                  ) : null}
                </NavItem>
                <NavItem>
                  {localStorage.getItem("role") === "admin" ? (
                    <NavLink
                      tag={Link}
                      className="text-dark"
                      to="/event-statistics"
                    >
                      Event Statistics
                    </NavLink>
                  ) : null}
                </NavItem>
                <NavItem>
                  {localStorage.getItem("token") === "" ? null : (
                    <Button
                      className="btn btn-lg btn-primary"
                      onClick={this.logout.bind(this)}
                      id="logout"
                    >
                      Logout
                    </Button>
                  )}
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
      isOpen: !this.state.isOpen,
    });
  };
}
