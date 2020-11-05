using System;
using System.Collections.Generic;
using System.Text;
using Test.Models;

namespace Test.Attributes
{
    class MaxValueAttribute : ValidationAttribute
    {
        public int Value { get; set; }
        public MaxValueAttribute()
        {
        }
        public MaxValueAttribute(int value)
        {
            Value = value;
        }
        public override bool CheckValid(object checkItem)
        {
            try
            {
                int value = Convert.ToInt32(checkItem);
                return Value >= value && value >= 0;
            }
            catch (FormatException)
            {
                return false;
            }        
        }
    }
}
