using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIOC.AttributeLib
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =true)]
    public class IOCInjectAttribute:Attribute
    {
        public IOCInjectAttribute()
        {
            
        }
    }
}
