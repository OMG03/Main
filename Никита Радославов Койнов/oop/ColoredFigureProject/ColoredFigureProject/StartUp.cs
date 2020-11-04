namespace ColoredFigureProject
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int figuresCount = int.Parse(Console.ReadLine());

            List<ColoredFigure> figures = new List<ColoredFigure>();

            for (int i = 0; i < figuresCount; i++)
            {
                string[] line = Console.ReadLine().Split();

                var figureType = line[0];
                var figureColor = line[1];
                var figureSize = int.Parse(line[2]);

                switch (figureType)
                {
                    case "Triangle":
                        figures.Add(new Triangle(figureColor, figureSize));
                        break;
                    case "Circle":
                        figures.Add(new Circle(figureColor, figureSize));
                        break;
                    case "Square":
                        figures.Add(new Square(figureColor, figureSize));
                        break;
                }
            }

            figures.ForEach(f => f.Show());
        }
    }
}
