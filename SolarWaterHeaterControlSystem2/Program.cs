using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        DisplayUnit display = new DisplayUnit();
        AlarmSystem alarm = new AlarmSystem();

        List<WaterHeater> heaters = new List<WaterHeater>
        {
            new WaterHeater("Roof - Building A"),
            new WaterHeater("Roof - Building B"),
            new WaterHeater("Factory - South Wing")
        };

        foreach (var heater in heaters)
        {
            heater.TemperatureChanged += display.OnTemperatureChanged;
            heater.TargetReached += alarm.OnTargetReached;
        }

        List<Task> heatingTasks = heaters
            .Select(h => h.StartBoilerAsync(70))
            .ToList();

        Task firstFinished = await Task.WhenAny(heatingTasks);

        int index = heatingTasks.IndexOf(firstFinished);
        Console.WriteLine(
            $"First heater finished: {heaters[index].Location}"
        );

        await Task.WhenAll(heatingTasks);

        Console.WriteLine("\nHeating costs:");

        foreach (var heater in heaters)
        {
            double cost = await heater.CalculateHeatingCostAsync();
            Console.WriteLine(
                $"{heater.Location}: {cost:F2} ₪"
            );
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
