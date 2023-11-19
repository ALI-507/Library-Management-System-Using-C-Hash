using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace LibraryManegmentSystem.Librarian
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
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\projects\visualstudio project\LibraryManegmentSystem\LibraryManegmentSystem\App_Data\Lms.mdf"";Integrated Security=True"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Librarian_registration WHERE username=@username AND password=@password", con))
                    {
                        cmd.Parameters.AddWithValue("@username", username.Text);
                        cmd.Parameters.AddWithValue("@password", password.Text);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                Session["Librarian"] = username.Text;
                                Response.Redirect("testOnly.aspx");
                            }
                            else
                            {
                                error.Style.Add("display", "block");
                            }
                        }
                    }
                }
            }
            else
            {
                
                Div1.Style.Add("display", "block");
            }
        }

    }
}