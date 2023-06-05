using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Weight : System.Web.UI.UserControl
    {
        public double AmountValue
        {
            get { return Convert.ToDouble(Weight2.Text) / Convert.ToDouble(WeightUnit.SelectedValue); }
            set { Weight2.Text = Convert.ToString(value); }
        }

        private double oldExchangeValue
        {
            get { return ViewState["WeightOldExchange"] == null ? 1 : (double)ViewState["WeightOldExchange"]; }
            set { ViewState["WeightOldExchange"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void Select (object sender, EventArgs arg)
        {
            
        }

        protected void WeightUnit_SelectedIndexChanged(object sender, EventArgs e)
        {   
            try
            {
                double currentAmount = Convert.ToDouble(Weight2.Text);
                double newExchangeValue = Convert.ToDouble(WeightUnit.SelectedValue);
                double newAmount = currentAmount / oldExchangeValue * newExchangeValue;
                oldExchangeValue = newExchangeValue;
                Weight2.Text = newAmount.ToString("f2");
            } catch (Exception)
            {
                Weight2.Text = "0";
            }
        }
    }
}