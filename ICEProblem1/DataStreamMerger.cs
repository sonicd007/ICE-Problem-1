using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICEProblem1
{
    //Class supports various custom comparers, DI, and unit testing
    public class DataStreamMerger
    {
        ICustomCompare comparer;
        public DataStreamMerger()
        {
            comparer = new ICEComparer();
        }

        public DataStreamMerger(ICustomCompare comparer)
        {
            if (null == comparer)
                throw new ArgumentNullException();

            this.comparer = comparer;
        }

        public void MergeDataStream(IDataStream stream1, IDataStream stream2, string outputPath)
        {
            if (null == stream1 || null == stream2 || String.IsNullOrWhiteSpace(outputPath))
                throw new ArgumentNullException();

            string line1 = string.Empty;
            string line2 = string.Empty;
            string outLine = string.Empty;

            using (StreamWriter outFile = new StreamWriter(outputPath))
            {
                while (true)
                {
                    if (String.IsNullOrWhiteSpace(line1))
                    {
                        while (!stream1.IsEndOfStream() && String.IsNullOrWhiteSpace(line1))
                        {
                            line1 = stream1.ReadLine();
                        }
                    }

                    if (String.IsNullOrWhiteSpace(line2))
                    {
                        while (!stream2.IsEndOfStream() && String.IsNullOrWhiteSpace(line2))
                        {
                            line2 = stream2.ReadLine();
                        }
                    }

                    if (String.IsNullOrWhiteSpace(line1) && String.IsNullOrWhiteSpace(line2))
                        break;

                    outLine = comparer.Compare(line1, line2);
                    outFile.WriteLine(outLine);

                    if (outLine == line1)
                        line1 = string.Empty;
                    else
                        line2 = string.Empty;
                }
            }
        }
    }
}
