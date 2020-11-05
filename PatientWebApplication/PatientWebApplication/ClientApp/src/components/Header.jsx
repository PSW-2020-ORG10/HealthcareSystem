import React, { Component } from "react";
import { connect } from "react-redux";

class Header extends Component {
    render() {
        return (
            <header className="header">
                <div className="wrap">
                    <div className="header-blockquote">
                        <h1 className="header-quote">{this.props.title}</h1>
                        <div className="header-cite">- {this.props.description}</div>
                    </div>
                </div>
            </header>
        );
    }
}

const mapStateToProps = (state) => ({

});

export default connect(mapStateToProps, {})(Header);
