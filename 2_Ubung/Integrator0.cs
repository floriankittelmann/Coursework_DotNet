using System;

namespace Integrator
{
    class MainClass
    {
        const int STEPS = 100;
        const double EPS = 1E-10;

        public static void Main(string[] args)
        {
            Console.WriteLine("Linear:" + Integrator.Integrate(x => x, 0, 10, STEPS));
            Console.WriteLine("Square:" + Integrator.Integrate(x => x * x, 0, 10, STEPS));
            Console.WriteLine("Square:" + Integrator.Integrate(x => x * x, 0, 10, EPS));
            Console.ReadLine();
        }
    }

    public class Integrator
    {
        public static double Integrate(Func<double, double> f, double start, double end, int step)
        {

            double totalArea = 0.0d;
            double stepSize = (end - start) / step;
            double xStartValue = 0.0d + (stepSize / 2);
            double xPlusEins = start;

            for (int i = 0; i < step; i++)
            {   
                xStartValue = xPlusEins;
                xPlusEins = xStartValue + stepSize;
                totalArea += stepSize / 2.0 * (f(xStartValue) + f(xPlusEins));
            }

            return Math.Round(totalArea, 10);
        }


        public static double Integrate(Func<double, double> f, double start, double end, double eps)
        {     
            double xPlusEins = start;
            double areaLast = 0.0d;
            double totalArea = 0.0d;

            while(end > xPlusEins)
            {
                double xStartValue = xPlusEins;
                int startSteps = 100;

                double stepSize = (end - start) / startSteps;
                xPlusEins = xStartValue + stepSize;
                double areaNew = stepSize / 2.0 * (f(xStartValue) + f(xPlusEins));
                
                while (Math.Abs(areaLast - areaNew) > eps)
                {
                    startSteps = startSteps * 5;

                    stepSize = (end - start) / startSteps;
                    xPlusEins = xStartValue + stepSize;
                    areaNew = stepSize / 2.0 * (f(xStartValue) + f(xPlusEins));
                }

                totalArea += areaNew;
                areaLast = areaNew;
            }

            return totalArea;
        }

    }
}