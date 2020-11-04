namespace ColoredFigureProject
{
    using System;

    public abstract class ColoredFigure
    {
        public string Color { get; set; }

        public int Size { get; set; }

        protected ColoredFigure(string color, int size)
        {
            Color = color;
            Size = size;
        }

        public void Show()
        {
            Console.WriteLine(this.GetName() + ":");
            Console.WriteLine("Color: " + this.Color);
            Console.WriteLine("Size: " + this.Size);
            Console.WriteLine(string.Format("Area: {0:F2}", this.GetArea()));
        }

        public abstract string GetName();

        public abstract double GetArea();
    }
}
