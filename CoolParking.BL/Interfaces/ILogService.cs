using System.Collections.Generic;

namespace CoolParking.BL.Interfaces
{
    public interface ILogService
    {
        string LogPath { get; }
        void Write(string logInfo);
        void Write(List<TransactionInfo> transactions);
        string Read();
    }
}