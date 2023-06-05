using System;

namespace Integrator {
  class MainClass {
    const int STEPS = 100;
    const double EPS = 1E-10;
    
    public static void Main(string[] args) {
      Console.WriteLine("Linear:" +Integrator.Integrate(x => x,0,10,STEPS));
      Console.WriteLine("Square:"+Integrator.Integrate(x=>x*x,0,10,STEPS));
      Console.WriteLine("Square:"+Integrator.Integrate(x => x * x, 0,10,EPS));
      Console.ReadLine();
    }
  }
  
  public class Integrator {

      public static double Integrate(Func<double, double> f, double start, double end, int step) {
		// TODO
      }
 
  
      public static double Integrate(Func<double, double> f, double start, double end, double eps) {
		// TODO
      }

}