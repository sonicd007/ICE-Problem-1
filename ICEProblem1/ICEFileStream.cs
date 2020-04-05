using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICEProblem1
{
    public class ICEFileStream : IDataStream
    {
        StreamReader reader;
        public ICEFileStream()
        {

        }

        public ICEFileStream(string fileName)
        {
            if (String.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException();

            reader = new StreamReader(fileName);
        }

        public void OpenStream(string filePath)
        {
            if (null != reader)
                reader.Dispose();

            reader = new StreamReader(filePath);
        }
        public void Dispose()
        {
            if (null != reader)
                reader.Dispose();
        }

        public string ReadLine()
        {
            if (!reader.EndOfStream)
                return reader.ReadLine();
            else
                return null;
        }

        public bool IsEndOfStream()
        {
            if (null != reader)
                return reader.EndOfStream;

            return true;
        }
    }
}
