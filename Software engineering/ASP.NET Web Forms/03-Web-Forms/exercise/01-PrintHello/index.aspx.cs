using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_PrintHello
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bShowMsg_OnClick(object sender, EventArgs e)
        {
            var name = this.tbEnterName.Text;
            this.lMsg.Text = "Hello " + name;
        }
    }
}