using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ICEProblem1.UnitTests
{
    [TestClass]
    public class DataStreamMergerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeDataStream_Throws_Null_Exception_When_null_parameter_is_passed()
        {
            DataStreamMerger merger = new DataStreamMerger();
            merger.MergeDataStream(null, null, null);
        }

        [TestMethod]
        public void MergeDataStream_OutFile_Preserves_Sort_Order_For_Strings()
        {
            var datastream1 = new Mock<IDataStream>();
            var datastream2 = new Mock<IDataStream>();

            datastream1.SetupSequence(x => x.ReadLine()).Returns("ABC").Returns("FooBar");
            datastream1.SetupSequence(x => x.IsEndOfStream()).Returns(false).Returns(false).Returns(false).Returns(false).Returns(true).Returns(true);
            datastream2.SetupSequence(x => x.ReadLine()).Returns("Dog").Returns("Giraffe");
            datastream2.SetupSequence(x => x.IsEndOfStream()).Returns(false).Returns(false).Returns(false).Returns(false).Returns(true).Returns(true);

            DataStreamMerger merger = new DataStreamMerger();
            const string outfile = "test.txt";
            merger.MergeDataStream(datastream1.Object, datastream2.Object, outfile);

            Assert.IsTrue(File.Exists(outfile));

            List<string> values = new List<string>();
            using (StreamReader reader = new StreamReader(outfile))
            {
                while (!reader.EndOfStream)
                {
                    values.Add(reader.ReadLine());
                }
            }

            Assert.AreEqual(4, values.Count);
            Assert.AreEqual("ABC", values[0]);
            Assert.AreEqual("Dog", values[1]);
            Assert.AreEqual("FooBar", values[2]);
            Assert.AreEqual("Giraffe", values[3]);
        }

        //Etc. Other test methods would be added to ensure all code paths and permutations are checked.
    }
}
