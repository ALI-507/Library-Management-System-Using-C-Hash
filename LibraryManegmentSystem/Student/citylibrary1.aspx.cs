using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManegmentSystem.Student
{
    public partial class citylibrary1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void b1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Librarian/login.aspx");
        }

        protected void b2_Click(object sender, EventArgs e)
        {
            Response.Redirect("student_login.aspx");
        }
    }
}