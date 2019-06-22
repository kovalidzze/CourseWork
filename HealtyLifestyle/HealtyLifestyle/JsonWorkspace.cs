using System;
using System.IO;
using System.Threading.Tasks;
namespace HealtyLifestyle
{
    public class JsonSaver
    {

        public static async Task Save(ITable table)
        {
            string json = table.GetJson();
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), table.GetFileName());
            using (var writer = File.CreateText(backingFile))
            {
                await writer.WriteLineAsync(json);
            }
        }

        //public static void Save(ITable table)
        //{
        //    string json = JsonConvert.SerializeObject(table);
        //    System.IO.File.WriteAllText(table.GetFileName(), json);
        //}
    }
    public class JsonLoader
    {
        public static void Load(ITable table)
        {
            table.Load();
        }

    }

}
