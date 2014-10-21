using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_GenRandomNumbers
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GenerateNumbers(object sender, EventArgs e)
        {
            var from = int.Parse(this.inpFrom.Value);
            var to = int.Parse(this.inpTo.Value);
            for (int i = from; i < to; i++)
            {
                this.result.InnerHtml += "<div>" + (i + 1) + "</div>";
            }
        }
    }
}