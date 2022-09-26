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


        public string Name { get => name; }



        public string Sex { get => sex; } 
        public int NormalPay { get => normalPay; } 
        public int BonusPay { get => bonusPay; }
        public int getAccumulatedAfterLastPay { get => accumulatedAfterLastPay; } 
        public void work(in int accumulated)
        {
            if (accumulated < 0) { return; }
            accumulatedAfterLastPay += accumulated;

        }
        public virtual string WorkerStatus { get => ""; }
        public virtual int calculateSalary() => 0;

    }
}
