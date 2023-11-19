using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Net;
using System.IO;

namespace LibraryManegmentSystem.Student
{
    public partial class student_registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Lms.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            int count = 0;
            int count2 = 0;

            //if recaptcha is valid run this
            if (IsReCaptchValid())
            {
                // for getting a unique enrollment no for every user
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "select * from student_registration where enrollment_no='" + enrollmentno.Text + "'";
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(dt1);
                count = Convert.ToInt32(dt1.Rows.Count.ToString());

                if (count > 0)
                {
                    Response.Write("<script>alert('This enrollment no is already Taken.');</script>");
                }
                else
                {

                    //for getting a unique username
                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select * from student_registration where username='" + username.Text + "'";
                    DataTable dt2 = new DataTable();
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    da2.Fill(dt2);
                    count2 = Convert.ToInt32(dt2.Rows.Count.ToString());
                    if (count2 > 0)
                    {
                        Response.Write("<script>alert('This username is already Taken.');</script>");

                    }
                    else
                    {


                        //to get the image 
                        string randomno = Class1.GetRandomPassword(10) + ".jpg";
                        string path = "";
                        fu1.SaveAs(Request.PhysicalApplicationPath + "/student_img" + randomno.ToString());
                        path = "Student/student_img/" + randomno.ToString();


                        //comands to execute and store student registraion data in database
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into student_registration values('" + firstname.Text + "','" + lastname.Text + "','" + enrollmentno.Text + "','" + username.Text + "','" + email.Text + "','" + password.Text + "','" + contact.Text + "','" + path.ToString() + "','no')";
                        cmd.ExecuteNonQuery();

                        Response.Write("<script>alert('Successfully Registered')</script>");
                    }
                }
            }
            //if recaptcha is invalid display this
            else
            {
                lblMessage1.Text = "this is invalid";
            }


        }

        //code for recaptcha
        public bool IsReCaptchValid()
        {
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = "6LeGUOklAAAAAEI18ahtfA7z3zOQdk5B5MrNq8Gv";
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = (isSuccess) ? true : false;
                }
            }
            return result;
        }
    }
}