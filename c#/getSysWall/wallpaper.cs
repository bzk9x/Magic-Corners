using System;
using System.Runtime.InteropServices;
using System.Text;

partial class Program
{
    // Import Windows API function
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
            // Create buffer for wallpaper path
            StringBuilder wallpaperPath = new StringBuilder(260);
            
            // Get the current wallpaper path
            bool success = SystemParametersInfo(SPI_GETDESKWALLPAPER, wallpaperPath.Capacity, wallpaperPath, 0);
            
            if (success)
            {
                string path = wallpaperPath.ToString();
                if (!string.IsNullOrEmpty(path))
                {
                    Console.WriteLine($"Current wallpaper path: {path}");
                }
                else
                {
                    Console.WriteLine("No custom wallpaper is currently set (using default)");
                }
            }
            else
            {
                Console.WriteLine("Failed to get wallpaper path");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}