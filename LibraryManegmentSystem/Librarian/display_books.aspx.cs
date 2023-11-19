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
    public partial class display_books : System.Web.UI.Page
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

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from books";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            r1.DataSource = dt;
            r1.DataBind();
            
        }
        // to delete videos files from the dispaly books page
        public string checkvideo(object myvalue,object id)
        {
            if(myvalue == "")
            {
                return myvalue.ToString();
            }
            else
            {
                return "<a href='delete_files.aspx?id="+id+"' class='btn btn-danger'>Delete</a>";
            }
        }

        // to delete pdf files from the dispaly books page
        public string checkpdf(object myvalue1, object id1)
        {
            if (myvalue1 == "")
            {
                return myvalue1.ToString();
            }
            else
            {
                return "<a href='delete_files.aspx?id1=" + id1 + "' class='btn btn-danger'>Delete</a>";
            }
        }


    }
}