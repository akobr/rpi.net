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

var colorList = new Color[]
{
    Color.FromArgb(27, 161, 226),
    Color.FromArgb(160, 80, 0),
    Color.FromArgb(51, 153, 51),
    Color.FromArgb(162, 193, 57),
    Color.FromArgb(216, 0, 115),
    Color.FromArgb(240, 150, 9),
    Color.FromArgb(230, 113, 184),
    Color.FromArgb(162, 0, 255),
    Color.FromArgb(229, 20, 0),
    Color.FromArgb(0, 171, 169),
};

var index = 4;

while (!Console.KeyAvailable)
{
    image.Clear();
    image.SetPixel(index - 4, 0, Color.FromArgb(255 - 4 * 51, 162, 0, 255));
    image.SetPixel(index - 3, 0, Color.FromArgb(255 - 3 * 51, 162, 0, 255));
    image.SetPixel(index - 2, 0, Color.FromArgb(255 - 2 * 51, 162, 0, 255));
    image.SetPixel(index - 1, 0, Color.FromArgb(255 - 51, 162, 0, 255));
    image.SetPixel(index, 0, Color.FromArgb(162, 0, 255));
    image.SetPixel(index + 1, 0, Color.FromArgb(255 - 51, 162, 0, 255));
    image.SetPixel(index + 2, 0, Color.FromArgb(255 - 2 * 51, 162, 0, 255));
    image.SetPixel(index + 3, 0, Color.FromArgb(255 - 3 * 51, 162, 0, 255));
    image.SetPixel(index + 4, 0, Color.FromArgb(255 - 4 * 51, 162, 0, 255));
    device.Update();

    if (++index > 235)
    {
        index = 4;
    }

    await Task.Delay(200);
}

image.Clear();
device.Update();

Console.WriteLine("LED strip out!");