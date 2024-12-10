using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task_OOP
{
    internal class City
    {
            public string City_Name { get; set; }
            public string City_Region { get; set; }
            public List<School> Schools { get; set; }

            public City(string name, string region)
            {
               City_Name   = name;
                City_Region  = region;
                Schools = new List<School>();
            }
        

    }
}
