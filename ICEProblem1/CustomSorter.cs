using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICEProblem1
{
    public class ICEComparer : ICustomCompare
    {
        public bool IsSortAscending { get; set; } = true;
        public ICEComparer()
        {

        }

        public string Compare(string a, string b)
        {
            int priorityA = 0;
            int priorityB = 0;

            //Setting the sort priority first based on data type
            if (!String.IsNullOrWhiteSpace(a))
            {
                if (DateTime.TryParse(a, out DateTime temp))
                {
                    priorityA = 3;
                }
                else if (Double.TryParse(a, out double temp3))
                {
                    priorityA = 2;
                }
                else
                {
                    priorityA = 1;
                }
            }

            if (!String.IsNullOrWhiteSpace(b))
            {
                if (DateTime.TryParse(b, out DateTime temp2))
                {
                    priorityB = 3;
                }
                else if (Double.TryParse(b, out double temp4))
                {
                    priorityB = 2;
                }
                else
                {
                    priorityB = 1;
                }
            }

            if (priorityA > priorityB)
            {
                return a;
            }
            else if (priorityA < priorityB)
            {
                return b;
            }
            else
            {
                // Determing if a or b wins the comparison since they're the same datatype
                switch (priorityA)
                {
                    case 3:
                        {
                            DateTime x = DateTime.Parse(a);
                            DateTime y = DateTime.Parse(b);

                            if (x < y)
                                return IsSortAscending ? a : b;
                            else if (x > y)
                                return IsSortAscending ? b : a;
                            else
                                return a;
                        }
                    case 2:
                        {
                            Double x = Double.Parse(a);
                            Double y = Double.Parse(b);

                            if (x < y)
                                return IsSortAscending ? a : b;
                            else if (x > y)
                                return IsSortAscending ? b : a;
                            else
                                return a;
                        }
                    case 1:
                        {
                            var sort = new List<string>() { a, b };
                            if (IsSortAscending)
                            {
                                sort.Sort();
                            }
                            else
                            {
                                sort.Sort();
                                sort.Reverse();
                            }
                            return sort[0];
                        }
                    default:
                        return null;
                }
            }
        }
    }
}
