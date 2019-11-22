using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace mp3player
{
   public class DialogService:IDialogService
    {
        public string FilePath{
            get; set;}
        public bool OpenFileDialog()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "mp3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
          
            if(openFile.ShowDialog()==true)
            {
                FilePath = openFile.FileName;
                return true;
            }
            return false;
        }
        public void ShowMessage(string Message)
        {
            MessageBox.Show(Message);
        }
        public bool SaveFileDialog()
        {
            return true;
        }
    }
}
