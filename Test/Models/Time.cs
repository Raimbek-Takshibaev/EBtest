using System;
using System.Collections.Generic;
using System.Text;
using Test.Attributes;

namespace Test.Models
{
    class Time
    {
        [MaxValue(12)]
        public int Hours { get; set; }
        [MaxValue(60)]
        public string Minutes { get; set; }
        [MaxValue(60)]
        public string Seconds { get; set; }
        [IsInQuery(new string[] { "AM", "PM" })]
        public string Period { get; set; }
    }
}
