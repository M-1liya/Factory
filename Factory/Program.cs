using System;
using Factory.Behaviour;



namespace Factory
{
	static class Modeling
    {
        const int normalyEveryHourPay = 150;
        const int normalyHourEveryDayWork = 5;
        const int priceForProcessing = 250;

        static int Main()
		{

            Menu();

			return 0;
		}

        static void Menu()
        {
            int choice;
            Company company = new Company();
            for (; ; )
            {

                do
                {
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("1. Задать дни работы компании");
                    Console.WriteLine("2. Нанять сотрудника");
                    Console.WriteLine("3. Уволить сотрудника");
                    Console.WriteLine("4. Список сотрудников");
                    Console.WriteLine("5. Завершить работу");
                    Console.WriteLine("------------------------------");

                }
                while (int.TryParse(Console.ReadLine(), out choice) && choice <= 1 && choice >= 5);


                switch (choice)
                {
                    case 1:
                        companyWork(company);
                        break;
                    case 2:
                        positionChoosing(company);
                        break;
                    case 3:
                        removeWorker(company);
                        break;
                    case 4:
                        company.print();
                        break;
                    case 5:
                    default:
                        return;
                }
            }
                
        }

        static void positionChoosing(Company c)
        {
            byte newWorkerPost;
            do
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("1. Сотрудник с комиссионной оплатой труда");
                Console.WriteLine("2. Сотрудник с почасовой оплатой труда");
                Console.WriteLine("------------------------------\n");
                Console.WriteLine("Введите номер должности сотрудника: ");

            }
            while(!(byte.TryParse(Console.ReadLine(), out newWorkerPost) && (newWorkerPost == 1 || newWorkerPost == 2)));


            switch (newWorkerPost)
            {
                case 1:
                    addCommissionWorker(c);
                    break;
                case 2:
                    addHourlyWorker(c);
                    break;
            }
        }


        static void addHourlyWorker( Company company)
        {
            string? name, sex;
            Console.WriteLine("------------------------------");
            Console.Write("Введите имя сотрудника: ");

            name = Console.ReadLine();

            Console.Write("Введите пол сотрудника: ");
            sex = Console.ReadLine();

            HourlyWage worker = new HourlyWage(name, sex, normalyEveryHourPay, normalyHourEveryDayWork, priceForProcessing);

            company.addWorker(worker);
            Console.WriteLine("Сотрудник добавлен!\n\n");
        }

        static void addCommissionWorker(Company company)
        {
            string? name, sex;
            int salary, percent;

            Console.WriteLine("------------------------------");

            Console.Write("Введите имя сотрудника: ");              // Имя
            name = Console.ReadLine();

            Console.Write("Введите пол сотрудника: ");            //Пол
            sex = Console.ReadLine();

            Console.Write("Введите оклад сотрудника: ");                          // Оклад
            int.TryParse(Console.ReadLine(), out salary);

            Console.Write("Введите процент с продаж для сотрудника: ");           //Процент
            int.TryParse(Console.ReadLine(), out percent);
            
            Console.WriteLine("------------------------------");


            CommissionWage worker = new CommissionWage(name, sex, salary, percent);
            company.addWorker(worker);
            Console.WriteLine("Сотрудник добавлен!\n\n");

        }

        static void removeWorker( Company company)
        {
            string? name;

            Console.WriteLine("\nВведите имя сотрудника, которого хотите удалить:");
            do { name = Console.ReadLine(); } while (name == null);

            company.removeWorker(name);
            Console.WriteLine("Сотрудник уволен!\n");
        }

        static void companyWork(Company company)
        {
            int days;
            Console.WriteLine("Количество дней с момента последней выплаты зарплаты: " + company.LastDayPaid);
            Console.WriteLine("------------------------------");
            do 
            {
                Console.WriteLine("Введите количество дней: ");
                int.TryParse(Console.ReadLine(), out days); 
            }while (days < 0);

            Console.WriteLine("\nCуммарные затраты на зарплату: " + company.companyWork(days));
        }


    }
}