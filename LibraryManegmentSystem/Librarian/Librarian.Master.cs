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
    public partial class Librarian : System.Web.UI.MasterPage
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\projects\visualstudio project\LibraryManegmentSystem\LibraryManegmentSystem\App_Data\Lms.mdf"";Integrated Security=True");
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from messages where dusername='librarian' and placed='No'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            notification1.Text = count.ToString();
            notification2.Text = count.ToString();
            r1.DataSource= dt;
            r1.DataBind();

        }
        public string gettwentychracters(object myvalues)
        {
            string a;
            a= Convert.ToString(myvalues.ToString());
            string b = "";

            if(a.Length >= 10)
            {
                b=a.Substring(0,10);
                return b.ToString() + "..";
            }
            else
            {
                b = a.ToString();
                return b.ToString();
            }
        }
    }
}