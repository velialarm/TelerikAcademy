var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var figures;
(function (figures) {
    var Rect = (function (_super) {
        __extends(Rect, _super);
        function Rect(pX, pY, width, heigth) {
            _super.call(this, pX, pY);
            this.width = width;
            this.heigth = heigth;
        }
        Rect.prototype.getArea = function () {
            return (this.width + this.heigth) * 2;
        };
        return Rect;
    })(Shape);
    figures.Rect = Rect;

    var Circle = (function (_super) {
        __extends(Circle, _super);
        function Circle(pX, pY, radius) {
            _super.call(this, pX, pY);
            this.radius = radius;
        }
        Circle.prototype.getArea = function () {
            return Math.PI * this.radius * 2;
        };
        return Circle;
    })(Shape);
    figures.Circle = Circle;
})(figures || (figures = {}));
//# sourceMappingURL=Figure.js.map
