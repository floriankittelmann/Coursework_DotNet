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

        public Form1()
        {
            InitializeComponent();

            orb = new List<Orb>();

            Random rnd = new Random();
            int mMars = 5;
            Planet mars = new Planet("mars", rnd.Next(1, this.Width), rnd.Next(1, this.Height), 0, 0, mMars);
            orb.Add(mars);

            int mJupiter = 100;
            Planet jupiter = new Planet("jupiter", rnd.Next(1, this.Width), rnd.Next(1, this.Height), 0, 0, mJupiter);
            orb.Add(jupiter);

            int mMerkur = 4;
            Planet merkur = new Planet("jupiter", rnd.Next(1, this.Width), rnd.Next(1, this.Height), 0, 0, mMerkur);
            orb.Add(merkur);

            int mEnterprise = 1;
            Spaceship enterprise = new Spaceship("enterprise", rnd.Next(1, this.Width), rnd.Next(1, this.Height), 0, 0, mEnterprise);
            orb.Add(enterprise);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            foreach (Orb flyingObstacle in orb){
                flyingObstacle.Draw(g);
            }
        }
    }
}
