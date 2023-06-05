using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebApplication1
{
    public partial class BmiPicture : System.Web.UI.UserControl
    {
        public void SetBitmapPicture(Bitmap value)
        {
            ImageConverter converter = new ImageConverter();
            byte[] bytes = (byte[])converter.ConvertTo(value, typeof(byte[]));
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            Image1.ImageUrl = "data:image/png;base64," + base64String;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}