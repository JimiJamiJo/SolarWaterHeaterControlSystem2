using System;

public class DisplayUnit
{
    public void OnTemperatureChanged(object? sender, TemperatureChangedEventArgs e)
    {
        if (sender is WaterHeater heater)
        {
            Console.WriteLine(
                $"[Display - {heater.Location}] Current Temperature: {e.CurrentTemperature:F1} at {e.MeasuredAt:HH:mm:ss}"
            );
        }
    }
}
