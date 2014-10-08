using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Humans
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal workHoursPerDay;

        public Worker(decimal weekSalary, decimal workHoursPerDay, String firstName, String lastName)
            : base(firstName, lastName)
        {
            this.weekSalary = weekSalary;
            this.workHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get { return weekSalary; }
            set { weekSalary = value; }
        }
        public decimal WorkHoursPerDay
        {
            get { return workHoursPerDay; }
            set { workHoursPerDay = value; }
        }

        public decimal moneyPerHour()
        {
            int workingDay = 5;
            decimal result = weekSalary / (workHoursPerDay * workingDay);
            return result;
        }
    }
}
