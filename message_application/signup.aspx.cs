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
    public partial class signup : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ChatApp.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btncreate_Click(object sender, EventArgs e)
        {
            if (!Control(username.Text))
            {
                connect.Open();
                string sorgu = "insert into T_USER(FIRST_NAME,LAST_NAME,USERNAME,PASSWORD)values(@FIRST_NAME,@LAST_NAME,@USERNAME,@PASSWORD)";
                SqlCommand asd = new SqlCommand(sorgu, connect);

                asd.Parameters.Add("@FIRST_NAME", SqlDbType.VarChar).Value = firstname.Text;
                asd.Parameters.Add("@LAST_NAME", SqlDbType.VarChar).Value = lastname.Text;
                asd.Parameters.AddWithValue("@USERNAME", username.Text);
                asd.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = password.Text;
                asd.ExecuteReader();

                connect.Close();
                asd.Dispose();
                username.Text = null;
                lblmsg.Text = "Registration Successful.";
            }
            else if (username.Text == null)
            {
                lblmsg.Text = "Email can not be empty.";
            }
            else
            {
                lblmsg.Text = "This email is using by anyone else.";
            }
            connect.Close();

        }
        private bool Control(string gelenkullanici)
        {
            bool varmisinyokmusun;
            SqlCommand sql = new SqlCommand("select * from T_USER where USERNAME='" + gelenkullanici + "'", connect);
            connect.Open();
            SqlDataReader dr = sql.ExecuteReader();
            varmisinyokmusun = dr.HasRows;
            connect.Close();
            dr = null;
            return varmisinyokmusun;
        }
        protected void username_Textchanged(object sender, EventArgs e)
        {

            if (Control(username.Text))
            {
                lblusernamemsg.ForeColor = Color.Red;
                lblusernamemsg.Text = "This username is using by anyone else.";
            }
            else if ((username.Text) == null)
            {
                lblusernamemsg.ForeColor = Color.Red;
                lblusernamemsg.Text = "Username can not be empty.";
            }
            else
            {
                lblusernamemsg.ForeColor = Color.Green;
                lblusernamemsg.Text = "This Username Can Be Use.";
            }
        }
    }
}