using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace LibraryManegmentSystem.Student
{

    public partial class login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\projects\visualstudio project\LibraryManegmentSystem\LibraryManegmentSystem\App_Data\Lms.mdf"";Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            if (!IsPostBack)
            {
                string captchaText;
                Bitmap captchaImage = CaptchaGenerator.GenerateCaptcha(out captchaText);
                Session["CaptchaText"] = captchaText;
                imgCaptcha.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(BitmapToBytes(captchaImage));
            }
        }
        protected void b2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Student/citylibrary1.aspx");
        }
        private byte[] BitmapToBytes(Bitmap image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }
        protected void b1_Click(object sender, EventArgs e)
        {
            string enteredCaptcha = txtCaptcha.Text.Trim();
            string generatedCaptcha = Session["CaptchaText"] as string;

            if (enteredCaptcha.Equals(generatedCaptcha, StringComparison.OrdinalIgnoreCase))
            {
                int i = 10;
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from student_registration where username='" + username.Text + "' and password='" + password.Text + "' and approved='Yes'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());

                if (i > 0)
                {
                    Session["student"] = username.Text;
                    Response.Redirect("demo.aspx");
                }
                else
                {
                    error.Style.Add("display", "block");
                }
            }
            else
            {
                
                Div1.Style.Add("display", "block");
            }
        }
    }
}