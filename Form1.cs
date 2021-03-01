using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public class BattleshipButton : System.Windows.Forms.Button
    {
        private int x,y;        
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public BattleshipButton(int x, int y, EventHandler eventHandler)
        {
            this.x = x;
            this.y = y;
            this.Click += eventHandler;
            this.Size = new System.Drawing.Size(50, 50);
            this.Location = new System.Drawing.Point(x*50, (y+1)*50);
            this.UseVisualStyleBackColor = true;            
            this.Name = string.Format("{0}x{1}",x,y);            
            this.TabIndex = 0;
            this.BackgroundImage = Properties.Resources.sea;
        }
    }
    public partial class Form1 : Form
    {        
        private Board board;
        Image empty, hit, miss, sunk;
        public Form1()//start game with default parameteres - 10x10 and three ships one 5-square and two 4-square
        {
            List<int> ships = new List<int> { 5, 4, 4 };
            setup_objects(10, ships);

        }
        public Form1(int size, List<int>ships)//start game with defined parameteres
        {
            setup_objects(size, ships);
        }
        private void setup_objects(int size, List<int>ships)
        {
            board = new Board(size, ships);
            miss = Properties.Resources.miss;
            hit = Properties.Resources.hit;
            sunk = Properties.Resources.sunk;
            InitializeComponent();
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    this.Controls.Add(new BattleshipButton(x, y, shoot_handler));
                }
            }
        }
        public void shoot_handler(object sender, EventArgs e)
        {
            BattleshipButton button = (BattleshipButton)sender;
            int result = board.shoot(button.getX(), button.getY());
            switch(result)
            {
                case -1:
                    ((Label)this.Controls.Find("top_banner",false)[0]).Text = "You already checked here. Are you sure?";
                    break;
                case 0:
                    button.BackgroundImage = miss;
                    ((Label)this.Controls.Find("top_banner", false)[0]).Text = "You missed!";
                    break;
                case 1:
                    button.BackgroundImage = hit;
                    ((Label)this.Controls.Find("top_banner", false)[0]).Text = "You hit a ship!";
                    break;
                case 2:
                    List<KeyValuePair<int,int>>sunk_ship = board.get_ship_from_field(button.getX(), button.getY());
                    ((Label)this.Controls.Find("top_banner", false)[0]).Text = "The ship sunk!";
                    foreach (KeyValuePair<int,int>square in sunk_ship)
                    {
                        ((BattleshipButton)this.Controls.Find(string.Format("{0}x{1}", square.Key, square.Value), false)[0]).BackgroundImage = sunk;
                    }
                    break;
                case 3:
                    sunk_ship = board.get_ship_from_field(button.getX(), button.getY());
                    ((Label)this.Controls.Find("top_banner", false)[0]).Text = "You won!";
                    ((Label)this.Controls.Find("top_banner", false)[0]).BackColor = Color.LightGreen;
                    foreach (KeyValuePair<int, int> square in sunk_ship)
                    {
                        ((BattleshipButton)this.Controls.Find(string.Format("{0}x{1}", square.Key, square.Value), false)[0]).BackgroundImage = sunk;
                    }
                    foreach (Control ctrl in this.Controls)
                    {
                        ctrl.Enabled = false;
                    }
                    break;
            }
            board.mark_as_checked(button.getX(), button.getY());
        }
    }
}
