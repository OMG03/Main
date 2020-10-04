using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneProject
{
    public class Phone
    {
        public static Phone NokiaN95 { get; set; }

        private ICollection<Call> callHistory = new List<Call>();

        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public decimal Price { get; set; }

        public string Owner { get; set; }

        public Battery Battery { get; set; }

        public Screen Screen { get; set; }

        public IReadOnlyCollection<Call> CallHistory => this.callHistory.ToList().AsReadOnly();

        static Phone()
        {
            NokiaN95 = new Phone
            {
                Model = "N95",
                Manufacturer = "Nokia",
                Price = 1,
                Owner = "Delqn Peevski",
                Battery = new Battery
                {
                    Model = "Custom Nokia Battery",
                    HoursTalk = 12,
                    IdleTime = new TimeSpan(12, 11, 3),
                    BatteryType = BatteryType.NiCd
                },
                Screen = new Screen
                {
                    Size = 4,
                    Colors = "Black/Yellow"
                }
            };
        }

        public Phone(string model, string manufacturer, decimal price, string owner, Battery battery, Screen screen)
        {
            Model = model;
            Manufacturer = manufacturer;
            Price = price;
            Owner = owner;
            Battery = battery;
            Screen = screen;
        }

        public Phone() 
            : this(null, null, 0, null, null, null)
        {
            
        }

        public static void PrintNokiaInfo()
        {
            Console.WriteLine(NokiaN95);
        }

        public void AddCall(DateTime startedAt, TimeSpan duration)
        {
            this.callHistory.Add(new Call
            {
                StartedAt = startedAt,
                Duration = duration
            });
        }

        public void DeleteLastCall()
        {
            var latestCall = this.callHistory.OrderByDescending(c => c.StartedAt).FirstOrDefault();

            if (latestCall != null)
            {
                this.callHistory.Remove(latestCall);
            }
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Manufacturer) || string.IsNullOrWhiteSpace(this.Manufacturer)
                || string.IsNullOrEmpty(this.Model) || string.IsNullOrWhiteSpace(this.Model))
            {
                return "Empty Phone";
            }

            return this.Manufacturer + " " + this.Model + " - " + (this.Owner == null ? "unknown" : this.Owner);
        }
    }
}
