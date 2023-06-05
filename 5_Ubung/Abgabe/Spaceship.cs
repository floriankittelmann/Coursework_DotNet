using System.Drawing;
using System.Media;
using System.Drawing;
using System.Windows.Forms;
using p5;
using WindowsFormsApp1.Properties;
using System.Diagnostics;
using WindowsFormsApp1;
using System;

namespace Galaxy
{
    [Collidable]
    class Spaceship : Orb
    {
        public Spaceship(string name, double x, double y, double vx, double vy, double m) : base(name, x, y, vx, vy, m)
        {
        }

        private bool currentlyAnimatingExplosion = false;
        public override void Draw(Graphics g)
        {
            if (masse == 0) {
                if(explosionCounter == 0) { 
                    System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
                    SoundPlayer sp = new SoundPlayer(global::WindowsFormsApp1.Properties.Resources.explosion);
                    sp.Play();
                }
            } else
            {
                g.DrawImage(bitmap, (float)Pos[0], (float)Pos[1], bitmap.Width / 2, bitmap.Height / 2);
            }

        }
    }

    
}
