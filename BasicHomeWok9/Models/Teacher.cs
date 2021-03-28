using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicHomeWok9.Models
{
    class Teacher : Person
    {
        public string Category { get; set; }
        public string NumberOfGroup { get; set; }


        public override string GetInfo()
        {
            string info = $"Учитель {base.Name} {base.Surname}\n\tГруппа: {this.NumberOfGroup}\n\tКатегория: {this.Category}\n{new string('-', 50)}\n";
          
            info += $"{new string('*', 50)}\n";

            return info;
        }
    }



}
