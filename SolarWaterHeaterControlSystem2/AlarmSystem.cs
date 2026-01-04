using System;

public class AlarmSystem
{
    public void OnTargetReached(object? sender, EventArgs e)
    {
        if (sender is WaterHeater heater)
        {
            Console.WriteLine(
                $"[ALARM - {heater.Location}] Target temperature reached! Powering off..."
            );
        }
    }
}

