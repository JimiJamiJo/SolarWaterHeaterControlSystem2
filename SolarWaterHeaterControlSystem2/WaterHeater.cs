using System;
using System.Threading.Tasks;

public class WaterHeater
{
    public string Location { get; }
    public double CurrentTemperature { get; private set; }

    public event EventHandler<TemperatureChangedEventArgs>? TemperatureChanged;
    public event EventHandler? TargetReached;

    public WaterHeater(string location)
    {
        Location = location;
        CurrentTemperature = 20;
    }

    public async Task StartBoilerAsync(double targetTemp)
    {
        while (true)
        {
            CurrentTemperature += 2;

            TemperatureChanged?.Invoke(
                this,
                new TemperatureChangedEventArgs(CurrentTemperature, DateTime.Now)
            );

            if (CurrentTemperature >= targetTemp)
            {
                TargetReached?.Invoke(this, EventArgs.Empty);
                break;
            }

            await Task.Delay(500);
        }
    }

    public async Task<double> CalculateHeatingCostAsync()
    {
        await Task.Delay(3000);

        Random rnd = new Random();
        int factor = rnd.Next(2, 21);

        double baseCost = CurrentTemperature * factor;
        double vat = baseCost * 0.18;

        return baseCost + vat;
    }
}

//