namespace HomeWork6
{// пропоную усне обговорення архітектури.
    public class Accountant
    {
        private readonly string PATH;
        public Accountant(string path)
            => PATH = path;

        public async Task GetDays()
        {
            List<string> data = File.ReadLines(PATH).ToList();

            using (StreamWriter writer = new StreamWriter($"{PATH}LastCheck.txt", false))
            {
                foreach (var line in data)
                {
                    string[] lineArray = line.Split('|');
                    string[] stringDate = lineArray[lineArray.Length - 2].Split('.');
                    DateTime lastDate = new DateTime(int.Parse(stringDate[2]), int.Parse(stringDate[1]), int.Parse(stringDate[0]));
                    
                    await writer.WriteLineAsync("Appartment " + lineArray[0] + " " + lineArray[1] + " Last time checked " + (DateTime.Now - lastDate).Days + " days ago");
                }
            }
        }

        // Завдання "При відомій вартості кВт енергії знайти прізвище власника з найбільшою заборгованістю."
        // Тому я не записував це в файл. Ну це було б трохи безглуздо отримати файл з одним прізвищем.
        public string? GetDebtor(int quarter)
        {
            if(quarter < 1 || quarter > 4)
                return null;

            string lastName = string.Empty;
            decimal maxSum = 0;
            List<string> data = File.ReadLines(PATH).ToList();
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

        public List<int>? HaveNotUsedElectricityForQuarter(int quarter)
        {
            List<int> appartmentsId = new List<int>();
            List<string> data = File.ReadLines(PATH).ToList();
            Appartment appartment;

            foreach (var line in data)
            {
                appartment = Parse(line, quarter);
                if (appartment.Accounting.Values.Sum(x => x) == 0)
                    appartmentsId.Add(appartment.AppartmentId);
            }
            return appartmentsId;
        }

        public async Task ElectricityNotUsed(int quarter)
        {
            if (quarter < 1 || quarter > 4)
                return;

            List<int>? appartmentsId = HaveNotUsedElectricityForQuarter(quarter);

            using (StreamWriter writer = new StreamWriter($"{PATH}Quarter_{quarter}_NoElectricity.txt", false))
            {
                if (appartmentsId == null || appartmentsId.Count == 0)
                {
                    await writer.WriteLineAsync("Every apartment have been used electricity");
                    return;
                }

                foreach (var item in appartmentsId)
                    await writer.WriteLineAsync(item.ToString());
            }
        }

        public async Task FullReport(int quarter)
        {
            if (quarter < 1 || quarter > 4)
                return;

            List<string> data = File.ReadLines(PATH).ToList();
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

        public async Task ReportFor(int appartmentId, int quarter)
        {
            if (quarter < 1 || quarter > 4)
                return;

            List<string> data = File.ReadLines(PATH).ToList();

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
        private Appartment Parse(string line, int quarter)
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
