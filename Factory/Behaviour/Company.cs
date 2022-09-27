using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Behaviour
{
    internal class Company
    {
        //private BindingList<Worker> m_workers;
        //private vector<shared_ptr<Worker>> m_workers;
        private int m_daysSinceLastPay;


        private List<Worker> m_workersList = new List<Worker>();
        public Company() { m_daysSinceLastPay = 0; }

        public void addWorker(Worker worker)
        {
            m_workersList.Add(worker);
        }



        public void removeWorker(string name)
        {
            int i = 0;
            foreach (var worker in m_workersList)
    {
                if (worker.Name == name)
                {
                    m_workersList.Remove(worker);
                    break;
                }
                i++;
            }

        }



        
        public int companyWork(int days)
        {
            if (days < 0) { days = 0; }
                //throw invalid_argument("Число должно быть больше 0: " + to_string(days));

            int cost = 0;
            if (m_workersList.Count == 0)
                Console.WriteLine("Активные сотрудники не найдены");

            Random rand = new Random();
            while (days > 0)
            {
                foreach (var worker in m_workersList)
        {
                    if (worker.WorkerStatus == "Hourly")
                    {
                         
                        int hours = 0 + rand.Next() % (25) ;
                        worker.work(hours);
                    }
                    else
                    {
                        int Sum = 0 + rand.Next() % (15000);
                        worker.work(Sum);
                    }
                }
                m_daysSinceLastPay++;
                if (m_daysSinceLastPay >= 15)
                {
                    foreach (var worker in m_workersList)
                    {
                        if (worker.WorkerStatus == "Commission")
                            cost += worker.NormalPay;
                        cost += worker.calculateSalary();
                        
                    }
                    m_daysSinceLastPay -= 15;
                }
                days--;
            }
            return cost;

        }




        public int LastDayPaid { get => m_daysSinceLastPay; } 



        //Вывод результата
        public void print()
        {
            if (m_workersList == null || m_workersList.Count == 0)
            {
                Console.WriteLine("Список пуст\n");
                return;
            }

            Console.WriteLine("Сотрудники с почасовой оплатой труда\n");
            forPrint("Hourly");

            Console.WriteLine("Сотрудники с комиссионной оплатой труда\n");
            forPrint("Commission");


            void forPrint(string status)
            {
                foreach (var worker in m_workersList)
                {
                    if (worker.WorkerStatus == status)
                    {
                        Console.Write($"{worker.Name} \t");
                        Console.Write($"{worker.Sex} \t");
                        Console.Write($"{worker.NormalPay}  \t");
                        Console.WriteLine($"{worker.BonusPay} \n");
                    }

                }
            }
        }

    }
}
