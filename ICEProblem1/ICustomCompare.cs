using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICEProblem1
{
    //Interface created so dependency injection could be used or unit testing of comparers can be done
    public interface ICustomCompare
    {
        string Compare(string a, string b);
    }
}
