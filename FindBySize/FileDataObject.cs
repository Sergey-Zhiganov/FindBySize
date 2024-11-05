using System.Collections.Generic;
using System.IO;

namespace FindBySize
{
    public class FileDataObject
    {
        public static List<FileData> GetFiles()
        {
            string path = "D:\\МПТ\\4 семестр\\Экзамен АИП";

            List<FileData> files = new List<FileData>();
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] fileInfos = directoryInfo.GetFiles();

            foreach (FileInfo fileInfo in fileInfos)
            {
                files.Add(new FileData(fileInfo.Name, fileInfo.Length));
            }

            return files;
        }
    }
}
