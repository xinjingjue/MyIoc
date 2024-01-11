using MyIOC.AttributeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIOC.ClassLib
{
    [IOCServer]
    public class student
    {
        [IOCInject]
        public Teacher teacher { get; set; }

        public void StandUp()
        {
            Console.WriteLine($"{teacher.teacherName} 老师好");
        }
    }
}
