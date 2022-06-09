// See https://aka.ms/new-console-template for more information
using CoolParking.BL.Interfaces;
using CoolParking.UI;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Timers;

TimerService withdrawTimer = new TimerService();
TimerService logTimer = new TimerService();

ILogService logService = new LogService($@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\Transactions.log");


ParkingService parkingService = new ParkingService(withdrawTimer,logTimer,logService);
Parking parking = Parking.GetParking();




var vehicle = new Vehicle(Vehicle.GenerateRandomRegistrationPlateNumber(), VehicleType.PassengerCar, 100);
var vehicle1 = new Vehicle(Vehicle.GenerateRandomRegistrationPlateNumber(), VehicleType.Truck, 100);
var vehicle2 = new Vehicle(Vehicle.GenerateRandomRegistrationPlateNumber(), VehicleType.Bus, 100);
var vehicle3 = new Vehicle(Vehicle.GenerateRandomRegistrationPlateNumber(), VehicleType.Motorcycle, 100);


parkingService.AddVehicle(vehicle);
parkingService.AddVehicle(vehicle1);
parkingService.AddVehicle(vehicle2);
parkingService.AddVehicle(vehicle3);



withdrawTimer.SetTimerInterval(Settings.PaymentPeriod*1000);
withdrawTimer.Elapsed += (object? sender, ElapsedEventArgs e) => {
    parkingService.Payment();
};
withdrawTimer.AddToTimer();

logTimer.SetTimerInterval(Settings.LogPeriod * 1000);
logTimer.Elapsed += (object? sender, ElapsedEventArgs e) => {
    parkingService.WriteTransactions();

};
logTimer.AddToTimer();

withdrawTimer.Start();
logTimer.Start();


User.Menu(parkingService);







