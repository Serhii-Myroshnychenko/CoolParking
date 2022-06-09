// TODO: implement the ParkingService class from the IParkingService interface.
//       For try to add a vehicle on full parking InvalidOperationException should be thrown.
//       For try to remove vehicle with a negative balance (debt) InvalidOperationException should be thrown.
//       Other validation rules and constructor format went from tests.
//       Other implementation details are up to you, they just have to match the interface requirements
//       and tests, for example, in ParkingServiceTests you can find the necessary constructor format and validation rules.
using CoolParking.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class ParkingService : IParkingService
{
    private TimerService _withdrawTimer;
    private TimerService _logTimer;
    private ILogService _logService;
    private Parking parking;
    private List<TransactionInfo> transactionInfos;
    public ParkingService(TimerService withdrawTimer, TimerService logTimer, ILogService logService)
    {
        _withdrawTimer = withdrawTimer;
        _logTimer = logTimer;
        _logService = logService;
        parking = Parking.GetParking();
        transactionInfos = new List<TransactionInfo>();
    }
    public void AddVehicle(Vehicle vehicle)
    {
        if (parking.list.Count < Settings.ParkingCapacity)
        {
            parking.list.Add(vehicle);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public void Dispose()
    {
        this.Dispose();
    }

    public decimal GetBalance() => parking.Balance;

    public int GetCapacity() => parking.list.Capacity;

    public int GetFreePlaces() => parking.list.Capacity - parking.list.Count;

    public TransactionInfo[] GetLastParkingTransactions() => transactionInfos.ToArray();


    public ReadOnlyCollection<Vehicle> GetVehicles() => new ReadOnlyCollection<Vehicle>(parking.list);


    public string ReadFromLog()
    {
        throw new System.NotImplementedException();
    }

    public void RemoveVehicle(string vehicleId)
    {
        var vehicle = parking.list.Find(x => x.Id == vehicleId);
        if (vehicle == null || vehicle.Balance < 0)
        {
            throw new InvalidOperationException();
        }
        else
        {
            parking.list.Remove(vehicle);
        }
    }

    public void TopUpVehicle(string vehicleId, decimal sum)
    {
        throw new System.NotImplementedException();
    }
    public void Payment()
    {
        foreach (var vehicle in parking.list)
        {
            var sum = vehicle.Balance;
            var type = Settings.Tarrifs(vehicle.VehicleType);
            if (vehicle.Balance > 0 && vehicle.Balance < type)
            {
                sum = vehicle.Balance + (type - vehicle.Balance);
            }
            else if (vehicle.Balance > 0 && vehicle.Balance > type)
            {
                sum = vehicle.Balance - (vehicle.Balance - type);
            }
            else if (vehicle.Balance <= 0)
            {
                sum = type * Settings.PenaltyCoefficient;
            }
            parking.Balance += sum;
            vehicle.Balance -= sum;
            transactionInfos.Add(new TransactionInfo(DateTime.Now, vehicle.Id, sum));

        }
    }
    public void WriteTransactions()
    {
        _logService.Write(transactionInfos);
        transactionInfos.Clear();
    }
    public decimal GetSumOfCurentPeriod()
    {
        decimal sum = 0; 
        foreach(var elem in transactionInfos)
        {
            sum += elem.Sum;
        }
        return sum;
    }
    public (int,int) GetCountFreeAndOccupiedPlaces() => (parking.list.Capacity - parking.list.Count, parking.list.Count);

    public void PrintTransactions()
    {
        foreach(var elem in transactionInfos)
        {
            Console.WriteLine($"{elem.Time},{elem.Id},{elem.Sum}");
        }
    }
    public void PrintVehicles()
    {
        foreach(var elem in parking.list)
        {
            Console.WriteLine($"{elem.Id},{elem.VehicleType},{elem.Balance}");
        }
    }
    public bool IsConsist(string id)
    {
        if(parking.list.Exists(x => x.Id == id))
        {
            return true;
        }
        return false;
    }
    public void DeleteVehicle(string id)
    {
        var vehicle = parking.list.Find(x => x.Id == id);
        parking.list.Remove(vehicle);
    }

}