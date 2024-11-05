using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FindBySize.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Search_SearchBySize_file3_4_5_10returned()
        {
            long min = Program.ConvertSizeToBytes("1 МБ");
            long max = Program.ConvertSizeToBytes("15 МБ");
            List<FileData> expected = new List<FileData>()
            {
                new FileData("file3.mp3", 5242880),
                new FileData("file4.zip", 10485760),
                new FileData("file5.png", 15728640),
                new FileData("file10.exe", 3145728)
            };

            List<FileData> actual = Program.Search(min, max);

            Assert.AreEqual(expected.Count, actual.Count);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Name, actual[i].Name);
                Assert.AreEqual(expected[i].Length, actual[i].Length);
            }
        }
    }
}
