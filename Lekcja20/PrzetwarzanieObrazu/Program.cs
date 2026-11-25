using IronSoftware.Drawing;
using System.Numerics;

class Program
{
    // Path to input and output image file
    // The file should be located in the same directory as the .exe application
    public static string imagePath = "data/Tapir.jpg";
    public static string newImageSavePath = "newImage.jpg";

    public static void Main(string[] args)
    {
    }

    public static void IncreaseImageBrightness(AnyBitmap img)
    {
    }
    public static void DecreaseImageBrightness(AnyBitmap img)
    {
    }

    public static void ReplaceColors(AnyBitmap img)
    {
    }

    // Converts user-provided RGB values into a Color object
    public static Color ConvertStringToColor(string rgb)
    {
        int r, g, b;

        try
        {
            string[] rgbParts = rgb.Split(',');
            r = int.Parse(rgbParts[0]);
            g = int.Parse(rgbParts[1]);
            b = int.Parse(rgbParts[2]);
            return Color.FromArgb(r, g, b);
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid color input. Setting default color (black).");
            return Color.Black;
        }
    }

    // Prevents values from exceeding the 0–255 RGB range
    public static int ClampValue(int value)
    {
        if (value < 0) return 0;
        if (value > 255) return 255;

        return value;
    }

    // Loads image from given path and displays message if error occurs
    public static AnyBitmap LoadImage(string filePath)
    {
        if (File.Exists(filePath) == false) return null;

        try
        {
            AnyBitmap bitmap = new AnyBitmap(filePath);
            return bitmap;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}