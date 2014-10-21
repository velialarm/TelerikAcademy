namespace _02_GenNumServerCrl
{
    using System;
    using System.Web.UI;

    public partial class index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GenerateNumbers(object sender, EventArgs e)
        {
            var from = int.Parse(this.tbFrom.Text);
            var to = int.Parse(this.tbTo.Text);
            for (int i = from; i < to; i++)
            {
                this.result.Text += "<div>" + (i + 1) + "</div>";
            }
        }
    }
}