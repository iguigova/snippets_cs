using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegularPolygons
{
    class RegularPolygonBroker
    {
        RegularPolygon polygon = null;

        public RegularPolygonBroker(string polygon_type, double polygon_side)
        {
            switch (polygon_type)
            {
                case "circle": polygon = new Circle(polygon_type, polygon_side); break;
                default: polygon = new RegularPolygon(polygon_type, polygon_side); break;
            }
        }

        public override string ToString()
        {
            return (polygon != null) ? (polygon).ToString() : string.Empty;
        }
    }

    class RegularPolygon
    {
        private const int undefined = -1;
        private const string undefinedstr = "Undefined";

        private int number_of_sides = undefined;
        private string type = undefinedstr;
        private double side = undefined;

        public RegularPolygon(string polygon_type, double polygon_side)
        {
            type = polygon_type;
            side = polygon_side;

            switch (type)
            {
                case "triangle": number_of_sides = 3; break;
                case "square": number_of_sides = 4; break;
                case "pentgon": number_of_sides = 5; break;
            }
        }

        public string Type
        {
            get { return type; }
        }

        public double Side
        {
            get { return side; }
        }

        public int Number_Of_Sides
        {
            get { return number_of_sides; }
        }

        public override string ToString()
        {
            return string.Format("A {0} with side length {1} u has a perimeter of {2} u and an area of {3} u^2", type, side, calcPerimeter(), calcArea());
        }

        public virtual double calcArea()
        {
            // http://www.mathwords.com/a/area_regular_polygon.htm
            return (0.25)*number_of_sides*Math.Pow(side, 2)*(Math.Cos(180/number_of_sides)/Math.Sin(180/number_of_sides));
        }

        public virtual double calcPerimeter()
        {
            return (number_of_sides * side);
        }
    }

    class Circle: RegularPolygon
    {
        public Circle(string polygon_type, double polygon_size) : base(polygon_type, polygon_size) { }

        public override double calcArea()
        {
            return Math.PI*Math.Pow(Side, 2);
        }

        public override double calcPerimeter()
        {
            return 2*Math.PI*Side;
        }     
    }
}
