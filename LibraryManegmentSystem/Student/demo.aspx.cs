using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManegmentSystem.Student
{
    public partial class demo : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Lms.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();



            if (Session["student"] == null)
            {
                Response.Redirect("student_login.aspx");
            }
            else
            {
                string loggedInUsername = Session["student"].ToString();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Student_registration WHERE username = @Username";
                cmd.CommandText = "SELECT student_img FROM Student_registration WHERE username = @Username";
                cmd.Parameters.AddWithValue("@Username", loggedInUsername);

                string imagePath = cmd.ExecuteScalar()?.ToString();
                if (!string.IsNullOrEmpty(imagePath))
                {
                    // Update the path to the location of the user's uploaded images
                    imgUser.ImageUrl = ResolveUrl("~/student_img" + imagePath);
                }
                else
                {
                    // Provide a default image path if no image is available
                    imgUser.ImageUrl = ResolveUrl("~/images/admin.jpg");

                }

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                r2.DataSource = dt;
                r2.DataBind();
            }
                
        }

        protected string GetLoggedInUsername()
        {
            if (Session["student"] != null)
            {
                return Session["student"].ToString(); // Assuming the session variable stores the username
            }
            else
            {
                return string.Empty; // Return an empty string if the session variable is not set
            }

        }
        



    }
}