using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Behaviour
{
    internal class HourlyWage: Worker
    {
        private int hoursStandard;
        public HourlyWage()
        : this("", "М", 1, 1, 1) { }

        public HourlyWage( string? name,  string? sex, in int NormalPay, in int hoursStandard, in int BonusPay)
            : base(name, sex, NormalPay, BonusPay)
        {
            if ((hoursStandard < 1) || (hoursStandard > 24))
                //throw invalid_argument("Время выходит за суточные рамки 24 часа: " + to_string(m_hoursStandard));
            this.hoursStandard = hoursStandard * 15;

        }
        public int HoursStandard { get => hoursStandard; }
        public override string WorkerStatus { get => "Hourly"; } 
        public override int calculateSalary()
        {
            int wage;

            if (accumulatedAfterLastPay > hoursStandard)
                wage = hoursStandard * normalPay + (accumulatedAfterLastPay - hoursStandard) * bonusPay;
            else
                wage = accumulatedAfterLastPay * normalPay;

            accumulatedAfterLastPay = 0;

            return wage;

        }


    }
}
