namespace HomeWork7
{
    public class Luna
    {
        private string type = string.Empty;
        private string strNumber;

        string[] forbidenSymbols =
        {
            "`", "[", "]", ";", "'", ",",
            "/", ".", "<", ">", "{", "}",
            ":", "?", "!", "@", "#", "$",
            "_", " ", "+", "-", "*", "&"
        };
        string[] americanExpress = { "34", "37" };
        string[] masterCard = { "51", "52", "53", "54", "55" };
        string[] visa = { "4" };

        public Luna(string str)
        {
            foreach (var item in americanExpress)
                if (str.StartsWith(item))
                    if (str.Length == 15)
                        type = "American Express";

            foreach (var item in masterCard)
                if (str.StartsWith(item))
                    if (str.Length == 16)
                        type = "MasterCard";
            
            foreach (var item in visa)
                if (str.StartsWith(item))
                    if (str.Length == 16 || str.Length == 13)
                        type = "Visa";

            //"є ще багато символів, які не можуть входити в номер)
            foreach (var item in forbidenSymbols)
                if (str.Contains(item))
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
