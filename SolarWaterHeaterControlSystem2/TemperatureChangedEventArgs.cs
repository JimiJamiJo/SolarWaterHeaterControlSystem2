using System;

public class TemperatureChangedEventArgs : EventArgs
{
    public double CurrentTemperature { get; }
    public DateTime MeasuredAt { get; }

    public TemperatureChangedEventArgs(double currentTemperature, DateTime measuredAt)
    {
        CurrentTemperature = currentTemperature;
        MeasuredAt = measuredAt;
    }
}
