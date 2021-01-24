namespace Problem1
{ 
    public class Car
    {
        public string MakeAndModel { get; set; }

        public int ManufactureYear { get; set; }

        public int EnginePowerkW { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{MakeAndModel} {ManufactureYear} {EnginePowerkW}kW - {Price}";
        }
    }
}
