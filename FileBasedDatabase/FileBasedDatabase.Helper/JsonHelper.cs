using FileBasedDatabase.Data.Entities;
using System.Collections.Generic;
using System.IO;

namespace FileBasedDatabase.Helper
{
    public class JsonHelper
    {
        private static string _path { get; set; }
        public static void Initial(string path, string fileName)
        {          
            _path = path + "\\" + fileName + ".json";

            if (!File.Exists(_path))
            {
                string content = Newtonsoft.Json.JsonConvert.SerializeObject(new Data.Entities.BaseDatabase()
                {
                    Books = new List<Book>(),
                    Visitors = new List<Visitor>()
                });
                Write(content);
            }
        }

        public static void Write(string content)
        {
            File.WriteAllText(_path, content);
        }

        public static string Read()
        {
            string content = File.ReadAllText(_path);
            return content;
        }

        public static Data.Entities.BaseDatabase GetDatabase()
        {
            string content = Read();
            Data.Entities.BaseDatabase baseDatabase = Newtonsoft.Json.JsonConvert.DeserializeObject<Data.Entities.BaseDatabase>(content);

            return baseDatabase;
        }
        
        public static void SetDatabase(Data.Entities.BaseDatabase baseDatabase)
        {
            string content = Newtonsoft.Json.JsonConvert.SerializeObject(baseDatabase);
            Write(content);
        }
    }
}