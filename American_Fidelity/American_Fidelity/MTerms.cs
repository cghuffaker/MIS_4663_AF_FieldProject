using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace American_Fidelity
{
    public class MTerms
    {
        public string Software_Function { get; set; }

        public MTerms()
        {
            Software_Function = string.Empty;

        }
        public MTerms(string type, int LineNum = 0)
        {
            string[] term = type.Split(',');
            Software_Function = term[0];
        }
    }
}
