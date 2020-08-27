using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;

namespace message_application
{
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ChatApp.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            connect.Open();
            string yAd = kadi.Text;
            string yParola = sifre.Text;
            SqlCommand sorgu = new SqlCommand("select * from T_USER where USERNAME='" + yAd + "' and PASSWORD='" + yParola + "'", connect);
            SqlDataReader asd = sorgu.ExecuteReader();
            if (asd.Read())
            {
                Session.Add("kullanici", yAd);
                Response.Redirect("homepage.aspx");
            }
            else
            {
                lblmsg.Text = "Wrong Password or Username";
            }
            connect.Dispose();
            connect.Close();
        }

    }
}