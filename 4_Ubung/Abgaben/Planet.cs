using p5;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Properties;

namespace Galaxy
{
    class Planet: Orb
    {
        public Planet(string name, double x, double y, double vx, double vy, double m) : base(name, x, y, vx, vy, m) 
        {
        }

        public override void Draw(Graphics g)
        {
            Image image = (Bitmap)Resources.ResourceManager.GetObject(name);
            g.DrawImage(image, (float)Pos[0], (float)Pos[1], image.Width / 2, image.Height / 2);
        }

    }
}
