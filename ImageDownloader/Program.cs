using System;
using System.IO;
using System.Net;

public class ImageSaver
{
    public void SaveImage(string filepath, byte[] imageBytes)
    {
        FileStream fs = new FileStream(filepath, FileMode.Create);

        using (BinaryWriter bw = new BinaryWriter(fs))
        {
            bw.Write(imageBytes);
        }
        Console.WriteLine("Image downloaded successfully. Please check Pictures folder.");

    }
}

public class Program
{
    public static void Main()
    {
        byte[] imageBytes = GetImageBytes();
        ImageSaver saver = new ImageSaver();
        saver.SaveImage("C:\\Users\\user\\Pictures\\SavedImage.png", imageBytes);
    }
    public static byte[] GetImageBytes()
    {
        string imageURL = "https://getwallpapers.com/wallpaper/full/4/c/4/1481382-vertical-bliss-desktop-wallpaper-1920x1200-1080p.jpg";
        byte[] imageBytes;
        using (WebClient webc = new WebClient())
        {
            imageBytes = webc.DownloadData(imageURL);
        }
        return imageBytes;
    }
}
