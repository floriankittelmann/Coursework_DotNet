using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string url = "https://intra.zhaw.ch/personensuche/";
        public Form1()
        {
            InitializeComponent();
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(this.url);
        }

        private void webBrowser1_DocumentCompleted(Object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            bool alreadyLoaded = e.Url.ToString().StartsWith(this.url);
            if (alreadyLoaded) { 
                HtmlElement elem = getElementByClassName("form-control person-search-query", 0);
                elem.SetAttribute("value", textBox1.Text);
                HtmlElement e2 = getElementByClassName("btn btn-primary", 1);
                e2.InvokeMember("click");
            }
        }

        private HtmlElement getElementByClassName(string name, int hitToReturn)
        {
            int index = 0;
            HtmlElement returnElem = null;
            foreach (HtmlElement elem in webBrowser1.Document.All){
                if(elem.GetAttribute("className") == name){
                    if(index == hitToReturn) {
                        returnElem = elem;
                    } else {
                        index++;
                    }
                }
            }
            return returnElem;
        }




    }
}
