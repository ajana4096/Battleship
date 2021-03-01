using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Board
    {       
        private List<Ship> ships;
        int ships_count;
        private short[,] square_states;//logical states of squares: -1 - already checked by the opponent, 0 - empty, greater then 0 - occupied by a ship with id one less than the state 
        public Board(int size, List<int> ships)//create ship of given size and number of ships
        {
            square_states = new short[size, size];
            this.ships = new List<Ship>(ships.Count);
            this.ships_count = ships.Count;
            Random rm = new Random((int)DateTime.Now.Ticks);            
            //the code doesn't detect that more ships cannot be placed since it's beyond scope of the question 
            //and number of ships flexibility is added only because I consider it good practice
            for(int i=0;i<ships.Count;i++)
            {
                bool correct_position = false;
                this.ships.Add(new Ship(ships[i]));
                int direction,x,y;
                do
                {
                    direction = rm.Next(0, 2); //choose if ship is placed horizontally(0) or vertically(y)
                    correct_position = true;
                    //check if the position is free
                    if (direction == 1)///horizontal
                    {
                        //choose the position of the top left square of the new ship
                        x = rm.Next(0, size-ships[i]);
                        y = rm.Next(0, size);

                        for (int k = x; k < x + ships[i]; k++)
                        {
                            if (square_states[k, y] != 0)
                            {
                                correct_position = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        //choose the position of the top left square of the new ship
                        x = rm.Next(0, size);
                        y = rm.Next(0, size-ships[i]);

                        for (int k = y; k < y + ships[i]; k++)
                        {
                            if (square_states[x, k] != 0)
                            {
                                correct_position = false;
                                break;
                            }
                        }
                    }
                }
                while (!correct_position);//repest until you find correct position
                //save the ships position
                if (direction == 1)
                {
                    for (int k = x; k < x + ships[i]; k++)
                    {
                        square_states[k, y] = (short)(i + 1);
                        this.ships[i].add_square(k, y);
                    }
                }
                else
                {
                    for (int k = y; k < y + ships[i]; k++)
                    {
                        square_states[x, k] = (short)(i + 1);
                        this.ships[i].add_square(x,k);
                    }
                }
            }
        }
        //execute player's move and return result
        public int shoot(int x, int y)
        {
            int result = square_states[x, y];
            if(square_states[x,y]>0)//check if a ship was hit
            {
                result = 1;                
                if(this.ships[square_states[x, y]-1].shoot())//check if the ship was sunk
                {
                    ships_count--;
                    result++;                    
                    if(ships_count==0)//check if there are ships remaining
                    {                        
                        result++;
                    }
                }
            }            
            return result;
        }
        public void mark_as_checked(int x, int y)
        {
            square_states[x, y] = -1;
        }
        //returns all squares of a ship that occupies a given square
        public List<KeyValuePair<int,int>>get_ship_from_field(int x, int y)
        {
            return this.ships[square_states[x, y] - 1].get_squares();
        }
    }
}
