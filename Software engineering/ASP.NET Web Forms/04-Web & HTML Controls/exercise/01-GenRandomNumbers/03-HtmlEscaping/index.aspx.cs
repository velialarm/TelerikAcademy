using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03_HtmlEscaping
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnClickOne(object sender, EventArgs e)
        {
            var text = this.tbValue.Text;
            this.lEscText.Text = text;
            this.tbEscText.Text = text;
        }
    }
}