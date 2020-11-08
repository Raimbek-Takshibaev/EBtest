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
                int num = Convert.ToInt32(numStr);
                if(num < 1 || num > 100)
                    return new TaskResult() { IsGood = false, Result = "The number must be between 1 and 100" };
                string result = "";
                if (num < 20)
                    result = SmallFactorial(num).ToString();
                else
                    result = BigFactorial(num);
                return new TaskResult() { IsGood = true, Result = result };
            }
            catch (FormatException)
            {
                return new TaskResult() { IsGood = false, Result = "The text in the file must be natural number" };
            }
        }
        public int SmallFactorial(int num)
        {
            if (num == 0)
                return 1;
            return num * SmallFactorial(num - 1);
        }
        public string BigFactorial(int num)
        {
            if (num == 0)
                return "1";
            return MultiplyBigNums(BigFactorial(num - 1), num.ToString());
        }
        public string MultiplyBigNums(string first, string second)
        {
            string[] columnElements = new string[second.Length];
            for (int i = second.Length - 1; i >= 0; i--)
            {
                List<int> products = new List<int>();
                for (int a = first.Length - 1; a >= 0; a--)
                {
                    products.Add(Convert.ToInt32(second[i].ToString()) * Convert.ToInt32(first[a].ToString()));
                }
                SetColumnNums(ref products);
                string zeros = "";
                for (int a = i; a < columnElements.Length - 1; a++)
                    zeros += "0";
                columnElements[i] = GetNumFromQuery(products) + zeros;
            }
            for (int i = columnElements.Length - 1; i > 0; i--)
            {
                string zeros = "";
                for (int a = 0; a < columnElements[0].Length - columnElements[i].Length; a++)
                    zeros += "0";
                columnElements[i] = zeros + columnElements[i];
            }
            List<int> sums = new List<int>();
            for (int i = columnElements[0].Length - 1; i >= 0; i--)
            {
                int sum = 0;
                for (int a = 0; a < columnElements.Length; a++)
                {
                    sum += Convert.ToInt32(columnElements[a][i].ToString());
                }
                sums.Add(sum); 
            }
            SetColumnNums(ref sums);
            return GetNumFromQuery(sums);
        }
        private void SetColumnNums(ref List<int> nums)
        {
            for (int i = 0; i < nums.Count - 1; i++)
            {
                string numStr = nums[i].ToString();
                if (numStr.Length == 2)
                {
                    nums[i + 1] += Convert.ToInt32(numStr[0].ToString());
                    nums[i] = Convert.ToInt32(numStr[1].ToString());
                }
            }
        }
        private string GetNumFromQuery(List<int> nums)
        {
            string num = "";
            for (int i = nums.Count - 1; i >= 0; i--)
            {
                num += nums[i].ToString();
            }
            return num;
        }
    }
}
