using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicHomeWok9.Models
{
    class Student : Person
    {
        private string groupOfStudent;
        public Dictionary<string, int?> StudentMarks { get; set; } = new Dictionary<string, int?>();

        public string GroupOfStudent
        {
            get
            {
                if (groupOfStudent == string.Empty)
                {
                    return "-";
                }
                else
                {
                    return groupOfStudent;
                }
            }

            set
            {
                this.groupOfStudent = value;
            }
        }

        public Student()
        {
            foreach (var item in new Subjects().AllSubjects)
            {
                StudentMarks.Add(item, null);
            }
        }

        public override string GetInfo()
        {
            string info = $"Студет {base.Name} {base.Surname}\n\tГруппа: {this.GroupOfStudent}\n{new string('-',50)}\n";

            foreach (var mark in this.StudentMarks)
            {
                info += $"{mark.Key} -> {mark.Value}\n";
            }

            info += $"{new string('*',50)}\n";

            return info;
        }

    }
}
