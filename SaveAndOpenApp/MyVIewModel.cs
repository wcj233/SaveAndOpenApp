using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SaveAndOpenApp
{
    public static class Serializer
    {
        public static string Serialize(object obj, DataContractJsonSerializerSettings settings = null)
        {
            if (obj == null)
            {
                throw new NullReferenceException();
            }

            settings = settings ?? new DataContractJsonSerializerSettings();
            DataContractJsonSerializer jsonizer = new DataContractJsonSerializer(obj.GetType(), settings);
            string jsonString = null;
            using (MemoryStream stream = new MemoryStream())
            {
                jsonizer.WriteObject(stream, obj);
                stream.Position = 0;
                StreamReader sr = new StreamReader(stream);
                jsonString = sr.ReadToEnd();
            }
            return jsonString;
        }

        public static T Deserialize<T>(string jsonString)
        {
            DataContractJsonSerializer jsonizer = new DataContractJsonSerializer(typeof(T));
            T obj;
            using (Stream stream = GenerateStreamFromString(jsonString))
            {
                obj = (T)jsonizer.ReadObject(stream);
            }
            return obj;
        }

        private static Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }

    public class MyVIewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string text { get; set; }
        private string text1 { get; set; }

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                this.OnPropertyChanged();
            }
        }

        public string Text1
        {
            get { return text1; }
            set
            {
                text1 = value;
                this.OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}
