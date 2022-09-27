using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Behaviour
{
    internal class Worker
    {
        protected string name, sex;
        protected int normalPay, bonusPay, accumulatedAfterLastPay;

        public Worker()
            :this("", "M", 1, 1) { }
        public Worker(string? name,  string? sex, in int normalPay, in int bonusPay)
        {
            this.name = name != null ? name : "None";
            this.sex = sex != null ? sex : "None";
            this.normalPay = normalPay;
            this.bonusPay = bonusPay;

            accumulatedAfterLastPay = 0;
        }



        public string Name => name; 
        public string Sex  => sex; 
        public int NormalPay => normalPay; 
        public int BonusPay => bonusPay; 
        public int AccumulatedAfterLastPay => accumulatedAfterLastPay; 
        public void work(in int accumulated)
        {
            if (accumulated < 0) { return; }
            accumulatedAfterLastPay += accumulated;

        }
        public virtual string WorkerStatus  => ""; 
        public virtual int calculateSalary() => 0;

    }
}
