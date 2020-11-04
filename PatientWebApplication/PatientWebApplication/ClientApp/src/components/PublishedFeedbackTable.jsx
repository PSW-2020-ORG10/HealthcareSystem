import React, { Component } from "react"
import { loadedPublishedFeedback } from "../actions2/actions"
import { connect } from "react-redux"

class PublishedFeedbackTable extends Component {
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
                    <thead> 
                        <tr>
                            <th>id of feedback</th>
                            <th>message</th>
                        </tr>
                    </thead>
                {feedbackList.map((f) => ( 
                    <tbody key={f.id}>
                        <tr key={f.id}>
                            <td  >{f.id}</td >
                            <td  >{f.message}</td >
                        </tr> 
                    </tbody>
                ))}
                </table>

            </div>
            

        );
    }
        
}


const mapStateToProps = (state) => 
    
    ({ publishedFeedbackList: state.reducer.publishedFeedbackList})

export default connect(mapStateToProps, { loadedPublishedFeedback })(PublishedFeedbackTable);