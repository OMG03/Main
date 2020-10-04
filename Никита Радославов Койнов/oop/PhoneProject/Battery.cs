using System;

namespace PhoneProject
{
    public class Battery
    {
        // модел, idle time, часове разговор /hours talk/

        public string Model { get; set; }

        public TimeSpan IdleTime { get; set; }

        public decimal HoursTalk { get; set; }

        public BatteryType? BatteryType { get; set; }

        public Battery(string model, TimeSpan idleTime, decimal hoursTalk, BatteryType? batteryType)
        {
            Model = model;
            IdleTime = idleTime;
            HoursTalk = hoursTalk;
            BatteryType = batteryType;
        }

        public Battery()
            : this(null, new TimeSpan(), 0, null)
        {

        }
    }
}