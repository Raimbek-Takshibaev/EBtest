using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Attributes
{
    abstract class ValidationAttribute : Attribute
    {
        public abstract bool CheckValid(object checkItem);
    }
}
