// TODO: implement the LogService class from the ILogService interface.
//       One explicit requirement - for the read method, if the file is not found, an InvalidOperationException should be thrown
//       Other implementation details are up to you, they just have to match the interface requirements
//       and tests, for example, in LogServiceTests you can find the necessary constructor format.
using CoolParking.BL.Interfaces;
using System.Collections.Generic;
using System.IO;

public class LogService : ILogService
{
    public string LogPath { get; init; }

    public LogService(string logPath)
    {
        LogPath = logPath;
    }

    public string Read()
    {
        return File.ReadAllText(LogPath);
    }

    public async void Write(string logInfo)
    {
        using (StreamWriter writer = new StreamWriter(LogPath))
        {
            await writer.WriteLineAsync(logInfo);
        }
    }
    public async void Write(List<TransactionInfo> transactions)
    {
        using(StreamWriter writer = new StreamWriter(LogPath))
        {
            for(int i = 0; i < transactions.ToArray().Length; i++)
            {
                await writer.WriteLineAsync($"{transactions[i].Time},{transactions[i].Id},{transactions[i].Sum}");
            }

        }
    }
}