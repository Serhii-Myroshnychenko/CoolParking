// TODO: implement class TimerService from the ITimerService interface.
//       Service have to be just wrapper on System Timers.
using CoolParking.BL.Interfaces;
using System;
using System.Timers;

public class TimerService : ITimerService
{
    private Timer _timer;
    public double Interval { get; set; }

    public event ElapsedEventHandler Elapsed;
    public TimerService()
    {
        _timer = new Timer();
    }
    public void SetTimerInterval(double interval)
    {
        _timer.Interval = interval;
        Interval = interval;
    }
    public void AddToTimer()
    {
        _timer.Elapsed += Elapsed;
    }
    public void Dispose()
    {
        this.Dispose();

    }
    public void Start()
    {
        _timer.Enabled = true;
    }
    public void Stop()
    {
        _timer.Enabled = false;
    }
}