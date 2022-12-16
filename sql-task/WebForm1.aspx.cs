using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sql_task
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string folderPath = Server.MapPath("~/Images/");

            //Check whether Directory (Folder) exists.
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists Create it.
                Directory.CreateDirectory(folderPath);
            }

            //Save the File to the Directory (Folder).
            FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));
            SqlConnection con = new SqlConnection("data source=DESKTOP-Ek069v4\\SQLEXPRESS; database=14-12Task;integrated security=SSPI");
            con.Open();
            SqlCommand cmd = new SqlCommand($"insert into CustomerDetails values('{TextBox1.Text}',{TextBox2.Text},'{TextBox3.Text}',{TextBox4.Text},'{FileUpload1.FileName}')", con);
            cmd.ExecuteNonQuery();

            string table = "<table class='table table-striped'> <tr><th>Name</th> <th>Age</th> <th>Country</th> <th>Phone</th> <th>Image</th> </tr>";
            SqlCommand comand = new SqlCommand("select * from CustomerDetails", con);
            SqlDataReader sdr = comand.ExecuteReader();
            while (sdr.Read())
            {
                table += $"<tr><td>{sdr[0]}</td><td>{sdr[1]}</td><td>{sdr[2]}</td><td>{sdr[3]}</td><td><img width='200px' height='200px' src='Images/{sdr[4]}'/></td></tr>";
            }
            table += "</table>";
            Label label = new Label();
            label.Text = table;
            this.Controls.Add(label);


            con.Close();
        }
    }
}
    