using System;
using System.IO;
using NUnit.Framework;
using ServantSoftware.FolderLister;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    public class FolderListerTests
    {
        [SetUp]
        public void Setup()
        {
            CreateTestFiles(100);
        }

        [TearDown]
        public void Cleanup()
        {
            string rootFolder = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles");

            DeleteTestFiles(rootFolder);
        }

        private void DeleteTestFiles(string folder)
        {
            if (Directory.Exists(folder))
            {
                foreach(var file in Directory.EnumerateFiles(folder))
                {
                    File.Delete(file);
                }

                Directory.Delete(folder, true);
            }
        }

        private void CreateTestFiles(int count)
        {
            string rootFolder = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles");

            if (Directory.Exists(rootFolder) == false)
            {
                Directory.CreateDirectory(rootFolder);
            }

            for (int i = 1; i <= count; i++)
            {
                string filename = $"TestFile{i}.txt";

                using (var testFile = File.CreateText(Path.Combine(rootFolder, filename)))
                {
                    testFile.WriteLine(filename);
                }
            }
        }

        [Test]
        public void Test_CanGetCountOfAllFilesInFolder()
        { 
            string rootFolder = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles");
            int expected = 100;

            var results = new FolderListService().GetFiles(rootFolder, "*.*", recursive: false);

            Assert.AreEqual(expected: expected, actual: results.Count());
        }
    }
}