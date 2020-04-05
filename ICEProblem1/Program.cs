using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ICEProblem1
{
    class Program
    {
        /*
         * The problem assumes sorted files are given as the input. The problem does not state if the files are sorted in ascending order or descending order.
         * The problem also does not specify if the given three data types are mixed together in a file, or if the file can consist only of one of the given three datatypes.
         * For the purpose of this assignment, the following assumptions are made:
         * -Files are in ascending order
         * -Files can contain all three datatypes
         * 
         * Current project is overengineered to demonstrate moqing for unit testing, dependency injection, and extensibility
         */

        static void Main(string[] args)
        {
            DataStreamMerger merger = new DataStreamMerger();
            using (IDataStream file1 = new ICEFileStream("Input1.txt"))
            {
                using (IDataStream file2 = new ICEFileStream("Input2.txt"))
                {
                    merger.MergeDataStream(file1, file2, "outfile.txt");
                }
            }
            Console.ReadLine();
        }
    }
}
