using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ClassLibrary1;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/scripts/jquery-1.7.2.min.js",
                DebugPath = "~/scripts/jquery-1.7.2.min.js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.js"
            });
        }
        protected void CalculateClick(object sender, EventArgs e)
        {
            if (IsValid)
            {
                BMIControl bmiControl = new BMIControl(Height.AmountValue, Weight.AmountValue);
                BmiService bmiCalc = new BmiService();
                this.BmiResult.Text = Convert.ToString(bmiCalc.bmi(Height.AmountValue, Weight.AmountValue));
                BmiPicture.SetBitmapPicture(bmiControl.getBmiPicture());
            }
        }

        protected void ResetClick(object sender, EventArgs e)
        {
            /*this.RequiredFieldValidator1.Enabled = false;
            this.RangeValidator1.Enabled = false;
            this.RequiredFieldValidator2.Enabled = false;
            this.RangeValidator2.Enabled = false;*/

            Weight.AmountValue = 0;
            Height.AmountValue = 0;
            this.BmiResult.Text = "0";

            /*this.RequiredFieldValidator1.Enabled = true;
            this.RangeValidator1.Enabled = true;
            this.RequiredFieldValidator2.Enabled = true;
            this.RangeValidator2.Enabled = true;*/
        }

    }
}