using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneProject
{
    public static class PhoneTest
    {
        private static IEnumerable<Phone> phones;

        public static IReadOnlyCollection<Phone> Phones => phones.ToList().AsReadOnly();

        static PhoneTest()
        {
            phones = new List<Phone> 
            {
                new Phone(),
                new Phone
                {
                    Model = "X",
                    Manufacturer = "Iphone",
                    Price = 1,
                    Owner = "Mitio Pishtov",
                    Battery = new Battery
                    {
                        Model = "Djakuzi Battery",
                        HoursTalk = 1242444,
                        IdleTime = new TimeSpan(1, 21, 31),
                        BatteryType = BatteryType.NiCd
                    },
                    Screen = new Screen
                    {
                        Size = 4,
                        Colors = "RGB"
                    }
                },
                new Phone
                {
                    Model = "Z Float 2",
                    Manufacturer = "Samsung",
                    Price = 1,
                    Owner = "Denis Teofikov",
                    Battery = new Battery
                    {
                        Model = "Double Battery",
                        HoursTalk = 313,
                        IdleTime = new TimeSpan(6, 51, 22),
                        BatteryType = BatteryType.NiCd
                    },
                    Screen = new Screen
                    {
                        Size = 9,
                        Colors = "RGB"
                    }
                }
            };
        }

        public static void PrintPhonesInfo()
        {
            foreach (var phone in phones)
            {
                Console.WriteLine(phone);
            }
        }

        public static void PrintNokiaInfo()
        {
            Phone.PrintNokiaInfo();
        }
    }
}
