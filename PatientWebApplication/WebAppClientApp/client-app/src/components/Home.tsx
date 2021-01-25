import * as React from 'react';
import { connect } from 'react-redux';
import Header from './Header';
import Login from './Login'

const Home = () => (
  <React.Fragment>
                <Header title="Welcome to Health Clinic!" description="Please Login" />
                <Login/>  
            </React.Fragment>
);

export default connect()(Home);
