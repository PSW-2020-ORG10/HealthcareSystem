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
var PrescriptionsSearchSimpleTable_1 = require("./PrescriptionsSearchSimpleTable");
var PrescriptionsSimple = /** @class */ (function (_super) {
    __extends(PrescriptionsSimple, _super);
    function PrescriptionsSimple() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    PrescriptionsSimple.prototype.render = function () {
        return (React.createElement(React.Fragment, null,
            React.createElement(Header_1.default, { title: "Simple Prescriptions Search", description: "Search prescriptions." }),
            React.createElement(PrescriptionsSearchSimpleTable_1.default, null)));
    };
    return PrescriptionsSimple;
}(React.PureComponent));
;
exports.default = react_redux_1.connect(function (state) { return state.counter; }, CounterStore.actionCreators)(PrescriptionsSimple);
//# sourceMappingURL=PrescriptionsSimple.js.map