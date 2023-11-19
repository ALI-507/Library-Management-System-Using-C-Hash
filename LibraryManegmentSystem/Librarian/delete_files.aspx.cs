using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManegmentSystem.Librarian
{

    public partial class delete_files : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\projects\visualstudio project\LibraryManegmentSystem\LibraryManegmentSystem\App_Data\Lms.mdf"";Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            if (Session["Librarian"] == null)
            {
                Response.Redirect("login.aspx");
            }


            if (Request.QueryString["id"]!= null)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books set books_video='' where id='" + Request.QueryString["id"].ToString() +"'";
                cmd.ExecuteNonQuery();
            }
            else if (Request.QueryString["id1"]!= null) 
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books set books_pdf='' where id='" + Request.QueryString["id1"].ToString() + "'";
                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete books where id='" + Request.QueryString["id2"].ToString() + "'";
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("display_books.aspx");
            
        }
    }
}