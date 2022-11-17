﻿namespace HomeWork6
{
    public static class Accountant
    {
        private const string PATH = "E:\\C#\\SigmaSoftware\\HomeWork6\\HomeWork6\\";

        public static async void GetDays(string path)
        {
            List<string> data = File.ReadLines(PATH + path).ToList();

            using (StreamWriter writer = new StreamWriter($"{PATH}LastCheck.txt", false))
            {
                foreach (var line in data)
                {
                    string[] lineArray = line.Split('|');
                    string[] stringDate = lineArray[lineArray.Length - 2].Split('.');
                    DateTime lastDate = new DateTime(int.Parse(stringDate[2]), int.Parse(stringDate[1]), int.Parse(stringDate[0]));
                    
                    await writer.WriteLineAsync("Appartment " + lineArray[0] + " " + lineArray[1] + " Last time checked " + (DateTime.Now - lastDate).Days + " ago");
                }
            }
        }

        public static string? GetDebtor(string path, int quarter)
        {
            if(quarter < 1 || quarter > 4)
                return null;

            string lastName = string.Empty;
            decimal maxSum = 0;
            List<string> data = File.ReadLines(PATH + path).ToList();
            Appartment appartment;

            foreach (var line in data)
            {
                appartment = Parse(line, quarter);
                if (appartment.Accounting.Values.Sum(x => x * appartment.KVPRICE) >= maxSum)
                {
                    lastName = appartment.LastName;
                    maxSum = appartment.Accounting.Values.Sum(x => x * appartment.KVPRICE);
                }
            }

            return lastName;
        }

        public static List<int>? HaveNotUsedElectricityForQuarter(string path, int quarter)
        {
            if (quarter < 1 || quarter > 4)
                return null;

            List<int> appartmentsId = new List<int>();
            List<string> data = File.ReadLines(PATH + path).ToList();
            Appartment appartment;

            foreach (var line in data)
            {
                appartment = Parse(line, quarter);
                if (appartment.Accounting.Values.Sum(x => x) == 0)
                    appartmentsId.Add(appartment.AppartmentId);
            }
            return appartmentsId;
        }

        public static async Task FullReport(string path, int quarter)
        {
            if (quarter < 1 || quarter > 4)
                return;

            List<string> data = File.ReadLines(PATH + path).ToList();
            Appartment appartment;

            using (StreamWriter writer = new StreamWriter($"{PATH}FullReport_{quarter}_Quarter.txt", false))
            {
                foreach (var line in data)
                {
                    appartment = Parse(line, quarter);

                    await writer.WriteLineAsync(appartment.ToString());
                }
            }
        }

        public static async Task ReportFor(string path, int appartmentId, int quarter)
        {
            if (quarter < 1 || quarter > 4)
                return;

            List<string> data = File.ReadLines(PATH + path).ToList();

            foreach (var line in data)
            {
                int num = int.Parse(line.TakeWhile(x => x != '|').ToArray());

                if (num == appartmentId)
                {
                    Appartment appartment = Parse(line, quarter);

                    using (StreamWriter writer = new StreamWriter($"{PATH}{appartment.LastName}_{quarter}_Quarter.txt", false))
                    {
                        await writer.WriteLineAsync(appartment.ToString());
                    }
                }
            }
        }

        private static Appartment Parse(string line, int quarter)
        {
            string[] strAppartment = line.Split('|');
            Appartment appartment = new Appartment(int.Parse(strAppartment[0]), strAppartment[1], strAppartment[2]);
            int quarterStart = 3 * quarter - 2;
            quarter *= 3;

            for (int i = 3; i < strAppartment.Length; i += 2)
            {
                string[] date = strAppartment[i].Split('.');
                if (quarterStart == int.Parse(date[1]) && quarterStart <= quarter)
                {
                    quarterStart++;
                    appartment.AddMonth(new DateOnly(int.Parse(date[2]), int.Parse(date[1]),
                    int.Parse(date[0])), decimal.Parse(strAppartment[i + 1]));
                }
            }

            return appartment;
        }
    }
}