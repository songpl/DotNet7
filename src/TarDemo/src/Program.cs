using System.Formats.Tar;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // It will be throw IOException,
        // if the destination file already exists.
        if (File.Exists(@"..\TarDemo.tar"))
        {
            File.Delete(@"..\TarDemo.tar");
        }

        // Create a .tar file with the specified directory.
        await TarFile.CreateFromDirectoryAsync(
            @".\", // current directory
            @"..\TarDemo.tar", // .tar file in parent directory
            false
            );

        // It will be throw DirectoryNotFoundException,
        // if the destination folder doesn't exists.
        Directory.CreateDirectory(@"..\Extracted");

        // Extracts the .tar file to the specified directory.
        await TarFile.ExtractToDirectoryAsync(
            @"..\TarDemo.tar",
            @"..\Extracted",
            true
            );

        Console.WriteLine("Hello, World!");
    }
}
