using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mp3player
{
  public  interface IFileService
    {
        ObservableCollection<Song> Open(string path);
        void Save(string path, ObservableCollection<Song> songs);
    }
}
