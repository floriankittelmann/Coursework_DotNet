using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;
using Galaxy;
using p5;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {   
        private List<Orb> orb;
        private Graphics g;
        public Form1()
        {
            InitializeComponent();

            orb = new List<Orb>();

            orb.Add(new Spaceship("enterprise", 600, 230, 3, 0, 1));
            orb.Add(new Planet("jupiter", 600, 400, -0.099, 0, 100));
            orb.Add(new Planet("mars", 300, 400, 0, 1.5, 4));
            orb.Add(new Planet("merkur", 200, 200, 0, -1.5, 4));
            

            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            g = e.Graphics;
            foreach (Orb flyingObstacle in orb)
            {
                flyingObstacle.Draw(g);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   
            if(this.orb.Count != 0 && this.g != null) { 
                foreach(Orb orbInSpace in orb)
                {
                    orbInSpace.CalcPosNew(this.orb);
                }

                foreach (Orb orbInSpace in orb)
                {
                    orbInSpace.Move();
                }
                Refresh();
            }
        }
    }
}
