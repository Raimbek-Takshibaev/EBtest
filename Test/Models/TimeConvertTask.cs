using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Test.Attributes;

namespace Test.Models
{
    class TimeConvertTask : ITask
    {
        public Dictionary<string, int> timeCountings;
        public string Name { get; set; }
        public TimeConvertTask(string name)
        {
            timeCountings = new Dictionary<string, int>();
            timeCountings.Add("AM", 0);
            timeCountings.Add("PM", 12);
            Name = name;
        }
        public TaskResult Motion()
        {
            string timeStr = File.ReadAllText("../../../Time.txt");           
            try
            {
                string[] timeElements = timeStr.Split(new char[] { ':' });
                Time time = new Time() {
                    Hours = Convert.ToInt32(timeElements[0]),
                    Minutes = timeElements[1],
                    Seconds = $"{timeElements[2][0]}{timeElements[2][1]}", // seconds
                    Period = $"{timeElements[2][2]}{timeElements[2][3]}" // AM/PM
                };
                TaskResult result = CheckValidation(time);
                if (!result.IsGood)
                    return result;
                time.Hours += timeCountings[time.Period];
                return new TaskResult() { IsGood = true, Result = $"{time.Hours}:{time.Minutes}:{time.Seconds}" };
            }
            catch (Exception)
            {
                return new TaskResult() { IsGood = false, Result = "Time must be in hh:mm:ssAM/PM format" };
            }
        }
        public TaskResult CheckValidation(Time time)
        {
            Type t = typeof(Time);           
            PropertyInfo[] props = t.GetProperties();
            foreach (PropertyInfo property in props)
            {
                object[] attrs = property.GetCustomAttributes(false);
                foreach (ValidationAttribute attr in attrs)
                {
                    if (!attr.CheckValid(property.GetValue(time)))
                        return new TaskResult()
                        {
                            IsGood = false,
                            Result = "Time wrote in right format, but with incorrect values"
                        };
                }
            }
            return new TaskResult()
            {
                IsGood = true,
                Result = "good"
            };
        }
    }
}
