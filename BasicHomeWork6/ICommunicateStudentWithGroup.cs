using System;
using System.Collections.Generic;
using System.Text;

namespace BasicHomeWork6
{
    interface ICommunicateStudentWithGroup
    {
        //string NumberOfGroup { get; }

        event StudentTransferHandler StudentTransferHandler;
    }
}
