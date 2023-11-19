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
    public partial class issue_books : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Lms.mdf;Integrated Security=True");
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


            if (IsPostBack) return;

            //to display the enrollment no in dropdown menu
            enrno.Items.Clear();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select enrollment_no from student_registration";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                enrno.Items.Add(dr["enrollment_no"].ToString());
            }

            //to display the book isbn no in dropdown menu
            isbn.Items.Clear();
            isbn.Items.Add("Select");
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select books_isbn from books";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                isbn.Items.Add(dr1["books_isbn"].ToString());
            }
        }

        //Issue books button
        protected void b1_Click(object sender, EventArgs e)
        {
            //if the user hasnt selected book isbn and pressed issue books will show this alert message 
            if (isbn.SelectedItem.ToString() == "Select")
            {
                Response.Write("<script>alert('Please select  book ISBN First');window.location.href=window.location.href</script>");

            }
            else
            {

                //if the book is alraedy been borrowed by one user once cant borrow two books
                int found = 0;
                SqlCommand cmd0 = con.CreateCommand();
                cmd0.CommandType = CommandType.Text;
                cmd0.CommandText = "select * from Issue_Books where student_enrollment_no='" + enrno.SelectedItem.ToString() + "' and books_isbn='" + isbn.SelectedItem.ToString() + "' and is_book_returned='No'";
                cmd0.ExecuteNonQuery();
                DataTable dt0 = new DataTable();
                SqlDataAdapter da0 = new SqlDataAdapter(cmd0);
                da0.Fill(dt0);
                found = Convert.ToInt32(dt0.Rows.Count.ToString());
                if (found > 0)
                {
                    Response.Write("<script>alert('You have Already been issued this Book once.')</script>");

                }
                else
                {

                    //if the book is out of stock it shoukd display the message
                    if (instock.Text == "0")
                    {
                        Response.Write("<script>alert('Sorry! The Book is out of Stock')</script>");

                    }
                    else
                    {

                        string book_issue_date = DateTime.Now.ToString("yyyy/MM/dd");
                        string book_apprx_return_date = DateTime.Now.AddDays(10).ToString("yyyy/MM/dd");
                        string username = "";

                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from student_registration where enrollment_no='" + enrno.SelectedItem.ToString() + "'";
                        cmd.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        foreach (DataRow dr in dt.Rows)
                        {
                            username = dr["username"].ToString();
                        }

                        //To insert data into the issue_book table 
                        SqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "insert into Issue_Books values('" + enrno.SelectedItem.ToString() + "','" + username.ToString() + "','" + isbn.SelectedItem.ToString() + "','" + book_issue_date.ToString() + "','" + book_apprx_return_date.ToString() + "','No','No')";
                        cmd1.ExecuteNonQuery();

                        //after a book is issued the no of avaliable books is reduced by 1 (update avaliable books in database) 
                        SqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "update books set books_qty = books_qty-1 where books_isbn='" + isbn.SelectedItem.ToString() + "'";
                        cmd2.ExecuteNonQuery();

                        Response.Write("<script>alert('Book Issued Succcessfully!'); window.location.href=window.location.href</script>");

                    }
                }
            }

        }



        //after the isbn_no is selected it should display the related book,title and amount of avaliable books
        protected void isbn_SelectedIndexChanged(object sender, EventArgs e)
        {
            i1.ImageUrl = "";
            booksname.Text = "";
            instock.Text = "";

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from books where books_isbn='" + isbn.SelectedItem.ToString() + "'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                i1.ImageUrl = dr1["books_image"].ToString();
                booksname.Text = "Title: " + dr1["books_title"].ToString();
                instock.Text = "Avaliable Books: " + dr1["books_qty"].ToString();
            }

        }
    }
}