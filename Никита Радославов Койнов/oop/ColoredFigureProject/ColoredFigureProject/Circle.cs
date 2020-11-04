namespace ColoredFigureProject
{
    using System;

    public class Circle : ColoredFigure
    {
        public Circle(string color, int size)
            : base(color, size)
        {
        }

        public override double GetArea()
        {
            return this.Size * this.Size * Math.PI;
        }

        public override string GetName()
        {
            return "Circle";
        }
    }
}
