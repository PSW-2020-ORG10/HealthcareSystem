"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_redux_1 = require("react-redux");
var CounterStore = require("../store/Counter");
var Header_1 = require("./Header");
var DoctorsRatingTable_1 = require("./DoctorsRatingTable");
var DoctorRates = /** @class */ (function (_super) {
    __extends(DoctorRates, _super);
    function DoctorRates() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    DoctorRates.prototype.render = function () {
        return (React.createElement(React.Fragment, null,
            React.createElement(Header_1.default, { title: "Doctor reviews", description: "See what other users think about our doctors." }),
            React.createElement(DoctorsRatingTable_1.default, null)));
    };
    return DoctorRates;
}(React.PureComponent));
;
exports.default = react_redux_1.connect(function (state) { return state.counter; }, CounterStore.actionCreators)(DoctorRates);
//# sourceMappingURL=DoctorRates.js.map