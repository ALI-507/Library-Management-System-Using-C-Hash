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
    public partial class returnbook : System.Web.UI.Page
    {
  
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Lms.mdf;Integrated Security=True");
        string books_isbn = "";
        int id;
        
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

            id = Convert.ToInt32(Request.QueryString["id"]);

            //After returning book set book returned to yes
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Issue_Books set is_book_returned='Yes', book_returned_date='"+DateTime.Now.ToString("yyyy/MM/dd")+"' where id='"+id+"'";
            cmd.ExecuteNonQuery();

            //to load book_isbn from issue_books Table
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from Issue_books where id='"+id+"'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                books_isbn = dr1["books_isbn"].ToString();
            }


          

            //update books table after book is returned add to quantity +1
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "update books set books_qty = books_qty+1 where books_isbn='"+books_isbn.ToString()+"'";
            cmd2.ExecuteNonQuery();
            Response.Write("<script>alert('Book Returned Succcessfully!'); window.location.href=window.location.href</script>");


            Response.Redirect("return_books.aspx");
        }
    }
}