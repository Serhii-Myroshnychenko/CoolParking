// TODO: implement class Settings.
//       Implementation details are up to you, they just have to meet the requirements of the home task.
public static class Settings
{
    public static int InitialParkingBalance = 0;
    public static int ParkingCapacity = 10;
    public static int PaymentPeriod = 5;
    public static int LogPeriod = 30;
    public static decimal Tarrifs(VehicleType vehicleType)
    {
        switch (vehicleType.ToString())
        {
            case "PassengerCar":
                return 2;
            case "Truck":
                return 5;
            case "Bus":
                return 3.5M;
            case "Motorcycle":
                return 1;
            default:
                return 0;
        }
        
    }
    public static decimal PenaltyCoefficient = 2.5M;

}