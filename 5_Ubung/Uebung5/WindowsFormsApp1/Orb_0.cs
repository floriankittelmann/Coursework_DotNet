using System;
using System.Collections.Generic;
using System.Drawing;
using Galaxy;
using WindowsFormsApp1.Properties;
using WindowsFormsApp1;

namespace p5
{
    delegate void CollisionHandler(int posList);
    public sealed class Collidable : Attribute 
    {
        public bool collidable = true;
    };

    abstract class Orb {
        const double G = 30; //6.673e-11

        protected Bitmap bitmap;
        protected Vektor posNew, pos;
        protected Vektor v0;
        protected string name;
        protected double masse;
        public event CollisionHandler collision;
        protected int explosionCounter;

        public int ExplosionCounter
        {
            get { return explosionCounter; }
            set { explosionCounter = value; }
        }

        public Vektor Pos
        {
            get { return pos; }
        }

        public Vektor Velocity {
            get { return v0; }
        }

        public double Mass
        {
            get { return masse; }
            set { masse = value; }
        }
        public abstract void Draw(Graphics g);

        public void Move()
        {
            pos = posNew;
        }

        public Orb(string name, double x, double y, double vx, double vy, double m)
        {
            bitmap = (Bitmap)Resources.ResourceManager.GetObject(name);
            bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
            pos = new Vektor(x, y, 0);
            v0 = new Vektor(vx, vy, 0);
            masse = m;
            this.name = name;
            explosionCounter = 0;
        }

        public virtual void CalcPosNew(IList<Orb> space, Form1 form)
        {
            Vektor a = new Vektor();
            foreach (Orb spaceObject in space)
            {
                if (spaceObject != this) {
                    Vektor radiusVektor = spaceObject.Pos - this.Pos;
                    double radius = (double)radiusVektor;
                    double aAbs = G * (spaceObject.Mass * this.Mass) / (Math.Pow(radius, 2) * this.Mass);
                    a += aAbs * radiusVektor / radius;
                    if(radius < 15.0)
                    {
                        this.collision = new CollisionHandler(form.SubscriberCollision);
                        this.collision(space.IndexOf(spaceObject));
                    }
                }
            }
            double t = 3;
            posNew = pos + v0 * t + (t * t) * a;
            v0 = v0 + t * a;
        }

        public override string ToString()
        {
            return name;
        }

    }
}
