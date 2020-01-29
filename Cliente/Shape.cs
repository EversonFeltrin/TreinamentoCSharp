using System;
using System.Collections.Generic;

namespace Shape
{
    public class Shape
    {

        public double PI = Math.PI;
        public double x,y;

        public Shape() { }


        public Shape(double x,  double y)
        {
            
            this.x = x;

            this.y = y;
        }

        public virtual double Area()
        {
            return x * y;
        }
    }


    public class Circle : Shape 
    {

        public Circle(double r) : base(r, 0) { }
        
        public override double Area()
        {
            return PI * x * y;

        }

    }

}
