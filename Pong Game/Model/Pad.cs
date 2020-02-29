using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong_Game.Model
{
    class Pad: INotifyPropertyChanged
    {

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

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
