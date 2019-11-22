using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace mp3player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          var s= new PlayerViewModel(new DialogService(), new JsonFileService());
            this.DataContext = s;
            mediaElement.DataContext = s.Mp;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var context = DataContext as PlayerViewModel;

            if (context == null)
                return;

            context.Isplaying = !context.Isplaying;
        }
        private TimeSpan TotalTime;
        private DispatcherTimer timerMusicTime;

        private void mediaElement_MediaOpened_1(object sender, RoutedEventArgs e)
        {
            TotalTime = mediaElement.NaturalDuration.TimeSpan;

            // Create a timer that will update the counters and the time slider
            timerMusicTime = new DispatcherTimer();
            timerMusicTime.Interval = TimeSpan.FromSeconds(1);
            timerMusicTime.Tick += new EventHandler(timer_Tick);
            timerMusicTime.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (mediaElement.NaturalDuration.TimeSpan.TotalSeconds > 0)
            {
                if (TotalTime.TotalSeconds > 0)
                {
                    // Updating time slider
                    slider.Value = mediaElement.Position.TotalSeconds /
                                       TotalTime.TotalSeconds;
                }
            }
        }
    }
}
