using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonManipulator
{
    public static class LocalStorage
    {
        static  Dictionary<string,string> _data = null;
        public static string GetValue(string name, string defaultValue)
        {
            string result = defaultValue;

            if (_data == null)
                Load();

            if (_data.Keys.Contains(name))
            {
                result = _data[name];
            }

            return result;
        }

        public static void SetValue(string name, string value)
        {
            if (_data == null)
                Load();

            if(_data.Keys.Contains(name))
            {
                _data[name] = value;
            }
            else
            {
                _data.Add(name, value);
            }

        }

        private static void Load()
        {
            string jsonData = string.Empty;
            if (System.IO.File.Exists("settings.json"))
            {
                jsonData  = System.IO.File.ReadAllText("settings.json");
                _data = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
            }
            else
            {
                _data = new Dictionary<string, string>();
            }
        }

        private static void Save()
        {
            string jsonData = JsonConvert.SerializeObject(_data, Formatting.Indented);
            System.IO.File.WriteAllText("settings.json", jsonData);
        }
    }
}
