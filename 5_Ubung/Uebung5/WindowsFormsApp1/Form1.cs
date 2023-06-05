using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Galaxy;
using p5;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {   
        private List<Orb> orb;
        private Graphics g;
        private List<Orb> collided;
        private bool currentlyAnimatingExplosion = false;
        private Bitmap explosionGif;
        public Form1()
        {
            InitializeComponent();

            orb = new List<Orb>();
            collided = new List<Orb>();

            orb.Add(new Spaceship("enterprise", 600, 230, 3, 0, 1));
            orb.Add(new Planet("jupiter", 600, 400, -0.099, 0, 100));
            orb.Add(new Planet("mars", 300, 400, 0, 1.5, 4));
            orb.Add(new Planet("merkur", 200, 200, 0, -1.5, 4));
            

            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

            explosionGif = (Bitmap)Resources.ResourceManager.GetObject("explosion4");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            g = e.Graphics;
            foreach (Orb flyingObstacle in orb)
            {
                flyingObstacle.Draw(g);
            }

            List<Orb> coliddedTemp = new List<Orb>(this.collided);
            foreach (Orb flyingObstacle in coliddedTemp)
            {   
                if(flyingObstacle.ExplosionCounter < 20) { 
                    flyingObstacle.Draw(g);

                    if (!currentlyAnimatingExplosion)
                    {
                        this.AnimateExplosion();
                        currentlyAnimatingExplosion = true;
                    }
                    ImageAnimator.UpdateFrames();
                    float x = (float)flyingObstacle.Pos[0];
                    float y = (float)flyingObstacle.Pos[1];
                    e.Graphics.DrawImage(this.explosionGif, x, y, explosionGif.Width / 2, explosionGif.Height / 2);
                    
                    flyingObstacle.ExplosionCounter++;
                } else
                {
                    int posToDelete = coliddedTemp.IndexOf(flyingObstacle);
                    collided.RemoveAt(posToDelete);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   
            if(this.orb.Count != 0 && this.g != null) {
                List<Orb> orbTemp = new List<Orb>(this.orb);
                foreach(Orb orbInSpace in orbTemp)
                {
                    orbInSpace.CalcPosNew(orbTemp, this);
                }

                foreach (Orb orbInSpace in orb)
                {
                    orbInSpace.Move();
                }
                Refresh();
            }
        }

        public void SubscriberCollision(int posList)
        {   
            Orb orbobject = orb[posList];
            Type t = orbobject.GetType();
            object[] atts = t.GetCustomAttributes(typeof(Collidable), true);
            if(atts != null && atts.Length != 0) {
                Collidable attribute = (Collidable)atts[0];
                if (attribute.collidable) {
                    orbobject.Mass = 0;
                    collided.Add(orbobject);
                    orb.RemoveAt(posList);
                }
            }
        }

        public void AnimateExplosion()
        {
            if (!currentlyAnimatingExplosion)
            {
                //Begin the animation only once.
                ImageAnimator.Animate(explosionGif, new EventHandler(this.OnFrameChanged));
                currentlyAnimatingExplosion = true;
            }
        }

        private void OnFrameChanged(object o, EventArgs e)
        {
            //Force a call to the Paint event handler.
            this.Invalidate();
        }

    }
}
