using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mp3player
{
  public  interface IFileService
    {
        List<string> Open(string path);
        void Save(string path, List<string> songs);
    }
}
