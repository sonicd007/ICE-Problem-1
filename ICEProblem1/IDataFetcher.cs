using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICEProblem1
{
    public interface IDataStream : IDisposable
    {
        void OpenStream(string path);
        string ReadLine();
        bool IsEndOfStream();
    }
}
