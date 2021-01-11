import reducer from '../reducers/reducer';
import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import thunk from 'redux-thunk'

const initalState = {

}

const middleware = [thunk]

const store = createStore(reducer, initalState, compose(applyMiddleware(...middleware)))

export default store;