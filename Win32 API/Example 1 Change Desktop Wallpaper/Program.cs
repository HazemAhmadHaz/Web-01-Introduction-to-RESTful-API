using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Example_1_Change_Desktop_Wallpaper
{
    internal class Program
    {
        // Import the SystemParametersInfo function from user32.dll
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SystemParametersInfo(
            uint action, uint uParam, string vParam, uint winIni);

        // Constants for the function
        public static readonly uint SPI_SETDESKWALLPAPER = 0x14;
        public static readonly uint SPIF_UPDATEINIFILE = 0x01;
        public static readonly uint SPIF_SENDCHANGE = 0x02;

        static void Main()
        {
            // The path to the wallpaper image
            Console.Write("Enter the full path of the wallpaper image (e.g., C:\\pics\\newpic.jpg): ");
            string wallpaperPath = (Console.ReadLine() ?? "").Trim().Trim('"');

            if (!File.Exists(wallpaperPath))
            {
                Console.WriteLine("The specified file does not exist.");
                return;
            }

            // Set the wallpaper
            SetWallpaper(wallpaperPath);
            Console.ReadKey();

        }

        public static void SetWallpaper(string path)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
            Console.WriteLine("Wallpaper changed successfully!");
        }
    }
}
