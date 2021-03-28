using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicHomeWok9.Models
{
    class Person : IInfoGetter
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual string GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
