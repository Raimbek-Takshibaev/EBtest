using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Test.Models
{
    class FactorialTask : ITask
    {
        public string Name { get; set; }
        public FactorialTask(string name)
        {
            Name = name;
        }
        public TaskResult Motion()
        {
            string numStr = File.ReadAllText("../../../FactorialNum.txt");
            try
            {
                ulong num = Convert.ToUInt64(numStr);
                if(num < 1 || num > 100)
                    return new TaskResult() { IsGood = false, Result = "The number must be between 1 and 100" };
                return new TaskResult() { IsGood = true, Result = Factorial(num).ToString() };
            }
            catch (FormatException)
            {
                return new TaskResult() { IsGood = false, Result = "The text in the file must be natural number" };
            }
        }
        public ulong Factorial(ulong num)
        {
            if (num == 0)
                return 1;
            return num * Factorial(num - 1);
        }
    }
}
