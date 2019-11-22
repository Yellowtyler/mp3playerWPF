using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace mp3player
{
    [DataContract]
    public class Song : INotifyPropertyChanged
    {
        string nameS;
        string pathS;
        [DataMember]
      public string NameS
        {
            get
            {
                return nameS;
            }
            set
            {
                nameS = value;
                OnPropertyChanged("NameS");
            }
        }
        [DataMember]
        public string PathS
        {
            get
            {
                return pathS;
            }
            set
            {
               pathS = value;
                OnPropertyChanged("PathS");
            }
        }
        public  static ObservableCollection<Song> GetSongs(List<string> s)
        {
          
            ObservableCollection<Song> songs = new ObservableCollection<Song>();
           songs.Add(new Song { NameS = "S" , PathS= "Hekla.mp3" });
          /*  foreach (string str in s)
            {
              songs.Add(new Song() { Paths = str });
            }*/
            return songs;
        }
        void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
