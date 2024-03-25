using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhập đường dẫn của file nguồn: ");
        string sourceFilePath = Console.ReadLine();

        Console.Write("Nhập đường dẫn của thư mục đích: ");
        string destinationFolderPath = Console.ReadLine();

        try
        {
            CopyFile(sourceFilePath, destinationFolderPath);
            Console.WriteLine("Sao chép file thành công.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File nguồn không tồn tại.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Thư mục đích không tồn tại.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Lỗi I/O: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi: {ex.Message}");
        }
    }

    static void CopyFile(string sourceFilePath, string destinationFolderPath)
    {
        string fileName = Path.GetFileName(sourceFilePath);
        string destinationFilePath = Path.Combine(destinationFolderPath, fileName);

        using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
        {
            using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    destinationStream.Write(buffer, 0, bytesRead);
                }
            }
        }
    }
}