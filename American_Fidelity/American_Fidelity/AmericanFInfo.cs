using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace American_Fidelity
{
    public class AmericanFInfo
    {
        public string Software { get; set; }
        public string produced_by { get; set; }
        public string most_broad_definition { get; set; }
        public string verb { get; set; }

        public string description { get; set; }
        public string website { get; set; }


        public AmericanFInfo()
        {
            Software = string.Empty;
            produced_by = string.Empty;
            most_broad_definition = string.Empty;
            verb = string.Empty;
            description = string.Empty;
            website = string.Empty;
        }
        public AmericanFInfo(string type, int LineNum = 0)
        {
            string[] term = type.Split(',');
            Software = term[0];
            produced_by = term[1];
            most_broad_definition = term[2];
            verb = term[3];
            description = term[4];
            website = term[5];

        }
        public override string ToString()
        {
            return (Software);
        }


    }
}
