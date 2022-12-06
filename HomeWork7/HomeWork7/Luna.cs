namespace HomeWork7
{
    public class Luna
    {
        private string type;
        private string strNumber;

        public Luna(string str)
        {
            if (str.StartsWith("34") || str.StartsWith("37") && str.Length == 15)
                type = "American Express";

            if (str.StartsWith("51") || str.StartsWith("51")
                || str.StartsWith("53") || str.StartsWith("54")
                || str.StartsWith("55") && str.Length == 16)
                type = "MasterCard";

            if (str.StartsWith("4") && (str.Length == 16 || str.Length == 13))
                type = "Visa";
//"є ще багато символів, які не можуть входити в номер)
            if (str.Contains(" ") || str.Contains("-"))
                type = "Invalid";

            strNumber = str;
        }

        public bool IsValid()
        {
            var nums = strNumber.Select(x => int.Parse(x.ToString())).ToList();
//алгоритмічно не правильно 
            bool flag = false;
            for (int i = nums.Count - 1; i >= 0; i--)
            {
                if (flag)
                {
                    nums[i] *= 2;
                    if (nums[i] >= 10)
                        nums[i] = nums[i] % 10 + nums[i] / 10;
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }

            return nums.Sum() % 10 == 0;
        }

        public override string ToString()
        {
            string str = $"Number: {strNumber}\n";
            if (type == "Invalid")
                return str;

            str += $"{(IsValid() == true ? type : "INVALID")}";
            return str;
        }
    }
}
