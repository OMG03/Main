namespace ColoredFigureProject
{
    public class Square : ColoredFigure
    {
        public Square(string color, int size)
            : base(color, size)
        {
        }

        public override double GetArea()
        {
            return this.Size * this.Size;
        }

        public override string GetName()
        {
            return "Square";
        }
    }
}
