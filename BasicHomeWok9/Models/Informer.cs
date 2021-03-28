using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicHomeWok9.Models
{
    static class Informer 
    {
        static public string GetInfoAbouCurrentPerson(IInfoGetter infoGetter)
        {
            return infoGetter.GetInfo();
        }
    }
}
