using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong_Game.Model
{
    class PlayerPoints: INotifyPropertyChanged
    {
        private int rightplayer;

        public int RightPlayer
        {
            get
            {
                return rightplayer;
            }
            set
            {
                rightplayer = value;
                NotifyPropertyChanged("RightPlayer");
            }
        }


        private int leftplayer;

        public int LeftPlayer
        {
            get
            {
                return leftplayer;
            }
            set
            {
                leftplayer = value;
                NotifyPropertyChanged("LeftPlayer");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
