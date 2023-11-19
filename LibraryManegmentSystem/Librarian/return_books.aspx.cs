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
    public partial class return_books : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Lms.mdf;Integrated Security=True");
        string penalty = "0";
        double noofdays = 0;
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


            // to display indiviual penalty of user
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from penalty";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                penalty = dr2["penalty"].ToString();
            }




            //This is for temporary datatable
            DataTable dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("id");
            dt1.Columns.Add("student_enrollment_no");
            dt1.Columns.Add("student_username");
            dt1.Columns.Add("books_isbn");
            dt1.Columns.Add("book_issue_date");
            dt1.Columns.Add("book_apprx_return_date");
            dt1.Columns.Add("is_book_returned");
            dt1.Columns.Add("book_returned_date");
            dt1.Columns.Add("latedays");
            dt1.Columns.Add("penalty");


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Issue_Books where is_book_returned='No'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                DataRow dr1 = dt1.NewRow();
                dr1["id"] = dr["id"].ToString();
                dr1["student_enrollment_no"] = dr["student_enrollment_no"].ToString();
                dr1["student_username"] = dr["student_username"].ToString();
                dr1["books_isbn"] = dr["books_isbn"].ToString();
                dr1["book_issue_date"] = dr["book_issue_date"].ToString();
                dr1["book_apprx_return_date"] = dr["book_apprx_return_date"].ToString();
                dr1["is_book_returned"] = dr["is_book_returned"].ToString();
                dr1["book_returned_date"] = dr["book_returned_date"].ToString();


                //calculate latedays
                DateTime d1 = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                DateTime d2 = Convert.ToDateTime(dr["book_apprx_return_date"].ToString());

                if (d1 > d2)
                {
                    TimeSpan t = d1 - d2;
                    noofdays = t.TotalDays;
                    dr1["latedays"] = noofdays.ToString();

                    //multiply penalty with latedys
                    dr1["penalty"] = Convert.ToString(Convert.ToDouble(noofdays) * Convert.ToDouble(penalty));
                }
                else
                {
                    dr1["latedays"] = "0";
                    dr1["penalty"] = "0";
                }

                

                dt1.Rows.Add(dr1);
            }

            d1.DataSource = dt1;
            d1.DataBind();
        }
    
    }
}