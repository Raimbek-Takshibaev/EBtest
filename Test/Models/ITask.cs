using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Models
{
    interface ITask
    {
        string Name { get; set; }
        TaskResult Motion();
    }
}
