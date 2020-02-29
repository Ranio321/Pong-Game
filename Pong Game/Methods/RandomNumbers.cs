using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong_Game.Methods
{
   public static class RandomNumbers
    {

        public static int Random()
        {
            int Randoms;
            Random r = new Random();
              Randoms= r.Next(1,4);
              


            return Randoms;
        }

    }
}
