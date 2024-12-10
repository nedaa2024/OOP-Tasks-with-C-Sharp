using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task_OOP
{
    internal class MyGenericList<T>

    {
        private List<T> elements;

        public MyGenericList()
        {
            elements = new List<T>();
        }

        public void AddElement(T element) 
        { 
            elements.Add(element);
        }

        public void DisplayFirstElement() 
        {
            if (elements.Count > 0)
            { 
                Console.WriteLine("The First Element: " + elements[0]);
            }
            else
            {
                Console.WriteLine("You Have An Empty List......."); 
            
            }
        }

        public List<T> GetElements() { return elements; }
    }
}
