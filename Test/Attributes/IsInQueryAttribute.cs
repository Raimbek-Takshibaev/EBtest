using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Attributes
{
    class IsInQueryAttribute : ValidationAttribute
    {
        public string[] Values { get; set; }
        public IsInQueryAttribute()
        { }
        public IsInQueryAttribute(string[] values)
        {
            Values = values;
        }
        public override bool CheckValid(object checkItem)
        {
            string word = checkItem as string;
            foreach (string value in Values)
            {
                if (value == word)
                    return true;
            }
            return false;
        }
    }
}
