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
    public partial class add_books : System.Web.UI.Page
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
        }


        protected void b1_Click(object sender, EventArgs e)
        {
            string book_image_name = Class1.GetRandomPassword(10) + ".jpg";
            string book_pdf = "";
            string book_video = "";


            string path1 = "";
            string path2 = "";
            string path3 = "";


            f1.SaveAs(Request.PhysicalApplicationPath + "/Librarian/books_images/"+ book_image_name.ToString());
            path1 = "books_images/"+ book_image_name.ToString();
            
            if (pdf_file.FileName.ToString() != "")
            {
                book_pdf = Class1.GetRandomPassword(10) + ".pdf";
                pdf_file.SaveAs(Request.PhysicalApplicationPath + "/Librarian/book_pdf/" + book_pdf.ToString());
                path2 = "book_pdf/" + book_pdf.ToString();
            }
            

            if (f3.FileName.ToString() != "")
            {
                book_video = Class1.GetRandomPassword(10) + ".mp4";
                f3.SaveAs(Request.PhysicalApplicationPath + "/Librarian/book_video/" + book_video.ToString());
                path3 = "book_video/" + book_video.ToString();
            }

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into books values('"+booktitle.Text+"','"+path1.ToString()+"','"+path2.ToString()+"','"+path3.ToString()+"','"+authorname.Text+"','"+isbn.Text+ "','"+qty.Text+"')";
            cmd.ExecuteNonQuery();

            msg.Style.Add("display", "block");
        }
    }
}