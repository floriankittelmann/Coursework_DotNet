using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                /*//double weight = Convert.ToDouble(Weight.Text);
                double height = Convert.ToDouble(Height.Text);

                double bmi = weight / (height * height);
                BmiResult.Text = bmi.ToString();*/
            }
        }

        protected void ResetClick(object sender, EventArgs e)
        {
            /*this.RequiredFieldValidator1.Enabled = false;
            this.RangeValidator1.Enabled = false;*/
            this.RequiredFieldValidator2.Enabled = false;
            this.RangeValidator2.Enabled = false;

           // this.Weight.Text = "";
            this.Height.Text = "";
            this.BmiResult.Text = "";

            /*this.RequiredFieldValidator1.Enabled = true;
            this.RangeValidator1.Enabled = true;*/
            this.RequiredFieldValidator2.Enabled = true;
            this.RangeValidator2.Enabled = true;
        }

    }
}