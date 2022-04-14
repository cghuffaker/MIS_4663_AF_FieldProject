using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace American_Fidelity
{
    public class Software
    {
        public string Name { get; set; }
        public string Manufacturer_Name { get; set; }

        public string? Product_Family_Name { get; set; }

        public string Product_Name { get; set; }
        public string Software_Acquisition_Method { get; set; }
        public string GUID { get; set; }
        public string? Description { get; set; }
        public string? Link_1 { get; set; }

        public  Software()
        {
            Name = string.Empty;

            Manufacturer_Name = string.Empty;

            Product_Family_Name = string.Empty;

            Product_Name = string.Empty;

            Software_Acquisition_Method = string.Empty;

            GUID = string.Empty;

            Description = string.Empty;
                
            Link_1 = string.Empty;

        }

        public Software(string info, int LineNum = 0)
        {
            string[] pieces = info.Split(',');
            Name = pieces[0];
            Manufacturer_Name = pieces[1];
            Product_Family_Name = pieces[2];
            Product_Name = pieces[3];
            Software_Acquisition_Method = pieces[4];
            GUID = pieces[5];
            Description = pieces[6];
            Link_1 = pieces[7];

        }
        public override string ToString()
        {
            return Name;
        }
    }
}
