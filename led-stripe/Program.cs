using System.Device.Spi;
using System.Drawing;
using Iot.Device.Ws28xx;

Console.WriteLine("Hello, World!");

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

for(var i = 0; i < count; i++)
{
    image.SetPixel(i, 0, Color.Green);
}

device.Update();

Thread.Sleep(10000);

image.Clear();
device.Update();;

Console.WriteLine("LED strip out!");