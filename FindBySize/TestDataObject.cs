using System.Collections.Generic;

namespace FindBySize
{
    public class TestDataObject
    {
        public static List<FileData> GetTestFiles()
        {
            List<FileData> testFiles = new List<FileData>
            {
                new FileData("file1.txt", 512),
                new FileData("file2.doc", 2048),
                new FileData("file3.mp3", 5242880),
                new FileData("file4.zip", 10485760),
                new FileData("file5.png", 15728640),
                new FileData("file6.mov", 1073741824),
                new FileData("file7.iso", 2147483648),
                new FileData("file8.pdf", 1024),
                new FileData("file9.html", 10240),
                new FileData("file10.exe", 3145728)
            };

            return testFiles;
        }
    }
}