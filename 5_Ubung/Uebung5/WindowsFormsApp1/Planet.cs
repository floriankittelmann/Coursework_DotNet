using p5;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy
{
    
    class Planet: Orb
    {
        public Planet(string name, double x, double y, double vx, double vy, double m) : base(name, x, y, vx, vy, m) 
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(bitmap, (float)Pos[0], (float)Pos[1], bitmap.Width / 2, bitmap.Height / 2);
        }

    }
}
