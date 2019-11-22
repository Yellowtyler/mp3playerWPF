using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Windows;

namespace mp3player
{
   public class JsonFileService :IFileService
    {
 public List<string> Open(string path)
        {
           DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(string));
            List<string> p = new List<string>();
            if (!File.Exists(path))
            {
                File.Create("data.json");
                p.Add("sn");
                return p;
            }
            else if(new FileInfo("data.json").Length == 0)
            {
                p.Add("sn");
                return p;
            }
            else
            {
              
                    using (FileStream f = new FileStream(path, FileMode.OpenOrCreate))
                    {
                         
                                p = (List<string>)json.ReadObject(f);
                    }
              
             
            }
            return p;
        }
        public void Save(string path, List<string> songs)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(string));
            using (FileStream f = new FileStream(path, FileMode.Truncate))
            {
                json.WriteObject(f,songs);
            }
        }
    }
}
