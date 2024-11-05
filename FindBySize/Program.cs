using System;
using System.Collections.Generic;

namespace FindBySize
{
    public class Program
    {
        static void Main()
        {
            Console.Write("Введите минимальный размер файла (в формате '5 КБ'): ");
            long min = ConvertSizeToBytes(Console.ReadLine());

            Console.Write("Введите максимальный размер файла (в формате '15 МБ'): ");
            long max = ConvertSizeToBytes(Console.ReadLine());

            Search(min, max);
        }

        public static long ConvertSizeToBytes(string size)
        {
            size = size.Trim();
            string[] strings = size.Split(' ');

            if (strings.Length != 2) throw new ArgumentException("Ожидался ввод двух параметров (число и размерность)");

            if (!long.TryParse(strings[0], out long number)) throw new ArgumentException("Первый параметр должен быть числом");


            switch (strings[1].ToUpper())
            {
                case "Б": return number;
                case "КБ": return number * (long)Math.Pow(1024, 1);
                case "МБ": return number * (long)Math.Pow(1024, 2);
                case "ГБ": return number * (long)Math.Pow(1024, 3);
            };

            throw new ArgumentException("Неверный формат второго параметра (доступно: Б, КБ, МБ, ГБ)");

        }

        public static string ConvertBytesToSize(long bytes)
        {
            if (bytes < 0) throw new ArgumentException("Размер не может быть отрицательным");

            string[] units = { "Б", "КБ", "МБ", "ГБ", "ТБ" };
            int unitIndex = 0;
            double size = bytes;

            while (size >= 1024 && unitIndex < units.Length - 1)
            {
                size /= 1024;
                unitIndex++;
            }

            return $"{size:0.##} {units[unitIndex]}";
        }

        public static List<FileData> Search(long min, long max)
        {
            //List<FileData> files = FileDataObject.GetFiles();
            List<FileData> files = TestDataObject.GetTestFiles();

            List<FileData> results = new List<FileData>();

            Console.WriteLine("Найденные файлы:");

            foreach (FileData file in files)
            {
                if (file.Length >= min && file.Length <= max) {
                    results.Add(file);

                    Console.WriteLine($"{file.Name} - {ConvertBytesToSize(file.Length)}");
                }
            }

            Console.WriteLine($"Всего файлов: {results.Count}");

            return results;
        }
    }
}
