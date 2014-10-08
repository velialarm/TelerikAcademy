using System;

namespace _01MobilePhones
{
    class Battery
    {
        public string ModelBatttery { get; set; }
        public int HoursIdle { get; set; }
        public int HoursTalkBattery { get; set; }
        public BatteryType TypeBattery { get; set; }

        public Battery()
        {
        }
        public Battery(String model, int hoursIdle, int hoursTalks, BatteryType typeBattery)
        {
            ModelBatttery = model;
            HoursIdle = hoursIdle;
            HoursTalkBattery = hoursTalks;
            TypeBattery = typeBattery;
        }

    }
}
