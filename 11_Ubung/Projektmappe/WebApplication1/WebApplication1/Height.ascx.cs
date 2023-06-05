using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        public double AmountValue
        {
            get { return Convert.ToDouble(Height2.Text) / Convert.ToDouble(HeightUnit.SelectedValue); }
            set { Height2.Text = Convert.ToString(value); }
        }

        private double oldExchangeValue
        {
            get { return ViewState["HeightOldExchange"] == null ? 1 : (double)ViewState["HeightOldExchange"]; }
            set { ViewState["HeightOldExchange"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void HeightUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double currentAmount = Convert.ToDouble(Height2.Text);
                double newExchangeValue = Convert.ToDouble(HeightUnit.SelectedValue);
                double newAmount = currentAmount / oldExchangeValue * newExchangeValue;
                oldExchangeValue = newExchangeValue;
                Height2.Text = newAmount.ToString("f2");
            }
            catch (Exception)
            {
                Height2.Text = "0";
            }
        }
    }
}