// TODO: implement class Vehicle.
//       Properties: Id (string), VehicleType (VehicleType), Balance (decimal).
//       The format of the identifier is explained in the description of the home task.
//       Id and VehicleType should not be able for changing.
//       The Balance should be able to change only in the CoolParking.BL project.
//       The type of constructor is shown in the tests and the constructor should have a validation, which also is clear from the tests.
//       Static method GenerateRandomRegistrationPlateNumber should return a randomly generated unique identifier.

using Fare;
using System.Text.RegularExpressions;

public class Vehicle
{
    public string Id { get; init; }
    public VehicleType VehicleType { get; init; }
    public decimal Balance { get; set; }
    public Vehicle(string id, VehicleType vehicleType, decimal balance)
    {
        Regex regex = new Regex("[A-Z]{2}-[0-9]{4}-[A-Z]{2}");
        if (regex.IsMatch(id))
        {
            Id = id;
        }
        else
        {
            Id = GenerateRandomRegistrationPlateNumber();
        }
        VehicleType = vehicleType;
        Balance = balance;
    }

    public static string GenerateRandomRegistrationPlateNumber()
    {
        var xeger = new Xeger("[A-Z]{2}-[0-9]{4}-[A-Z]{2}");
        var generatedString = xeger.Generate();
        return generatedString;
    }
    public void IncreaseBalance(decimal sum)
    {
        Balance += sum;
    }
}
