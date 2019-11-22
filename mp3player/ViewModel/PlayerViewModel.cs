using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;

namespace mp3player
{
   public class PlayerViewModel : INotifyPropertyChanged
    {
     
        MediaPlayer mp;
        IDialogService dialog;
        IFileService file;
        public MediaPlayer Mp
        {
            get
            {
                return mp;
            }
            set
            {
                mp = value;
                OnPropertyChanged("Mp");
            }
        }

      ObservableCollection<Song> songs;
        public ObservableCollection<Song> Songs
        {
            set
            {
                songs = value;
                OnPropertyChanged("Songs");
            
            }
            get
            {
                return songs;
            }
        }

       Song selecteds;
        public Song Selecteds
        {
            set
            {
                selecteds = value;
                OnPropertyChanged("Selecteds");
            }
            get
            {
                return selecteds;
            }
        }

        bool isplaying;
        public bool Isplaying
        {
            get
            {
                return isplaying;
            }
            set
            {
                isplaying = value;
                OnPropertyChanged("Isplaying");
            }
        }

        double slidervalue;
     public   double SliderValue
        {
            get
            {
                return slidervalue;
            }
            set
            {
                slidervalue = value;
                OnPropertyChanged("SliderValue");
            }
        }

       Duration mpmax;
        public Duration Mpmax
        {
            get
            {
                return mpmax;
            }
            set
            {
               mpmax = Mp.NaturalDuration;
                OnPropertyChanged("Mpmax");
            }
        }
        Uri mpsource;
        public Uri Mpsource
        {

            get
            {
                return mpsource;
            }
            set
            {
                mpsource = Mp.Source;
                OnPropertyChanged("Mpsource");
            }
        }
        public ICommand back
        {
            get;
            set;
        }
        public ICommand further
        {
            get;
            set;
        }
        public ICommand shuffle
        {
            get;
            set;
        }
        public ICommand open
        {
            get;
            set;
        }
        public ICommand play
        {
            get;
            set;
        }
        public ICommand pause
        {
            get;
            set;
        }
        public ICommand sliderchange
        {
            get;
            set;
        }
        void Open(object o)
        {
            try
            {
                if(dialog.OpenFileDialog()==true)
                {
                    Songs.Add(new Song() { PathS = dialog.FilePath});
                }
            }
            catch(Exception ex)
            {
                dialog.ShowMessage(ex.Message);
            }

        }
        int flag = 0;
        object temp=null;
        void Play(object o)
        {
           
            if ((o != null&&(flag==0))||( o != temp && (flag == 2 || flag == 1)))
            {
                Song s = o as Song;
                Mp.Open(new Uri(s.PathS, UriKind.RelativeOrAbsolute));
                Mp.Play();
               
                Isplaying = true;
                flag = 1;
             
              Mp.MediaOpened += new EventHandler(mediaOpened);
            }
          
            else if (o==null&&flag==0)
            {
                Mp.Open(new Uri(Songs[0].PathS, UriKind.RelativeOrAbsolute));
                Mp.Play();
                Mp.MediaOpened += new EventHandler(mediaOpened);
                flag =1;
              
            }
            else if (flag == 1)
            {
                Mp.Pause();
                flag = 2;
            }
            else if(flag==2)
            {
                Mp.Play();
                flag = 1;
            }
          temp = o;
        }

        private void slider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (TotalTime.TotalSeconds > 0)
            {
                Mp.Position = TimeSpan.FromSeconds(SliderValue * TotalTime.TotalSeconds);
            }
        }

        private TimeSpan TotalTime;
        private DispatcherTimer timerMusicTime;
        
        void mediaOpened(object sender, EventArgs e)
        {
            TotalTime = new TimeSpan();
            TotalTime = Mp.NaturalDuration.TimeSpan;

            // Create a timer that will update the counters and the time slider
            timerMusicTime = new DispatcherTimer();
            timerMusicTime.Interval = TimeSpan.FromSeconds(1);
            timerMusicTime.Tick += new EventHandler(timer_Tick);
            timerMusicTime.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (Mp.NaturalDuration.TimeSpan.TotalSeconds > 0)
            {
                if (TotalTime.TotalSeconds > 0)
                {
                    // Updating time slider
                    SliderValue = Mp.Position.TotalSeconds /
                                       TotalTime.TotalSeconds;
                }
            }
        }
        public PlayerViewModel(IDialogService dialog, IFileService file)
        {
            
            Songs = new ObservableCollection<Song>();
            this.dialog = dialog;
            this.file = file;
            var s = this.file.Open("data.json");
            Songs = Song.GetSongs(s);
            Mp = new MediaPlayer();
            // Songs.Clear();

            play = new DelegateCommand(Play);
           open = new DelegateCommand(Open);       
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
