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
var Util_1 = require("./Util");
var Layer_1 = require("./Layer");
var Global_1 = require("./Global");
var FastLayer = (function (_super) {
    __extends(FastLayer, _super);
    function FastLayer(attrs) {
        var _this = _super.call(this, attrs) || this;
        _this.listening(false);
        Util_1.Util.warn('Konva.Fast layer is deprecated. Please use "new Konva.Layer({ listening: false })" instead.');
        return _this;
    }
    return FastLayer;
}(Layer_1.Layer));
exports.FastLayer = FastLayer;
FastLayer.prototype.nodeType = 'FastLayer';
Global_1._registerNode(FastLayer);
Util_1.Collection.mapMethods(FastLayer);