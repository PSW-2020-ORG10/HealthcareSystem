import React, { Component } from 'react';
import { Slide } from 'react-slideshow-image';
import 'react-slideshow-image/dist/styles.css'
import { loadedAllMessages, loadedImageForAds, loadedImageForSecondAd, loadedImageForThirdAd } from "../actions/actions"
import { connect } from "react-redux"
import { wrap } from "module";
import axios from "axios";
import CancelAppointmentButton from "./CancelAppointmentButton";
import ReferralModal from "./ReferralModal"
import CreateSurveyForm from "./CreateSurveyForm"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { showErrorToast, checkDateFormat } from "../utilities/Utilities"

class AllMessages extends Component {
    componentDidMount() {
        debugger;
        this.props.loadedAllMessages();
        this.props.loadedImageForAds("hosp5.jpg");    
        this.props.loadedImageForSecondAd("hosp4.jpg");  
        this.props.loadedImageForThirdAd("hosp6.jpg");     
    }
    render() {
        if (this.props.loadedAllMessagesList === undefined) {          
            return null;
        }
        const loadedAllMessagesList = this.props.loadedAllMessagesList;  
        const image = this.props.image;
        const image2 = this.props.image2;
        const image3 = this.props.image3;
        const images = [image, image2, image3];
        debugger;
        return (
            <div>
                 <Slide easing="ease">
                    {loadedAllMessagesList.map((f) => (
                      <div className="each-slide">
                      <div className = "a" style={{'backgroundImage': `url(${'data:image/jpg;base64,' + images[f.id-1]})`}}>
                        <span>{f.text}</span>
                      </div>
                    </div>
                    ))}
                </Slide>
            </div>
        );
    }
    

}

const mapStateToProps = (state) => {
    debugger;
    return ({ loadedAllMessagesList: state.reducer.loadedAllMessagesList, image : state.reducer.loadedImage, image2 : state.reducer.loadedSecondImage, image3 : state.reducer.loadedThirdImage  });
}

export default connect(mapStateToProps, { loadedAllMessages, loadedImageForAds, loadedImageForSecondAd, loadedImageForThirdAd })(AllMessages);