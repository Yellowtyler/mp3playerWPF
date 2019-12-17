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
     
       
        IDialogService dialog;
        IFileService file;
        MediaPlayer mp;
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

     
       TimeSpan totalTime;
        public TimeSpan TotalTime
        {

            get
            {
                return totalTime;
            }
            set
            {
                totalTime = value;
                OnPropertyChanged("TotalTime");
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
      public ICommand repeat
        {
            get;
            set;
        }
       public ICommand remove
        {
            get;
            set;
        }



        string Getname(string path)
        {
            string[] words = path.Split('\\');
            string[] name = words[words.Length-1].Split('.');

            return name[0];

        }
        void Open(object o)
        {
            try
            {
                if(dialog.OpenFileDialog()==true)
                {
                  
                    Songs.Add(new Song() { PathS = dialog.FilePath , NameS = Getname(dialog.FilePath) });
                }
            }
            catch(Exception ex)
            {
                dialog.ShowMessage(ex.Message);
            }

        }



        void Remove(object o)
        {
            if(o!=null)
            {
             
                Songs.Remove(o as Song);
            }

            else
            {
                var res = MessageBox.Show("Choose songs for removing", "Error!", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }


        Song CurrentSong;
        int flag = 0;
        object temp=null;
        void Play(object o)
        {
           Random rand = new Random();
            if (IsShuffled == true&& o == null && flag == 0)
            {
            
               
                int n = rand.Next(0, Songs.Count);
                int temprand = n;
                if(CurrentSong == Songs[n])
                {
                    while(temprand==n)
                    {
                         n = rand.Next(0, Songs.Count);
                    }
                }
                CurrentSong = Songs[n];
                
                Mp.Open(new Uri(Songs[n].PathS, UriKind.RelativeOrAbsolute));
                Mp.Play();
                Mp.MediaOpened += new EventHandler(mediaOpened);
              
                flag = 1;
            }
            else if((o != null && (flag == 0)) || (o != temp && (flag == 2 || flag == 1))&&IsShuffled==true)
            {
         

                int n = rand.Next(0, Songs.Count);
                int temprand = n;
                if (CurrentSong == Songs[n])
                {
                    while (temprand == n)
                    {
                        n = rand.Next(0, Songs.Count);
                    }
                }
                CurrentSong = Songs[n];

                Mp.Open(new Uri(Songs[n].PathS, UriKind.RelativeOrAbsolute));
                Mp.Play();
                Mp.MediaOpened += new EventHandler(mediaOpened);
                 Isplaying = true;
                flag = 1;

            }
          
              else  if ((o != null && (flag == 0)) || (o != temp && (flag == 2 || flag == 1))&& IsShuffled == false)
                {
                    Song s = o as Song;
                    CurrentSong = s;
                    Mp.Open(new Uri(s.PathS, UriKind.RelativeOrAbsolute));
                    Mp.Play();
                    Mp.MediaOpened += new EventHandler(mediaOpened);
                    Isplaying = true;
                    flag = 1;
                }

                else if (o == null && flag == 0&&IsShuffled==false)
                {
                    Mp.Open(new Uri(Songs[0].PathS, UriKind.RelativeOrAbsolute));
                    CurrentSong = Songs[0];
                    Mp.Play();
                    Mp.MediaOpened += new EventHandler(mediaOpened);
                    flag = 1;

                }
                else if (flag == 1)
                {
                    Mp.Pause();
                    flag = 2;
                }
                else if (flag == 2)
                {
                    Mp.Play();
                    flag = 1;
                }
                
            
            Selecteds = CurrentSong;
            temp = Selecteds;
        }

        private void slider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (TotalTime.TotalSeconds > 0)
            {
                Mp.Position = TimeSpan.FromSeconds(SliderValue * TotalTime.TotalSeconds);
            }
        }

       
        private DispatcherTimer timerMusicTime;
   
        void mediaOpened(object sender, EventArgs e)
        {
        
            TotalTime = new TimeSpan();
            TotalTime = Mp.NaturalDuration.TimeSpan;

          
            timerMusicTime = new DispatcherTimer();
            timerMusicTime.Interval = TimeSpan.FromSeconds(1);
            timerMusicTime.Tick += new EventHandler(timer_Tick);
            timerMusicTime.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (Mp.NaturalDuration.HasTimeSpan)
            {
                if (Mp.NaturalDuration.TimeSpan.TotalSeconds > 0)
                {
                    if (TotalTime.TotalSeconds > 0)
                    {
                      
                        SliderValue = Mp.Position.TotalSeconds /
                                           TotalTime.TotalSeconds;
                    }
                    if(SliderValue==1)
                    {
                        object o = new object();
                        if (IsRepeated == false)
                            Further(o);
                        else
                            Repeat(o);
                    }
                }
            }
        }

       bool IsRepeated = false;
        void Repeat(object o)
        {
            if(IsRepeated==false)
            {

                IsRepeated =true;

            }
       else if (IsRepeated ==true && SliderValue != 1)
            {
                IsRepeated = false;
         
            }

        else if(IsRepeated == true && SliderValue == 1)
            {
                Mp.Open(new Uri(CurrentSong.PathS, UriKind.RelativeOrAbsolute));
                   Mp.Play();
                  Mp.MediaOpened += new EventHandler(mediaOpened);
            }

        }
        bool IsFurthered = false;
        void Further(object o)
        {
            for (int i = 0; i < Songs.Count; i++)
            {
                if (CurrentSong == Songs[i])
                {
                    if (i != Songs.Count - 1 && Songs.Count!=1)
                    { Play(Songs[i + 1]); }
                    else if(Songs.Count==1 || i == Songs.Count - 1)
                    {
                        Play(Songs[0]);
                    }
                    break;

                }


            }

           IsFurthered = true;
        }

        void Back(object o)
        {

            for (int i = 0; i < Songs.Count; i++)
            {
                if (CurrentSong == Songs[i])
                {
                    if (i != 0 && Songs.Count != 1)
                    { Play(Songs[i -1]); }
                    else if (Songs.Count == 1 || i == 0)
                    {
                        Play(Songs[Songs.Count-1]);
                    }
                    break;

                }


            }
        }

        bool IsShuffled = false;
        void Shuffle(object o)
        {
            if (IsShuffled == false)
                IsShuffled = true;

            else IsShuffled = false;


        }

        public PlayerViewModel(IDialogService dialog, IFileService file)
        {
            
            Songs = new ObservableCollection<Song>();
            this.dialog = dialog;
            this.file = file;
            Songs = Song.GetSongs();
            Mp = new MediaPlayer();
            play = new DelegateCommand(Play);
            open = new DelegateCommand(Open);
            remove = new DelegateCommand(Remove);
            repeat = new DelegateCommand(Repeat);
            further = new DelegateCommand(Further);
            back = new DelegateCommand(Back);
            shuffle = new DelegateCommand(Shuffle);
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
