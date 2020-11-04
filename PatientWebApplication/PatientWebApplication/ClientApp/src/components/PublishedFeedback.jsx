import React, { Component } from "react"
import { loadedPublishedFeedback } from "../actions2/actions"
import { connect } from "react-redux"

class PublishedFeedback extends Component {
    componentDidMount() {
        debugger;
        this.props.loadedPublishedFeedback();       
    }
    render() {
        debugger;
        if (this.props.publishedFeedbackList === undefined) {
            
            return null;
        }
        const feedbackList = this.props.publishedFeedbackList;       
        return (

            <div>
                <table className='table publishedFeedback'>
                    <tr>
                        <th>id of feedback</th>
                        <th>message</th>
                    </tr>
                    {feedbackList.map((f) => (
                   
                        <div className="check-flag">
                            <tr>
                                <td  >{f.id}</td >
                                <td  >{f.message}</td >
                            </tr>
                        
                    </div>
                ))}
                </table>

            </div>
            

        );
    }
        
}


const mapStateToProps = (state) => 
    
    ({ publishedFeedbackList: state.reducer.publishedFeedbackList})

export default connect(mapStateToProps, { loadedPublishedFeedback })(PublishedFeedback);