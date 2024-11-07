using System;
using System.Drawing;
using System.IO;

namespace Task2
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Введите нужную папку на диске");
            string folderPath = Console.ReadLine();

            try
            {
                long size = GetDirectorySize(folderPath);
                Console.WriteLine($"Размер папки: {size} байт");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: {ex}");
            }
        }

        static long GetDirectorySize(string folderPath)
        {
            long size = 0;
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
            if (directoryInfo.Exists)
            {
                FileInfo[] files = directoryInfo.GetFiles();
                foreach (FileInfo file in files)
                {
                    size += file.Length;
                }

                DirectoryInfo[] dirs = directoryInfo.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    size += GetDirectorySize(dir.FullName);
                }
            }
            else
            {
                throw new DirectoryNotFoundException($"Директория {folderPath} не была найдена");
            }
            return size;
        }
    }
}