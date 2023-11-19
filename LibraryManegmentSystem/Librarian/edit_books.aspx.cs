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
    public partial class edit_books : System.Web.UI.Page

    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Lms.mdf;Integrated Security=True");
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

            id = Convert.ToInt32(Request.QueryString["id"].ToString());

            if (IsPostBack) return;

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from books where id=" + id + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            //for editing books details it should show the previous added details in each block to be edited
            foreach (DataRow dr in dt.Rows)
            {
                booktitle.Text = dr["books_title"].ToString();
                booksimage.Text = dr["books_image"].ToString();
                bookspdf.Text = dr["books_pdf"].ToString();
                booksvideo.Text = dr["books_video"].ToString();
                authorname.Text = dr["books_author_name"].ToString();
                isbn.Text = dr["books_isbn"].ToString();
                qty.Text = dr["books_qty"].ToString();

            }
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            string book_image_name = "";
            string book_pdf = "";
            string book_video = "";


            string path1 = "";
            string path2 = "";
            string path3 = "";

            if (f1.FileName.ToString() != "")
            {
                book_image_name = Class1.GetRandomPassword(10) + ".jpg";
                f1.SaveAs(Request.PhysicalApplicationPath + "/Librarian/books_images/" + book_image_name.ToString());
                path1 = "books_images/" + book_image_name.ToString();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books set books_title='" + booktitle.Text + "',books_image='" + path1.ToString() + "',books_author_name='" + authorname.Text + "',books_isbn='" + isbn.Text + "',books_qty='" + qty.Text + "' where id=" + id + " ";
                cmd.ExecuteNonQuery();
            }

            if (pdf_file.FileName.ToString() != "")
            {
                book_pdf = Class1.GetRandomPassword(10) + ".pdf";
                pdf_file.SaveAs(Request.PhysicalApplicationPath + "/Librarian/book_pdf/" + book_pdf.ToString());
                path2 = "book_pdf/" + book_pdf.ToString();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books set books_title='" + booktitle.Text + "',books_pdf='" + path2.ToString() + "',books_author_name='" + authorname.Text + "',books_isbn='" + isbn.Text + "',books_qty='" + qty.Text + "' where id=" + id + " ";
                cmd.ExecuteNonQuery();
            }


            if (f3.FileName.ToString() != "")
            {
                book_video = Class1.GetRandomPassword(10) + ".mp4";
                f3.SaveAs(Request.PhysicalApplicationPath + "/Librarian/book_video/" + book_video.ToString());
                path3 = "book_video/" + book_video.ToString();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books set books_title='" + booktitle.Text + "',books_video='" + path3.ToString() + "',books_author_name='" + authorname.Text + "',books_isbn='" + isbn.Text + "',books_qty='" + qty.Text + "' where id=" + id + " ";
                cmd.ExecuteNonQuery();
            }
            if (f1.FileName.ToString() == "" && pdf_file.FileName.ToString() == "" && f3.FileName.ToString() == "")
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books set books_title='" + booktitle.Text + "',books_author_name='" + authorname.Text + "',books_isbn='" + isbn.Text + "',books_qty='" + qty.Text + "' where id=" + id + " ";
                cmd.ExecuteNonQuery();
            }


            Response.Redirect("display_books.aspx");
        }
    }
}