import reducer from '../reducers2/reducer';
import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import thunk from 'redux-thunk'

const initalState = {

}

const middleware = [thunk]

const store = createStore(reducer, initalState, compose(applyMiddleware(...middleware)))

export default store;