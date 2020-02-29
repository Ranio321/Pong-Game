using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong_Game.Model
{
    class Ball: INotifyPropertyChanged
    {
        private int x;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if(x!=value)
                {
                    x = value;
                    NotifyPropertyChanged("X");
                }
            }
        }
        private int y;
        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                if (y != value)
                {
                    y = value;
                    NotifyPropertyChanged("Y");
                }
            }
        }
        private int size;
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                if (size != value)
                {
                    size = value;
                    NotifyPropertyChanged("Size");
                }
            }
        }







        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
