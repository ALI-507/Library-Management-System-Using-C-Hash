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
    public partial class my_issued_books : System.Web.UI.Page
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

            if (Session["student"] == null)
            {
                Response.Redirect("student_login.aspx");
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
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("student_enrollment_no");
            dt.Columns.Add("student_username");
            dt.Columns.Add("books_isbn");
            dt.Columns.Add("book_issue_date");
            dt.Columns.Add("book_apprx_return_date");
            dt.Columns.Add("is_book_returned");
            dt.Columns.Add("book_returned_date");
            dt.Columns.Add("latedays");
            dt.Columns.Add("penalty");


            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from Issue_Books where student_username='" + Session["student"].ToString() + "'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["student_enrollment_no"] = dr1["student_enrollment_no"].ToString();
                dr["student_username"] = dr1["student_username"].ToString();
                dr["books_isbn"] = dr1["books_isbn"].ToString();
                dr["book_issue_date"] = dr1["book_issue_date"].ToString();
                dr["book_apprx_return_date"] = dr1["book_apprx_return_date"].ToString();
                dr["is_book_returned"] = dr1["is_book_returned"].ToString();
                dr["book_returned_date"] = dr1["book_returned_date"].ToString();


                //calculate latedays
                DateTime d1 = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                DateTime d2 = Convert.ToDateTime(dr1["book_apprx_return_date"].ToString());

                if (d1 > d2)
                {
                    TimeSpan t = d1 - d2;
                    noofdays = t.TotalDays;
                    dr["latedays"] = noofdays.ToString();
                    dr["penalty"] = Convert.ToString(Convert.ToDouble(noofdays) * Convert.ToDouble(penalty));
                }
                else
                {
                    dr["latedays"] = "0";
                    dr["penalty"] = "0";
                }

              

                dt.Rows.Add(dr);
            }

            d1.DataSource = dt;
            d1.DataBind();
        }
    }
}