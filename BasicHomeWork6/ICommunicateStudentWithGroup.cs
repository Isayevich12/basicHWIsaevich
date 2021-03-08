using System;
using System.Collections.Generic;
using System.Text;

namespace BasicHomeWork6
{
    interface ICommunicateStudentWithGroup// интерфейс для того чтоб студент мог ограниченно взаимодействовать с группой (в данном случае просто знал ее номер)
    {
        string NumberOfGroup { get; }

    }
}
