// TODO: implement struct TransactionInfo.
//       Necessarily implement the Sum property (decimal) - is used in tests.
//       Other implementation details are up to you, they just have to meet the requirements of the homework.
using System;

public struct TransactionInfo
{
    public DateTime Time { get; set; }
    public string Id { get; set; }
    public decimal Sum { get; set; }
    public TransactionInfo(DateTime time,string id, decimal sum)
    {
        Time = time;
        Id = id; 
        Sum = sum;
    }
}