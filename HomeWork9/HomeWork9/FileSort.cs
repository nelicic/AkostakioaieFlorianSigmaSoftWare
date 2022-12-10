namespace HomeWork9
{
    public class FileSort : MergeSplit
    {
        private readonly string _path;
        private int _filesCount;
        private int _totalCount;
        public FileSort(string path) => _path = path;

        public void Sort(string path)
        {
            using StreamReader fs = new(_path + path);
            int count = 1;

            while (!fs.EndOfStream)
            {
                string? line = fs.ReadLine();
                int[] array = Array.ConvertAll(line.Trim().Split(" "), x => int.Parse(x));
                _totalCount += array.Length;
                array = SortArray(array, 0, array.Length - 1);
                
                using (var fw = new StreamWriter(_path + count + ".txt", false))
                {
                    foreach (int i in array)
                        fw.Write(i + " ");
                }

                count++;
            }

            _filesCount = count;
            MergeFiles();
        }

        private void MergeFiles()
        {
            File.Delete(_path + "result" + ".txt");
            int min = int.MaxValue;
            int minFileIndex = 0;
            int[] newArray;

            for (int j = 0; j < _totalCount; j++)
            {
                min = int.MaxValue;
                for (int i = 1; i < _filesCount; i++)
                {
                    using StreamReader fs = new(_path + i + ".txt");

                    string? line = fs.ReadLine();
                    if (line == null)
                        continue;
                    int[] array = Array.ConvertAll(line.Trim().Split(" "), x => int.Parse(x));

                    if (array != null && array[0] < min)
                    {
                        min = array[0];
                        minFileIndex = i;
                    }
                }

                using (StreamReader fr = new(_path + minFileIndex + ".txt"))
                {
                    string? line = fr.ReadLine();
                    if (line == null)
                        continue;
                    newArray = Array.ConvertAll(line.Trim().Split(" "), x => int.Parse(x));
                }

                using (StreamWriter fw = new(_path + minFileIndex + ".txt", false))
                {
                    for (int i = 1; i < newArray.Length; i++) 
                        fw.Write(newArray[i] + " ");
                }

                using (StreamWriter fw = new(_path + "result" + ".txt", true))
                {
                    fw.Write(min + " ");
                }
            }

            Clean();
        }

        private void Clean()
        {
            for (int i = 1; i <= _filesCount; i++)
                File.Delete(_path + i + ".txt");
        }
    }
}
