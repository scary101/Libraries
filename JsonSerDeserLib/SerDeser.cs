using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace JsonSerDeserLib
{
    public class SerDeser
    {
        private static string _path { get; set; }

        public SerDeser(string path)
        {
            _path = path;
        }

        public void SerData<T>(List<T> data, string fileName)
        {


            string fullpath = _path + "\\" + fileName;
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(fullpath, json);


        }

        public void SerData<T>(ObservableCollection<T> data, string fileName)
        {


            string fullpath = _path + "\\" + fileName;
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(fullpath, json);


        }

        public void SerData<T>(T data, string fileName)
        {

            string fullpath = _path + "\\" + fileName;
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(fullpath, json);


        }
        public List<T> DeserList<T>(string fileName)
        {
            string fullpath = _path + "\\" + fileName;
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); }

            if (!File.Exists(fullpath))
            {

                string jsonContent = "[]";
                File.WriteAllText(fullpath, jsonContent);
            }
            string json = File.ReadAllText(fullpath);
            List<T> data = JsonConvert.DeserializeObject<List<T>>(json);
            return data;
        }

        public T DeserData<T>(string fileName)
        {
            string fullpath = Path.Combine(_path, fileName);
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }

            if (!File.Exists(fullpath))
            {
                File.WriteAllText(fullpath, "{}");
            }

            string json = File.ReadAllText(fullpath);
            T data = JsonConvert.DeserializeObject<T>(json);
            return data;
        }

        public ObservableCollection<T> DeserObsCollection<T>(string fileName)
        {
            string fullpath = _path + "\\" + fileName;
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); }

            if (!File.Exists(fullpath))
            {

                string jsonContent = "[]";
                File.WriteAllText(fullpath, jsonContent);
            }
            string json = File.ReadAllText(fullpath);
            ObservableCollection<T> data = JsonConvert.DeserializeObject<ObservableCollection<T>>(json);
            return data;
        }


    }
}
