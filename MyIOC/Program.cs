using MyIOC.ClassLib;
using MyIOC.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIOC
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            IOCFactory Container = new IOCFactory();

            Container.LoadAssmaly("MyIOC");

            student student = (student)Container.GetObject(typeof(student).Name);

            student.StandUp();

            Console.ReadKey();

        }
    }
}
