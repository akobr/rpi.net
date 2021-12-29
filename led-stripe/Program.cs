using System;
using System.Device.Spi;
using System.Device.Spi.Drivers;
using System.Drawing;
using IoT.Device.Graphics;
using IoT.Device.Ws28xx; 

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var count = 240;

var settings = new SpiConnectionSettings(0,0)
{
    ClockFrequency = 2_400_000,
    Mode = SpiMode.Mode0,
    DataBitLength = 8,
};


var spi = new UnixSpiDevice(settings);
var device = new Ws2812b(spi, count);

BitmapImage image = device.Image;
image.Clear();

for(int i = 0; i < count; i++)
{
    image.SetPixel(i, 0, Color.Green);
}

device.Update();