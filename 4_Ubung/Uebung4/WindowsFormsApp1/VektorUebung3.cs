using System;
using System.Security.Cryptography.X509Certificates;

namespace Galaxy
{
    public struct Vektor
    {   
        private double x;
        private double y;
        private double z;
        const double epsilon = 1E-10;
        
        public Vektor(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static explicit operator double (Vektor v1)
        {
            return Math.Sqrt(Math.Pow(v1.x, 2) + Math.Pow(v1.y, 2) + Math.Pow(v1.z, 2));
        }

        public static implicit operator Vektor(double a)
        {
            return new Vektor(a, 0, 0);
        }

        public static Vektor operator + (Vektor v1, Vektor v2)
        {
            return new Vektor(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vektor operator -(Vektor v1, Vektor v2)
        {
            return new Vektor(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vektor operator *(Vektor v1, Vektor v2)
        {
            double x = v1.y * v2.z - v1.z * v2.y;
            double y = v1.z*v2.x - v1.x*v2.z;
            double z = v1.x*v2.y - v1.y*v2.x;
            return new Vektor(x, y, z);
        }

        public static Vektor operator *(double a, Vektor v)
        {
            double x = v.x * a;
            double y = v.y * a;
            double z = v.z * a;
            return new Vektor(x, y, z);
        }

        public static Vektor operator *(Vektor v, double a)
        {
            return a * v;
        }

        public static Vektor operator /(Vektor v, double a)
        {
            double x = v.x / a;
            double y = v.y / a;
            double z = v.z / a;
            return new Vektor(x, y, z);
        }

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case (0):
                        return this.x;
                    case (1):
                        return this.y;
                    case (2):
                        return this.z;
                    default:
                        throw new Exception();
                }
            }
            set
            {
                switch (index)
                {
                    case (0):
                        this.x = value;
                        break;
                    case (1):
                        this.y = value;
                        break;
                    case (2):
                        this.z = value;
                        break;
                    default:
                        throw new Exception();
                }
            }
        }

        public static bool operator ==(Vektor v1, Vektor v2)
        {
            bool checkX = Math.Abs(v1.x - v2.x) < epsilon;
            bool checkY = Math.Abs(v1.y - v2.y) < epsilon;
            bool checkZ = Math.Abs(v1.z - v2.z) < epsilon;
            return (checkX && checkY && checkZ);
        }

        public static bool operator !=(Vektor v1, Vektor v2)
        {
            return !(v1 == v2);
        }

        public override bool Equals(object obj)
        {
            return (this == (Vektor)obj);
        }

        public static explicit operator String (Vektor v)
        {
            string a = "[ " + v.x + ", " + v.y + ", " + v.z + " ]";
            return a;
        }

    }
}
