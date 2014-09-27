class Shape implements IShape {
    public pointX: number;
    public pointY: number;

    constructor(pX: number, pY: number) {
        this.pointX = pX;
        this.pointY = pY;
    }

    getArea(): number {
        return 0;
    }
} 