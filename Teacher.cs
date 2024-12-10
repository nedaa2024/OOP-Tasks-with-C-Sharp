using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task_OOP
{
    internal class Teacher
    {
            public string Teacher_Name { get; set; }
            public int Teacher_Id { get; set; }

            public Teacher(string name, int id)
            {
            Teacher_Name = name;
            Teacher_Id = id;
            }
        

    }
}
