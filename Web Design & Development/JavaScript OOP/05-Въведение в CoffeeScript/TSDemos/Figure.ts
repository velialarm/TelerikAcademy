 module figures {
     export class Rect extends Shape {
         public width: number;
         public heigth: number;

         constructor(pX:number, pY:number, width: number, heigth: number) {
             super(pX, pY);
             this.width = width;
             this.heigth = heigth;
         }

         getArea(): number {
             return (this.width + this.heigth) * 2;
         }
     }

     export class Circle extends Shape {
         public radius: number;

         constructor(pX: number, pY: number, radius: number) {
             super(pX, pY);
             this.radius = radius;
         }

         getArea(): number {
             return Math.PI * this.radius * 2;
         }
     } 
 } 