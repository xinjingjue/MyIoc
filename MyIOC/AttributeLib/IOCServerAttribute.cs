using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIOC.AttributeLib
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class IOCServerAttribute:Attribute
    {
        public IOCServerAttribute() { } 
    }
}
