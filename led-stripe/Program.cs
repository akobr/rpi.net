using System.Device.Spi;
using System.Drawing;
using Iot.Device.Ws28xx;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var count = 240;

var settings = new SpiConnectionSettings(0,0)
{
    ClockFrequency = 2_400_000,
    Mode = SpiMode.Mode0,
    DataBitLength = 8,
};

var spi = SpiDevice.Create(settings);
var device = new Ws2812b(spi, count);

var image = device.Image;
image.Clear();

for(var i = 0; i < count; i++)
{
    image.SetPixel(i, 0, Color.Green);
}

device.Update();