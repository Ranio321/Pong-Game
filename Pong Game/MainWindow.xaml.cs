
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
using System.Timers;
using Pong_Game.VM;
using Pong_Game.Model;
using System.Windows.Threading;
using Pong_Game.View;
namespace Pong_Game
{
 
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private DispatcherTimer Balltimer;
       
        Components components;
     // private Options options= new Options();

        public MainWindow()
        {
            InitializeComponent();
           
            components = new Components();

            RightPad.DataContext = components.RightPad;
            LeftPad.DataContext = components.LeftPad;
            Ball.DataContext = components.Ball;
            RightPointer.DataContext = components.Points;
            LeftPointer.DataContext = components.Points;

            components.keys.Add("Up", false);
            components.keys.Add("Down", false);
            components.keys.Add("W", false);
            components.keys.Add("S", false);

            InitializeTimers();
          
            options.BallColor.SelectionChanged += comboBox_SelectionChanged;

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
 
        }

        private void InitializeTimers()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Event;


            Balltimer = new DispatcherTimer();
            Balltimer.Interval = TimeSpan.FromMilliseconds(1);
            Balltimer.Tick += BallMovement;
        }

        private void StartGame()
        {
    
            timer.Start();
            Balltimer.Start();
          PressSpace.Visibility = Visibility.Hidden;
 
        }

        private void StopGame()
        {
            timer.Stop();
            Balltimer.Stop();
            PressSpace.Visibility = Visibility.Visible;
        }


        void Event(object sender, EventArgs e)
        {
            
            components.MoveRightPad();
            components.MoveLeftPad();
        }

        void BallMovement(object sender, EventArgs e)

        {
            components.MoveBall();

        }


        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {

                case Key.Up:
                   components.keys["Up"] = true;
                    
                    break;

                case Key.Down:
                    components.keys["Down"] = true;
                    break;

                case Key.W:
                    components.keys["W"] = true;
                    break;

                case Key.S:
                    components.keys["S"] = true;
                    break;

                case Key.Space:

                    if (!timer.IsEnabled)
                    {
                        StartGame();
                    }
                    else
                    {
                        StopGame();
                    }
                    break;
            }
 

        }


        private void Window_KeyUp(object sender, KeyEventArgs e)
        {

            components.keys["Up"] = false;
            components.keys["Down"] = false;
            components.keys["W"] = false;
            components.keys["S"] = false;

        }

        private void Options_Click(object sender, RoutedEventArgs e)
        {
          // options.Show();
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            StopGame();
            components.RestartGame();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //options.Close();
            
        }
    }
}
