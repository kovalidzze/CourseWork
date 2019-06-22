using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HealtyLifestyle
{
    public class Results : ITable
    {
        public static List<Result> results = new List<Result>();

        public string GetJson()
        {
            return JsonConvert.SerializeObject(results);
        }


        public void Load()
        {
            var json = "";
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), GetFileName());

            if (backingFile == null || !File.Exists(backingFile))
            {
                throw new Exception("ASA");
            }

            using (var reader = new StreamReader(backingFile, true))
            {
                string line;
                while ((line =  reader.ReadLine()) != null)
                {
                    json += line;  
                }
            }
            results = JsonConvert.DeserializeObject<List<Result>>(json);
        }


        //public void Load()
        //{
        //    string json = System.IO.File.ReadAllText(GetFileName());
        //    results = JsonConvert.DeserializeObject<List<Result>>(json);
        //}

        public static void Add(Result item)
        {
            results.Add(item);
        }

        public static List<Result> GetAll()
        {
            return results;
        }

        public string GetFileName()
        {
            return "results.json";
        }
    }
}
