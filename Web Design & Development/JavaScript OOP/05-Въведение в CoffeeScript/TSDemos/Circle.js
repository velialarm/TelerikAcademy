var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Circle = (function (_super) {
    __extends(Circle, _super);
    function Circle() {
        _super.apply(this, arguments);
    }
    Circle.prototype.getArea = function () {
        return Math.PI * this.radius * 2;
    };
    return Circle;
})(Shape);
//# sourceMappingURL=Circle.js.map
