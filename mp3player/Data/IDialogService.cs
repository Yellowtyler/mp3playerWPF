using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mp3player
{
  public  interface IDialogService
    {
        void ShowMessage(string message);
        string FilePath
        {
            get;
            set;
        }
        bool OpenFileDialog();
        bool SaveFileDialog();
    }
}
