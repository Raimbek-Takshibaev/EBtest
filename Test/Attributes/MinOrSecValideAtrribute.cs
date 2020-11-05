using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Attributes
{
    class MinOrSecValideAtrribute : ValidationAttribute
    {
        public string Value { get; set; }
        public MinOrSecValideAtrribute()
        {
        }
        public MinOrSecValideAtrribute(string value)
        {
            Value = value;
        }
        public override bool CheckValid(object checkItem)
        {
            try
            {
                string time = checkItem as string;
                int num = Convert.ToInt32(time);
                return time.Length == 2 && num >= 0 && num <= 60;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
