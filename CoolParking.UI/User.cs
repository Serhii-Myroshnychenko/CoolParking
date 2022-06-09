using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoolParking.UI
{
    public static class User
    {
        public static void Menu(ParkingService parkingService)
        {
            Console.WriteLine("1 - Вывести на экран текущий баланс Парковки \n" +
            "2 - Вывести на экран сумму заработанных денег за текущий период \n" +
            "3 - Вывести на экран количество свободных/занятых мест \n" +
            "4 - Вывести на экран все Транзакции Парковки за текущий период \n" +
            "5 - Вывести историю транзакций \n" +
            "6 - Вывести на экран список Тр. средств находящихся на Паркинге \n" +
            "7 - Поставить транспортное средство на парковку \n");
             Answer(parkingService);
        }
        public static void Answer(ParkingService parkingService)
        {
            var number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    Console.WriteLine($"\nTекущий баланс парковки: {parkingService.GetBalance()} \n");
                    Menu(parkingService);
                    break;
                case "2":
                    Console.WriteLine($"\nСумма заработанных денег за текущий период: {parkingService.GetSumOfCurentPeriod()}\n");
                    Menu(parkingService);
                    break;
                case "3":
                    Console.WriteLine($"\nКоличество свободных/занятых мест: {parkingService.GetCountFreeAndOccupiedPlaces()}\n");
                    Menu(parkingService);
                    break;
                case "4":
                    Console.WriteLine($"\nТранзакции Парковки за текущий период: {parkingService.GetLastParkingTransactions()}\n");
                    Menu(parkingService);
                    break;
                case "5":
                    Console.WriteLine($"\nИстория транзакций:");
                    parkingService.PrintTransactions();
                    Console.WriteLine("\n");
                    Menu(parkingService);
                    break;
                case "6":
                    Console.WriteLine($"\nCписок Тр. средств находящихся на Паркинге: ");
                    parkingService.PrintVehicles();
                    Console.WriteLine("\n");
                    Menu(parkingService);
                    break;
                case "7":
                    CreateVehicle(parkingService);
                    Console.WriteLine("\n");
                    Menu(parkingService);
                    break;
                
                default:
                    Console.WriteLine("\nВведите значение от 1 до 9\n");
                    Menu(parkingService);
                    break;


            }
        }
       
        public static void CreateVehicle(ParkingService parkingService)
        {
            Console.WriteLine("Введите Id авто");
            var id = Console.ReadLine();
            Regex regex = new Regex("[A-Z]{2}-[0-9]{4}-[A-Z]{2}");
            while (!regex.IsMatch(id))
            {
                Console.WriteLine("Вот нужная форма Id - ХХ-YYYY-XX\n" +
                    "Напишите еще раз и повторите попытку");
                id = Console.ReadLine();
            }
            Console.WriteLine("Введите номер типа авто, от 0 до 3");
            var type = Console.ReadLine();
            while(type!="0" & type!="1" & type != "2" & type != "3")
            {
                Console.WriteLine("Возможные типы: 0 - PassengerCar,1 - Truck, 2 - Bus, 3 - Motorcycle\n" +
                    "Напишите еще раз и повторите попытку");
                type = Console.ReadLine();
            }
            Console.WriteLine("Введите баланс авто");
            var balance = Console.ReadLine();
            var result = 0M;
            while (!decimal.TryParse(balance,out result) )
            {
                Console.WriteLine(
                    "Напишите еще раз и повторите попытку");
                 balance= Console.ReadLine();
            }
            
            

            parkingService.AddVehicle(new Vehicle(id, (VehicleType)int.Parse(type), result));
            Console.WriteLine("Успешно");
        }
    }
}
