using System;

class Program
{
    static void Main()
    {
        double heatingRate = 0.05;  
        double waterRate = 20;    
        double gasRate = 30;      
        double repairRate = 0.02;  
        double seasonMultiplier = 1.2; 
        double veteranLaborDiscount = 0.3;  
        double veteranWarDiscount = 0.5;    

        Console.Write("Введите площадь помещения (в м^2): ");
        double area = double.Parse(Console.ReadLine());

        Console.Write("Введите количество проживающих людей: ");
        int numResidents = int.Parse(Console.ReadLine());

        Console.Write("Введите сезон (осень/зима - 1, другие - 0): ");
        int season = int.Parse(Console.ReadLine());

        Console.Write("Есть ли льготы (ветеран труда - 1, ветеран войны - 2, нет - 0): ");
        int discountType = int.Parse(Console.ReadLine());

        double heatingCost = area * heatingRate * (season == 1 ? seasonMultiplier : 1);
        double waterCost = numResidents * waterRate;
        double gasCost = numResidents * gasRate;
        double repairCost = area * repairRate;
        double totalCost = heatingCost + waterCost + gasCost + repairCost;

        double discount = 0;

        if (discountType == 1)
        {
            discount = totalCost * veteranLaborDiscount;
        }
        else if (discountType == 2)
        {
            discount = totalCost * veteranWarDiscount;
        }

        double finalCost = totalCost - discount;

        Console.WriteLine("\nТаблица коммунальных платежей:");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("| Вид платежа          | Начислено   | Льготная скидка | Итого    |");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine($"| Отопление            | ${heatingCost:F2}   | ${discount * heatingRate:F2}            | ${heatingCost - discount * heatingRate:F2} |");
        Console.WriteLine($"| Вода                 | ${waterCost:F2}   | ${discount * waterRate:F2}             | ${waterCost - discount * waterRate:F2}  |");
        Console.WriteLine($"| Газ                  | ${gasCost:F2}   | ${discount * gasRate:F2}              | ${gasCost - discount * gasRate:F2}   |");
        Console.WriteLine($"| Текущий ремонт        | ${repairCost:F2}   | ${discount * repairRate:F2}           | ${repairCost - discount * repairRate:F2}  |");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine($"| Итого                | ${totalCost:F2}   | ${discount:F2}                          | ${finalCost:F2}    |");
        Console.WriteLine("-----------------------------------------------------");
    }
}
