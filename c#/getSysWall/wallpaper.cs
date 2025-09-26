using System;
using System.Runtime.InteropServices;
using System.Text;

partial class Program
{
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern bool SystemParametersInfo(
        int uAction, 
        int uParam, 
        StringBuilder lpvParam, 
        int fuWinIni);

    private const int SPI_GETDESKWALLPAPER = 0x0073;

    static void Main()
    {
        try
        {
            StringBuilder wallpaperPath = new StringBuilder(260);
            
            bool success = SystemParametersInfo(SPI_GETDESKWALLPAPER, wallpaperPath.Capacity, wallpaperPath, 0);
            
            if (success)
            {
                string path = wallpaperPath.ToString();
                if (!string.IsNullOrEmpty(path))
                {
                    Console.WriteLine(path);
                }
                else
                {
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("");
        }
    }
}