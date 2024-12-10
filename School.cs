using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task_OOP
{
    internal class School
    {
       
            public string School_Name { get; set; }
            public int School_Space { get; set; }
            public List<Teacher> Teachers { get; set; }

            public School(string name, int space)
            {
            School_Name = name;
            School_Space = space;
            Teachers = new List<Teacher>();
            }
        

    }
}
