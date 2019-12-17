using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Windows;
using System.Collections.ObjectModel;

namespace mp3player
{
   public class JsonFileService :IFileService
    {
 public ObservableCollection<Song> Open(string path)
        {
           DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(ObservableCollection<Song>));
            ObservableCollection<Song> p = new ObservableCollection<Song>();
            if (!File.Exists(path))
            {
                File.Create("data.json");
                p.Add(new Song() { NameS="Gaston - Hekla", PathS= "Hekla.mp3" });
                return p;
            }
            else if(new FileInfo("data.json").Length == 0)
            {
                p.Add(new Song() { NameS = "Gaston - Hekla", PathS = "Hekla.mp3" });
                return p;
            }
            else
            {
              
                    using (FileStream f = new FileStream(path, FileMode.OpenOrCreate))
                    {
                         
                                p = (ObservableCollection<Song>)json.ReadObject(f);
                    }
              
             
            }
            return p;
        }
        public void Save(string path, ObservableCollection<Song> songs)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(ObservableCollection<Song>));
            using (FileStream f = new FileStream(path, FileMode.Truncate))
            {
                json.WriteObject(f,songs);
            }
        }
    }
}
