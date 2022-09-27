using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Behaviour
{
    internal class CommissionWage: Worker
    {

        public CommissionWage()
            : this("", "М", 0, 0) { }
        public CommissionWage( string? m_name,  string? m_sex, in int m_normalPay, in int m_bonusPay)
            : base(m_name, m_sex, m_normalPay, m_bonusPay)
        {
            if ((m_bonusPay <= 0) || (m_bonusPay > 100))
                bonusPay = m_bonusPay;

        }
        public override string WorkerStatus  => "Commission";  

        public override int calculateSalary()
        {
            int wage = accumulatedAfterLastPay * bonusPay / 100;
            accumulatedAfterLastPay = 0;
            return wage;

        }

    }
}
