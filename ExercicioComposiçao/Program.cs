using ExercicioComposiçao.Entities;
using ExercicioComposiçao.Entities.Enums;
using System;
using System.Globalization;

namespace ExercicioComposiçao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entre com o nome do departamento: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Dados do Trabalhador" );
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Nível (Junior/Pleno/Senior: )");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Salario Base: ");
            double salaryBase = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, salaryBase, dept);

            Console.WriteLine("Quantos contratos para este trabalhador? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Entre com dados do contrato #{i}: ");
                Console.Write("Data (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duração (horas): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                //Adicionando o contrato ao trabalhador
                worker.AddContract(contract);
            }
            Console.WriteLine("Entre com mês e ano para calcular os ganhos (MM/YYYY): " );
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Ganhos para " + monthAndYear + ": " , worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
