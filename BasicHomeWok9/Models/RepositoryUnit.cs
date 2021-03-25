using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicHomeWok9.Models
{
    class RepositoryUnit// репозиторий для хранения всех коллекций
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public List<Group> Groups { get; set; } = new List<Group>();
        public Subjects Subjects { get; set; } = new Subjects();
    }
}
