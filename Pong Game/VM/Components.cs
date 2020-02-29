using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pong_Game.Model;

namespace Pong_Game.VM
{
    class Components: INotifyPropertyChanged
    {
        public Ball Ball = new Ball() { X = 395,Y=190,Size=10 };
        public Pad LeftPad = new Pad() { Y = 150 };
        public Pad RightPad = new Pad() { Y = 150 };
        public PlayerPoints Points = new PlayerPoints() { LeftPlayer=0,RightPlayer=0};


        public IDictionary<string, bool> keys = new Dictionary<string, bool>();

        private string DirectionX = "Right";
        private string DirectionY = "Down";



        public void MoveRightPad()
        {
            if (keys["Up"] && RightPad.Y>0)
            {
                RightPad.Y -= 3;
            }
            if (keys["Down"] && RightPad.Y<300)
            {
                RightPad.Y += 3;
            }
        }


        public void MoveLeftPad()
        {
            if (keys["W"] && LeftPad.Y > 0)
            {
                LeftPad.Y -= 3;
            }
            if (keys["S"] && LeftPad.Y < 300)
            {
                LeftPad.Y += 3;
            }
        }
        int Random = Methods.RandomNumbers.Random();

        public void MoveBall()
        {


            if (Ball.X <= 0)
            {
                DirectionX = "Left";
                Random = Methods.RandomNumbers.Random();
                if (Ball.Y < LeftPad.Y || Ball.Y > LeftPad.Y + 100)
                {
                    Points.RightPlayer += 1;
                    RestartBall();
                }


            }
            if (Ball.X >= 795)
            {
                DirectionX = "Right";
                Random = Methods.RandomNumbers.Random();
                if (Ball.Y < RightPad.Y || Ball.Y > RightPad.Y + 100)
                {
                    Points.LeftPlayer += 1;
                    RestartBall();
                }
            }
            if (DirectionX == "Left") Ball.X += 3;
            if (DirectionX == "Right") Ball.X -= 3;
            if (Ball.Y <= 0) DirectionY = "Down";
            if (Ball.Y >= 390) DirectionY = "Up";
            if (DirectionY == "Down") Ball.Y += Random;
            if (DirectionY == "Up") Ball.Y -= Random;
        }


        private void RestartBall()
        {
            Ball.X = 395;
            Ball.Y = 190;
        }


        public void RestartGame()
        {
            Points.LeftPlayer = 0;
            Points.RightPlayer = 0;
            RestartBall();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}

