using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //************************************
        //Title: Snake
        //Application Type: WinForms
        //Description: Recreate the retro game snake in a winforms app
        //Author: Shawn Lewin
        //Date Created: 12/2/17
        //Last Modified: 12/10/17
        //************************************
        //
        //Declaring Variables 
        //
        Button[,] buttons = new Button[11, 11];

        int timerSpeed = 1000;
        int time = 1;
        int points = -2;

        char controller;

        int[] coords = new int[2] { 5, 5 };

        Timer snakeTimer = new Timer
        {
            Interval = 1000
        };

        List<int> tailPose = new List<int>(5) { 55, 55, 55, 55 };
        int tailLength = 1;
        int tailPoseY;
        int tailPoseX;

        Random randBait = new Random();
        int randomY;
        int randomX;

        bool gameOver = false;

        /// <summary>
        /// Setup for the form
        /// </summary>
        public Form1()
        {
            //
            //Automated Setup
            //
            InitializeComponent();

            //
            //Tells the timer what to do every tick, and to start timing
            //

            
            snakeTimer.Tick += new EventHandler(Timer_Tick);
            

            
            InitGrid();

            Bait();
            while ((controller.ToString().Length == 0))
            {

            }
            snakeTimer.Start();
        }

        /// <summary>
        /// Pushes all buttons into 2 dimentional array
        /// </summary>
        private void InitGrid()
        {

            buttons[0, 0] = button121;
            buttons[0, 1] = button1;
            buttons[0, 2] = button2;
            buttons[0, 3] = button3;
            buttons[0, 4] = button4;
            buttons[0, 5] = button5;
            buttons[0, 6] = button6;
            buttons[0, 7] = button7;
            buttons[0, 8] = button8;
            buttons[0, 9] = button9;
            buttons[0, 10] = button10;

            buttons[1, 0] = button120;
            buttons[1, 1] = button20;
            buttons[1, 2] = button19;
            buttons[1, 3] = button18;
            buttons[1, 4] = button17;
            buttons[1, 5] = button16;
            buttons[1, 6] = button15;
            buttons[1, 7] = button14;
            buttons[1, 8] = button13;
            buttons[1, 9] = button12;
            buttons[1, 10] = button11;

            buttons[2, 0] = button119;
            buttons[2, 1] = button30;
            buttons[2, 2] = button29;
            buttons[2, 3] = button28;
            buttons[2, 4] = button27;
            buttons[2, 5] = button26;
            buttons[2, 6] = button25;
            buttons[2, 7] = button24;
            buttons[2, 8] = button23;
            buttons[2, 9] = button22;
            buttons[2, 10] = button21;

            buttons[3, 0] = button118;
            buttons[3, 1] = button40;
            buttons[3, 2] = button39;
            buttons[3, 3] = button38;
            buttons[3, 4] = button37;
            buttons[3, 5] = button36;
            buttons[3, 6] = button35;
            buttons[3, 7] = button34;
            buttons[3, 8] = button33;
            buttons[3, 9] = button32;
            buttons[3, 10] = button31;

            buttons[4, 0] = button117;
            buttons[4, 1] = button50;
            buttons[4, 2] = button49;
            buttons[4, 3] = button48;
            buttons[4, 4] = button47;
            buttons[4, 5] = button46;
            buttons[4, 6] = button45;
            buttons[4, 7] = button44;
            buttons[4, 8] = button43;
            buttons[4, 9] = button42;
            buttons[4, 10] = button41;

            buttons[5, 0] = button116;
            buttons[5, 1] = button60;
            buttons[5, 2] = button59;
            buttons[5, 3] = button58;
            buttons[5, 4] = button57;
            buttons[5, 5] = button56;
            buttons[5, 6] = button55;
            buttons[5, 7] = button54;
            buttons[5, 8] = button53;
            buttons[5, 9] = button52;
            buttons[5, 10] = button51;

            buttons[6, 0] = button115;
            buttons[6, 1] = button70;
            buttons[6, 2] = button69;
            buttons[6, 3] = button68;
            buttons[6, 4] = button67;
            buttons[6, 5] = button66;
            buttons[6, 6] = button65;
            buttons[6, 7] = button64;
            buttons[6, 8] = button63;
            buttons[6, 9] = button62;
            buttons[6, 10] = button61;

            buttons[7, 0] = button114;
            buttons[7, 1] = button80;
            buttons[7, 2] = button79;
            buttons[7, 3] = button78;
            buttons[7, 4] = button77;
            buttons[7, 5] = button76;
            buttons[7, 6] = button75;
            buttons[7, 7] = button74;
            buttons[7, 8] = button73;
            buttons[7, 9] = button72;
            buttons[7, 10] = button71;

            buttons[8, 0] = button113;
            buttons[8, 1] = button90;
            buttons[8, 2] = button89;
            buttons[8, 3] = button88;
            buttons[8, 4] = button87;
            buttons[8, 5] = button86;
            buttons[8, 6] = button85;
            buttons[8, 7] = button84;
            buttons[8, 8] = button83;
            buttons[8, 9] = button82;
            buttons[8, 10] = button81;

            buttons[9, 0] = button112;
            buttons[9, 1] = button100;
            buttons[9, 2] = button99;
            buttons[9, 3] = button98;
            buttons[9, 4] = button97;
            buttons[9, 5] = button96;
            buttons[9, 6] = button95;
            buttons[9, 7] = button94;
            buttons[9, 8] = button93;
            buttons[9, 9] = button92;
            buttons[9, 10] = button91;

            buttons[10, 0] = button111;
            buttons[10, 1] = button110;
            buttons[10, 2] = button109;
            buttons[10, 3] = button108;
            buttons[10, 4] = button107;
            buttons[10, 5] = button106;
            buttons[10, 6] = button105;
            buttons[10, 7] = button104;
            buttons[10, 8] = button103;
            buttons[10, 9] = button102;
            buttons[10, 10] = button101;

            foreach (Button button in buttons)
            {
                button.BackColor = Color.White;
            }

            for (int i = 0; i < 11; i++)
            {
                buttons[0, i].BackColor = Color.Black;
                buttons[i, 10].BackColor = Color.Black;
                buttons[10, i].BackColor = Color.Black;
                buttons[i, 0].BackColor = Color.Black;
            }

        }

        /// <summary>
        /// For each tick of the timer, executes code block
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object o, EventArgs e)
        {
            Pose();

            Collison();

            if (!gameOver)
            {
                Points();

                Tail();
            }

            //
            //Dev mode
            //
            //    button123.Visible = true;


        }

        /// <summary>
        /// Uses input from form's keyboard input to decide which way the snake is moving
        /// </summary>
        private void Pose()
        {

            switch (controller)
            {
                case 'W':

                    //
                    //Sends Previous coords to list, for later tail use
                    //
                    //1=x 0=y
                    tailPose.Insert(0, coords[1] * 10 + coords[0]);

                    //
                    //Shows current coords
                    //
                    button123.Text = tailPose[0].ToString();

                    //
                    //Rewrites new coords to where the user requested to move to
                    //
                    coords[1] = coords[1] + 1;
                    break;

                case 'A':
                    tailPose.Insert(0, coords[1] * 10 + coords[0]);
                    button123.Text = tailPose[0].ToString();
                    coords[0] = coords[0] - 1;
                    break;
                case 'S':
                    tailPose.Insert(0, coords[1] * 10 + coords[0]);
                    button123.Text = tailPose[0].ToString();
                    coords[1] = coords[1] - 1;
                    break;
                case 'D':
                    tailPose.Insert(0, coords[1] * 10 + coords[0]);
                    button123.Text = tailPose[0].ToString();
                    coords[0] = coords[0] + 1;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Increases the Points, and tests for if the snake is on the bait
        /// </summary>
        private void Points()
        {
            if (time == 8)
            {
                button122.Text = time.ToString();
            }
            //
            //Adds 1 to time every tick to make a usuable value
            //
            time = time + 1;



            if (coords[0] == randomY && coords[1] == randomX)
            {
                tailLength++;
                points = points + 100;
                Bait();
                if (timerSpeed > 200)
                {
                    timerSpeed = timerSpeed - 50;
                }
                snakeTimer.Interval = timerSpeed;
            }
        }

        /// <summary>
        /// Places new bait
        /// </summary>
        private void Bait()
        {
            randomY = randBait.Next(1, 9);
            randomX = randBait.Next(1, 9);
            
            if (buttons[randomY, randomX].BackColor == Color.DarkGreen || buttons[randomY, randomX].BackColor == Color.LawnGreen || buttons[randomY, randomX].BackColor == Color.PaleGreen || randomY == coords[0] && randomX == coords[1])
            {
                Bait();
            }
            buttons[randomY, randomX].BackColor = Color.Blue;
        }

        /// <summary>
        /// Desides where Tail is and isnt through coords input during Pose()
        /// </summary>
        private void Tail()
        {
            for (int i = 0; i < tailPose.Count; i++)
            {
                //
                //When the coords in the list are below the tailLength max, writes a body block
                //
                if (i < tailLength)
                {
                    if (tailPose[i] > 10 && tailPose[i] < 20)
                    {
                        tailPoseY = 1;
                        tailPoseX = tailPose[i] - 10;
                    }
                    else if (tailPose[i] > 20 && tailPose[i] < 30)
                    {
                        tailPoseY = 2;
                        tailPoseX = tailPose[i] - 20;
                    }
                    else if (tailPose[i] > 30 && tailPose[i] < 40)
                    {
                        tailPoseY = 3;
                        tailPoseX = tailPose[i] - 30;
                    }
                    else if (tailPose[i] > 40 && tailPose[i] < 50)
                    {
                        tailPoseY = 4;
                        tailPoseX = tailPose[i] - 40;
                    }
                    else if (tailPose[i] > 50 && tailPose[i] < 60)
                    {
                        tailPoseY = 5;
                        tailPoseX = tailPose[i] - 50;
                    }
                    else if (tailPose[i] > 60 && tailPose[i] < 70)
                    {
                        tailPoseY = 6;
                        tailPoseX = tailPose[i] - 60;
                    }
                    else if (tailPose[i] > 70 && tailPose[i] < 80)
                    {
                        tailPoseY = 7;
                        tailPoseX = tailPose[i] - 70;
                    }
                    else if (tailPose[i] > 80 && tailPose[i] < 90)
                    {
                        tailPoseY = 8;
                        tailPoseX = tailPose[i] - 80;
                    }
                    else if (tailPose[i] > 90 && tailPose[i] < 100)
                    {
                        tailPoseY = 9;
                        tailPoseX = tailPose[i] - 90;
                    }
                    
                    buttons[tailPoseX, tailPoseY].BackColor = Color.LawnGreen;
                }
                //
                //When the coords in the list are above the tailLength max, writes a blank block
                //
                else if (i > tailLength)
                {
                    if (tailPose[i] > 10 && tailPose[i] < 20)
                    {
                        tailPoseY = 1;
                        tailPoseX = tailPose[i] - 10;
                    }
                    else if (tailPose[i] > 20 && tailPose[i] < 30)
                    {
                        tailPoseY = 2;
                        tailPoseX = tailPose[i] - 20;
                    }
                    else if (tailPose[i] > 30 && tailPose[i] < 40)
                    {
                        tailPoseY = 3;
                        tailPoseX = tailPose[i] - 30;
                    }
                    else if (tailPose[i] > 40 && tailPose[i] < 50)
                    {
                        tailPoseY = 4;
                        tailPoseX = tailPose[i] - 40;
                    }
                    else if (tailPose[i] > 50 && tailPose[i] < 60)
                    {
                        tailPoseY = 5;
                        tailPoseX = tailPose[i] - 50;
                    }
                    else if (tailPose[i] > 60 && tailPose[i] < 70)
                    {
                        tailPoseY = 6;
                        tailPoseX = tailPose[i] - 60;
                    }
                    else if (tailPose[i] > 70 && tailPose[i] < 80)
                    {
                        tailPoseY = 7;
                        tailPoseX = tailPose[i] - 70;
                    }
                    else if (tailPose[i] > 80 && tailPose[i] < 90)
                    {
                        tailPoseY = 8;
                        tailPoseX = tailPose[i] - 80;
                    }
                    else if (tailPose[i] > 90 && tailPose[i] < 100)
                    {
                        tailPoseY = 9;
                        tailPoseX = tailPose[i] - 90;
                    }
                
                
                    if (tailPose.Count > tailLength)
                    {
                        tailPose.RemoveAt(tailLength + 1);
                        points++;
                    }
                
                    buttons[tailPoseX, tailPoseY].BackColor = Color.White;
                }
                if (i == tailLength)
                {
                    if (tailPose[i] > 10 && tailPose[i] < 20)
                    {
                        tailPoseY = 1;
                        tailPoseX = tailPose[i] - 10;
                    }
                    else if (tailPose[i] > 20 && tailPose[i] < 30)
                    {
                        tailPoseY = 2;
                        tailPoseX = tailPose[i] - 20;
                    }
                    else if (tailPose[i] > 30 && tailPose[i] < 40)
                    {
                        tailPoseY = 3;
                        tailPoseX = tailPose[i] - 30;
                    }
                    else if (tailPose[i] > 40 && tailPose[i] < 50)
                    {
                        tailPoseY = 4;
                        tailPoseX = tailPose[i] - 40;
                    }
                    else if (tailPose[i] > 50 && tailPose[i] < 60)
                    {
                        tailPoseY = 5;
                        tailPoseX = tailPose[i] - 50;
                    }
                    else if (tailPose[i] > 60 && tailPose[i] < 70)
                    {
                        tailPoseY = 6;
                        tailPoseX = tailPose[i] - 60;
                    }
                    else if (tailPose[i] > 70 && tailPose[i] < 80)
                    {
                        tailPoseY = 7;
                        tailPoseX = tailPose[i] - 70;
                    }
                    else if (tailPose[i] > 80 && tailPose[i] < 90)
                    {
                        tailPoseY = 8;
                        tailPoseX = tailPose[i] - 80;
                    }
                    else if (tailPose[i] > 90 && tailPose[i] < 100)
                    {
                        tailPoseY = 9;
                        tailPoseX = tailPose[i] - 90;
                    }

                    buttons[tailPoseX, tailPoseY].BackColor = Color.PaleGreen;
                }
                button122.Text = points.ToString();

                //
                //Sets the current head to a body block
                //
                
                buttons[coords[0], coords[1]].BackColor = Color.DarkGreen;
                
            }
        }

        /// <summary>
        /// Tests if the snake is colliding with itself or the wall
        /// </summary>
        private void Collison()
        {
            if (buttons[coords[0], coords[1]].BackColor == Color.Black)
            {
                GameOver();
            }
            else if (buttons[coords[0], coords[1]].BackColor == Color.LawnGreen)
            {
                GameOver();
            }
        }
        
        /// <summary>
        /// Stops the timer, makes the restart button visable, paints grid red.
        /// </summary>
        private void GameOver()
        {
            snakeTimer.Stop();
            foreach (Button button in buttons)
            {
                button.BackColor = Color.Red;
            }
            gameOver = true;
            button124.Visible = true;
        }
        
        /// <summary>
        /// Form automated keyboard inputs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W && controller != 'S')
            {

                controller = 'W';
            }
            else if (e.KeyCode == Keys.A && controller != 'D')
            {

                controller = 'A';
            }
            else if (e.KeyCode == Keys.S && controller != 'W')
            {

                controller = 'S';
            }
            else if (e.KeyCode == Keys.D && controller != 'A')
            {

                controller = 'D';
            }
        }

        /// <summary>
        /// When restart button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button124_Click(object sender, EventArgs e)
        {
            //
            //reseting variables
            //
            tailPose.RemoveRange(0, tailPose.Count);
            for (int i = 0; i < 5; i++)
            {
                tailPose.Insert(0, 55);
            }
            controller = 't';
            timerSpeed = 1000;
            time = 1;
            points = -3;
            coords[0] = 5;
            coords[1] = 5;
            snakeTimer.Interval = 1000;
            tailLength = 1;
            gameOver = false;

            button124.Visible = false;

            //
            //rerunning setup
            //
            snakeTimer.Start();

            InitGrid();

            Bait();
        }
    }
}