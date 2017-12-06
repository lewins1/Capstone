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
        int _time;
        int _ypose = 6;
        int _xpose = 6;
        enum EnumController
        {
            W,
            A,
            S,
            D
        }
        List<EnumController> controller = new List<EnumController>(5);

        Button[,] buttons = new Button[11,11];

        public Form1()
        {
            
            InitializeComponent();

            InitTimer();

            InitGrid();

            foreach (Button button in buttons)
            {
                button.Text = "■";

            }

        }

        private void InitTimer()
        {
            Timer timer = new Timer
            {
                Interval = (1000)
            };
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }
        private void InitGrid ()
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
        }

        private void Timer_Tick(object o, EventArgs e)
        {
            Pose();
            
            Points();

            foreach (Button button in buttons)
            {
                button.Text = "";

            }
        }
        private void Pose()
        {
            //switch (controller[0])
            //{
            //    case EnumController.W:
            //    default:
            //        break;
            //}
            //foreach (var item in collection)
            //{

            //}
        }
        public void Points()
        {
            _time = _time + 1;
            button122.Text = _time.ToString();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                button123.Text = "W";
                controller.Add(EnumController.W);
            }
            else if (e.KeyCode == Keys.A)
            {
                button123.Text = "A";
                controller.Add(EnumController.A);
            }
            else if (e.KeyCode == Keys.S)
            {
                button123.Text = "S";
                controller.Add(EnumController.S);
            }
            else if (e.KeyCode == Keys.D)
            {
                button123.Text = "D";
                controller.Add(EnumController.D);
            }
        }
    }
}
