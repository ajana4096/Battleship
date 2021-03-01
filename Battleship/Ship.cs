using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Ship
    {
        private List<KeyValuePair<int, int>> squares;
        private int size;
        public Ship(int size)
        {
            this.size = size;
            squares = new List<KeyValuePair<int, int>>(size);
        }
        public List<KeyValuePair<int,int>>get_squares()
        {
            return squares;
        }
        public void add_square(int x, int y)
        {
            squares.Add(new KeyValuePair<int, int>(x, y));
        }
        public bool shoot()//reduce number of unfound fields of the sip by one and return true if the ship has been sunk
        {
            size--;
            if (size == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
