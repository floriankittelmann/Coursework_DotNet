using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ClassLibrary1.Properties;

namespace ClassLibrary1
{
    public class BMIControl
    {

        private double BmiValue;

        public BMIControl(double height, double weight)
        {
            this.BmiValue = weight / (height * height);
        }

        public double getBmiValue(){
            return this.BmiValue;
        }

        public Bitmap getBmiPicture()
        {
            Bitmap bitmap = null;
            if(this.BmiValue < 18){
                bitmap = (Bitmap)Resources.ResourceManager.GetObject("bmi18");
            } else if(this.BmiValue < 20){
                bitmap = (Bitmap)Resources.ResourceManager.GetObject("bmi20");
            } else if(this.BmiValue < 25){
                bitmap = (Bitmap)Resources.ResourceManager.GetObject("bmi25");
            } else if(this.BmiValue < 30){
                bitmap = (Bitmap)Resources.ResourceManager.GetObject("bmi30");
            } else {
                bitmap = (Bitmap)Resources.ResourceManager.GetObject("bmi40");
            }
            return bitmap;
        }
    }


}
