using System.Device.Spi;
using System.Drawing;
using Iot.Device.Ws28xx;

Console.WriteLine("Press any key to quit.");

const int count = 240;
var settings = new SpiConnectionSettings(0,0)
{
    ClockFrequency = 2_400_000,
    Mode = SpiMode.Mode0,
    DataBitLength = 8,
};

using var spi = SpiDevice.Create(settings);
var device = new Ws2812b(spi, count);

var image = device.Image;
image.Clear();
var rnd = new Random();

while (!Console.KeyAvailable)
{
    for (var i = 0; i < count; i++)
    {
        image.SetPixel(i, 0, Color.FromArgb(rnd.Next(20, 256), rnd.Next(20, 256), rnd.Next(20, 256)));
    }

    device.Update();
    Thread.Sleep(5000);
}

image.Clear();
device.Update();

Console.WriteLine("LED strip out!");