using Iot.Device.CpuTemperature;

using var cpuTemp = new CpuTemperature();
Console.WriteLine("Press any key to quit.");

while (!Console.KeyAvailable)
{
    if (!cpuTemp.IsAvailable)
    {
        Console.WriteLine("CPU temperature is not available. :(");
        Thread.Sleep(5000);
        continue;
    }

    var temps = cpuTemp.ReadTemperatures();
    foreach (var entry in temps)
    {
        Console.WriteLine(!double.IsNaN(entry.Temperature.DegreesCelsius)
            ? $"Temperature from {entry.Sensor} is {Math.Round(entry.Temperature.DegreesCelsius, 2)} °C."
            : $"Unable to read temperature from {entry.Sensor}. :(");
    }
    Thread.Sleep(2500);
}