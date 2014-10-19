using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _04_StudentWebForm
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO
        }

        protected void UniChange(object sender, EventArgs e)
        {
            //TODO
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            HtmlGenericControl mainContainer = new HtmlGenericControl("div");

            HtmlGenericControl heading = new HtmlGenericControl("h3");
            heading.InnerText = "Student's data";

            HtmlGenericControl firstName = new HtmlGenericControl("p");
            firstName.InnerText = "First Name: " + this.tbFirstName.Text;

            HtmlGenericControl lastName = new HtmlGenericControl("p");
            lastName.InnerText = "Last Name: " + this.tbLastName.Text;

            HtmlGenericControl facultyNumber = new HtmlGenericControl("p");
            facultyNumber.InnerText = "Faculty Number: " + this.tbFacultyNumber.Text;

            HtmlGenericControl university = new HtmlGenericControl("p");
            university.InnerText = "University: " + this.ddListUniversities.SelectedValue;

            HtmlGenericControl coursesText = new HtmlGenericControl("span");
            coursesText.InnerText = "Selected Courses: ";

            HtmlGenericControl coursesList = new HtmlGenericControl("ol");

            var coursesNumber = this.CkeckBoxListCourses.Items.Count;
            for (int i = 0; i < coursesNumber; i++)
            {
                if (CkeckBoxListCourses.Items[i].Selected)
                {
                    HtmlGenericControl courseListItem = new HtmlGenericControl("li");
                    courseListItem.InnerText = this.CkeckBoxListCourses.Items[i].Text;
                    coursesList.Controls.Add(courseListItem);
                }
            }

            mainContainer.Controls.Add(heading);
            mainContainer.Controls.Add(firstName);
            mainContainer.Controls.Add(lastName);
            mainContainer.Controls.Add(facultyNumber);
            mainContainer.Controls.Add(university);
            mainContainer.Controls.Add(coursesText);
            mainContainer.Controls.Add(coursesList);

            Controls.Add(mainContainer);
        }
    }
}