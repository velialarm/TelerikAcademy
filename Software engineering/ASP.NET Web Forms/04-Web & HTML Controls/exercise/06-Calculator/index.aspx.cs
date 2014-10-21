using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _06_Calculator
{
    public partial class index : Page
    {

        private List<int> numbers;
        //private List<Operator> operators; 

        protected void Page_Load(object sender, EventArgs e)
        {
           // numbers = new List<int>();
        }

        protected void ClickBtn(object sender, EventArgs e)
        {
            var test = (HtmlButton)sender; 
            var text = test.InnerHtml;
            if (this.result.Value.Equals("0"))
            {
                this.result.Value = "";
            }
            this.result.Value += text;

            try
            {
                var number = int.Parse(text);
                numbers.Add(number);
            }
            catch (Exception)
            {
                //TODO
            }
        }
    }
}