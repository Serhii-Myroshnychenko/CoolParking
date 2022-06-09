// TODO: implement class Parking.
//       Implementation details are up to you, they just have to meet the requirements 
//       of the home task and be consistent with other classes and tests.
using System.Collections.Generic;

public class Parking
{
    private static readonly Parking parking = new Parking();
    public decimal Balance { get; set; }
    public List<Vehicle> list;
    private Parking()
    {
        list = new List<Vehicle>(Settings.ParkingCapacity);
        Balance = Settings.InitialParkingBalance;
    }
    public static Parking GetParking() => parking;
}