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
    public partial class homepage : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ChatApp.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["kullanici"] != null)
            {
               // lblwelcomemsg.Text = ("Hoşgeldin   " + Session["kullanici"]);
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

            MultiView1.ActiveViewIndex = 0;
            getuserid();
            doldur();
        }
        protected void getuserid()
        {
            DataTable dt = null;
            DataSet ds = new DataSet();
            SqlConnection db_baglanti;
            SqlCommand db_komut;
            SqlDataAdapter db_adapter = null;
            db_baglanti = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ChatApp.mdf;Integrated Security=True");
            db_baglanti.Open();
            string sorgu = "SELECT * FROM T_USER WHERE   USERNAME=@USERNAME";
            db_komut = new SqlCommand(sorgu, db_baglanti);
            db_komut.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = Session["kullanici"];
            db_adapter = new SqlDataAdapter();
            db_adapter.SelectCommand = db_komut;
            db_adapter.Fill(ds);
            dt = ds.Tables[0];
            db_adapter = null;
            db_baglanti.Close();
            db_baglanti = null;
            if (dt.Rows.Count > 0)
            {
                lblid.Text = dt.Rows[0]["USER_ID"].ToString();
                lblfirstname.Text = dt.Rows[0]["FIRST_NAME"].ToString();
                lbllastname.Text = dt.Rows[0]["LAST_NAME"].ToString();
            }
        }
        void doldur()
        {
            // veritabanına bağlanmayı sağlar
            string yol = ("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ChatApp.mdf;Integrated Security=True");
            SqlConnection Con = new SqlConnection(yol);
            //aşağıdaki tümce kapalı durumda olan bağlantıyı açar
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            //string SQL = "SELECT DISTINCT (TUMR.ROOM_ID),(SELECT TSUB.USER_ID FROM T_USER TSUB WHERE TU.USER_ID=TSUB.USER_ID) AS USER_ID,(SELECT TSUB.FIRST_NAME FROM T_USER TSUB WHERE TU.USER_ID=TSUB.USER_ID) AS FIRST_NAME,(SELECT TSUB.LAST_NAME FROM T_USER TSUB WHERE TU.USER_ID = TSUB.USER_ID) AS LAST_NAME FROM T_USER TU,T_USER_MESSAGE_ROOM TUMR, T_USER_SENDER TUS,T_USER_MESSAGE TUM WHERE TU.USER_ID = TUS.USER_ID AND TUS.MESSAGE_SENDERS_ID = TUMR.MESSAGE_SENDERS_ID AND TUMR.ROOM_ID = TUM.ROOM_ID AND TUM.SENDER_ID = TU.USER_ID AND TUM.SENDER_ID <> 501 AND TUM.ROOM_ID IN(SELECT TUMM.ROOM_ID FROM T_USER_MESSAGE TUMM, T_USER_SENDER TUSS, T_USER_MESSAGE_ROOM TUMRR WHERE TUMRR.MESSAGE_SENDERS_ID = TUSS.MESSAGE_SENDERS_ID AND TUMRR.ROOM_ID = TUMM.ROOM_ID AND TUSS.USER_ID = 501)";
            string SQL = "SELECT DISTINCT (TUMB.MESSAGE_BOX_ID), (SELECT TSUB.USER_ID FROM T_USER TSUB WHERE TU.USER_ID=TSUB.USER_ID) AS USER_ID, (SELECT TSUB.FIRST_NAME FROM T_USER TSUB WHERE TU.USER_ID = TSUB.USER_ID) AS FIRST_NAME,(SELECT TSUB.LAST_NAME FROM T_USER TSUB WHERE TU.USER_ID = TSUB.USER_ID) AS LAST_NAME FROM T_USER TU,T_USER_MESSAGE_BOX TUMB, T_USER_SENDER TUS,T_USER_MESSAGE TUM WHERE TU.USER_ID = TUS.USER_ID AND TUS.MESSAGE_BOX_ID = TUMB.MESSAGE_BOX_ID AND TUMB.MESSAGE_BOX_ID = TUM.MESSAGE_BOX_ID AND TUM.SENDER_ID = TU.USER_ID AND TUM.SENDER_ID <> '"+lblid.Text+"' AND TUM.MESSAGE_BOX_ID IN(SELECT TUMM.MESSAGE_BOX_ID FROM T_USER_MESSAGE TUMM, T_USER_SENDER TUSS, T_USER_MESSAGE_BOX TUMBB WHERE TUMBB.MESSAGE_BOX_ID = TUSS.MESSAGE_BOX_ID AND TUMBB.MESSAGE_BOX_ID = TUMM.MESSAGE_BOX_ID AND TUSS.USER_ID = '" + lblid.Text + "')";
            //string SQL = "select TUM.ID,TU.USER_NAME,TU.USER_SURNAME,TUM.FROM_USER_ID,TUM.TO_USER_ID,from T_USER TU,T_USER_MESSAGE TUM where TUM.FROM_USER_ID = TUPP.PROFILE_PHOTO_USER_ID and TU.ID = TUM.FROM_USER_ID and TUM.TO_USER_ID=500  order by TUM.ID desc ";
            SqlDataAdapter adp = new SqlDataAdapter(SQL, Con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            Con.Close();
            Con.Dispose();
        }
        private void getmessageboxid()
        {
            DataTable dt = null;
            DataSet ds = new DataSet();
            SqlConnection db_baglanti;
            SqlCommand db_komut;
            SqlDataAdapter db_adapter = null;
            db_baglanti = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ChatApp.mdf;Integrated Security=True");
            db_baglanti.Open();
            string sorgu = "SELECT MESSAGE_BOX_ID FROM T_USER_SENDER WHERE USER_ID=@USERID1 INTERSECT SELECT MESSAGE_BOX_ID FROM T_USER_SENDER WHERE USER_ID =@USERID2";
            db_komut = new SqlCommand(sorgu, db_baglanti);
            db_komut.Parameters.Add("@USERID1", SqlDbType.VarChar).Value = lblid.Text;
            db_komut.Parameters.Add("@USERID2", SqlDbType.VarChar).Value = lbluserid.Text;
            db_adapter = new SqlDataAdapter();
            db_adapter.SelectCommand = db_komut;
            db_adapter.Fill(ds);
            dt = ds.Tables[0];
            db_adapter = null;
            db_baglanti.Close();
            db_baglanti = null;
            if (dt.Rows.Count > 0)
            {
                lblmessageboxid.Text = dt.Rows[0]["MESSAGE_BOX_ID"].ToString();

            }
        }
        private void getlastmessageboxid()
        {
            DataTable dt = null;
            DataSet ds = new DataSet();
            SqlConnection db_baglanti;
            SqlCommand db_komut;
            SqlDataAdapter db_adapter = null;
            db_baglanti = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ChatApp.mdf;Integrated Security=True");
            db_baglanti.Open();
            string sorgu = "SELECT MESSAGE_BOX_ID FROM T_USER_MESSAGE_BOX ORDER BY MESSAGE_BOX_ID DESC";
            db_komut = new SqlCommand(sorgu, db_baglanti);
            db_komut.Parameters.Add("@MESSAGE_BOX_ID", SqlDbType.VarChar).Value = TextSelectUser.Text;
            db_adapter = new SqlDataAdapter();
            db_adapter.SelectCommand = db_komut;
            db_adapter.Fill(ds);
            dt = ds.Tables[0];
            db_adapter = null;
            db_baglanti.Close();
            db_baglanti = null;
            if (dt.Rows.Count > 0)
            {
                lblmessageboxid.Text = dt.Rows[0]["MESSAGE_BOX_ID"].ToString();

            }
        }
        private void getusername()
        {
            DataTable dt = null;
            DataSet ds = new DataSet();
            SqlConnection db_baglanti;
            SqlCommand db_komut;
            SqlDataAdapter db_adapter = null;
            db_baglanti = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ChatApp.mdf;Integrated Security=True");
            db_baglanti.Open();
            string sorgu = "SELECT * FROM T_USER WHERE USERNAME=@USERNAME";
            db_komut = new SqlCommand(sorgu, db_baglanti);
            db_komut.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = TextSelectUser.Text;
            db_adapter = new SqlDataAdapter();
            db_adapter.SelectCommand = db_komut;
            db_adapter.Fill(ds);
            dt = ds.Tables[0];
            db_adapter = null;
            db_baglanti.Close();
            db_baglanti = null;
            if (dt.Rows.Count > 0)
            {
                lbluserid.Text = dt.Rows[0]["USER_ID"].ToString();

            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            //Label lblmessagesid = (Label)GridView1.SelectedRow.FindControl("lblmessagesid");
            Label lblmessageboxid = (Label)GridView1.SelectedRow.FindControl("lblmessageboxid");
            Label lblmessageuserid = (Label)GridView1.SelectedRow.FindControl("lblmessageuserid");
            Label lblmessageusername = (Label)GridView1.SelectedRow.FindControl("lblmessageusername");
            Label lblmessageusersurname = (Label)GridView1.SelectedRow.FindControl("lblmessageusersurname");

            //Textmessageid.Text = lblmessagesid.Text;
            Textmessageboxid.Text = lblmessageboxid.Text;
            Textmessageuserid.Text = lblmessageuserid.Text;
            labeltoname.Text = lblmessageusername.Text;
            labeltosurname.Text = lblmessageusersurname.Text;

            PnlSeeMessage.Visible = true;
            connect.Open();
            //string sorgu = "SELECT TU.FIRST_NAME,TU.LAST_NAME,TUM.MESSAGE FROM T_USER TU,T_USER_SENDER TUS,T_USER_MESSAGE TUM,T_USER_MESSAGE_ROOM TUMR WHERE TU.USER_ID = TUS.USER_ID AND TUS.MESSAGE_SENDERS_ID = TUMR.MESSAGE_SENDERS_ID AND TUMR.ROOM_ID = TUM.ROOM_ID AND TUM.SENDER_ID = TU.USER_ID AND TUM.ROOM_ID = " + Textroomid.Text + " ORDER BY TUM.MESSAGE_ID ASC";
            string sorgu = "SELECT TU.FIRST_NAME,TU.LAST_NAME,TUM.MESSAGE,TUM.MESSAGE_DATE FROM T_USER TU,T_USER_SENDER TUS,T_USER_MESSAGE TUM,T_USER_MESSAGE_BOX TUMB WHERE TU.USER_ID = TUS.USER_ID AND TUS.MESSAGE_BOX_ID = TUMB.MESSAGE_BOX_ID AND TUMB.MESSAGE_BOX_ID = TUM.MESSAGE_BOX_ID AND TUM.SENDER_ID = TU.USER_ID AND TUM.MESSAGE_BOX_ID = " + Textmessageboxid.Text + " ORDER BY TUM.MESSAGE_ID ASC";
            // string sorgu = "select TU.USER_NAME,TU.USER_SURNAME,TUMS.MESSAGE from T_USER TU,T_USER_MESSAGE TUM,T_USER_MESSAGES TUMS where TU.ID=TUM.FROM_USER_ID and TUM.ID=TUMS.MESSAGE_ID and TUM.ID=" + lblmessageid.Text + " order by TUMS.ID desc";
            SqlCommand cmd = new SqlCommand(sorgu, connect);
            SqlDataReader dr = cmd.ExecuteReader();
            lstDuyuru.DataSource = dr;
            lstDuyuru.DataBind();
            connect.Close();
        }
        private bool Control(string gelenkullanici)
        {
            connect.Open();
            bool varmisinyokmusun;
            SqlCommand sql = new SqlCommand("select *from T_USER where USERNAME='" + gelenkullanici + "'", connect);
            SqlDataReader dr = sql.ExecuteReader();
            varmisinyokmusun = dr.HasRows;
            connect.Close();
            dr = null;
            return varmisinyokmusun;
        }
        private bool Control2(string gelenkullanici)
        {
            connect.Open();
            bool varmisinyokmusun;
            SqlCommand sql = new SqlCommand("select * from T_USER_SENDER where USER_ID='" + gelenkullanici + "'", connect);
            SqlDataReader dr = sql.ExecuteReader();
            varmisinyokmusun = dr.HasRows;
            connect.Close();
            dr = null;
            return varmisinyokmusun;
        }
        private bool Control3(string gelenmessagebox)
        {
            bool varmisinyokmusun;
            SqlCommand sql = new SqlCommand("select *from T_USER_MESSAGE_BOX where MESSAGE_BOX_ID='" + gelenmessagebox + "'", connect);
            connect.Open();
            SqlDataReader dr = sql.ExecuteReader();
            varmisinyokmusun = dr.HasRows;
            connect.Close();
            dr = null;
            return varmisinyokmusun;
        }
        protected void TextSelectUser_Textchanged(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            if (Control(TextSelectUser.Text))
            {
                durum.ForeColor = Color.Green;
                durum.Text = "User Available";
            }
            else if ((TextSelectUser.Text) == null)
            {
                durum.ForeColor = Color.Red;
                durum.Text = "Username cannot be empty";
            }
            else
            {
                durum.ForeColor = Color.Red;
                durum.Text = "User not found ";
            }
        }
        protected void BtnAnswer_Click(object sender, EventArgs e)
        {
            lstDuyuru.Visible = false;
            BtnBack.Visible = false;
            BtnAnswer.Visible = false;
            BtnDelete.Visible = false;
            BtnAnswerBack.Visible = true;
            labelto.Visible = true;
            labeltoname.Visible = true;
            labeltosurname.Visible = true;
            TextMessage.Visible = true;
            BtnSend.Visible = true;
        }
        protected void BtnSend_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            connect.Open();
            string sorgu = "insert into T_USER_MESSAGE(MESSAGE_BOX_ID,SENDER_ID,MESSAGE,MESSAGE_DATE)values(@MESSAGE_BOX_ID,@SENDER_ID,@MESSAGE,@MESSAGE_DATE)";
            SqlCommand asd = new SqlCommand(sorgu, connect);
            asd.Parameters.Add("@MESSAGE_BOX_ID", SqlDbType.VarChar).Value = Textmessageboxid.Text;
            asd.Parameters.Add("@SENDER_ID", SqlDbType.VarChar).Value = lblid.Text;
            asd.Parameters.Add("@MESSAGE", SqlDbType.VarChar).Value = TextMessage.Text;
            asd.Parameters.Add("@MESSAGE_DATE", SqlDbType.DateTime).Value = now.ToString();
            asd.ExecuteReader();
            lblanswermsg.Visible = true;
            lblanswermsg.Text = "Message Sent";
            connect.Close();
        }
        protected void BtnWriteMessage_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            lblwritemsg.Visible = false;
        }
        protected void BtnWriteMsg_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            
            getusername();
            getmessageboxid();
            if (!Control(TextSelectUser.Text))
            {
            }
            else
            {
                if (Control3(lblmessageboxid.Text) && Control2(lblid.Text) && Control2(lbluserid.Text))
                {
                    //getmessageid2();

                    connect.Open();
                    string sorgu3 = "insert into T_USER_MESSAGE(MESSAGE_BOX_ID,SENDER_ID,MESSAGE,MESSAGE_DATE)values(@MESSAGE_BOX_ID,@SENDER_ID,@MESSAGE,@MESSAGE_DATE)";
                    SqlCommand asd3 = new SqlCommand(sorgu3, connect);
                    asd3.Parameters.Add("@MESSAGE_BOX_ID", SqlDbType.VarChar).Value = lblmessageboxid.Text;
                    asd3.Parameters.Add("@SENDER_ID", SqlDbType.VarChar).Value = lblid.Text;
                    asd3.Parameters.Add("@MESSAGE", SqlDbType.VarChar).Value = TextMessageBox.Text;
                    asd3.Parameters.Add("@MESSAGE_DATE", SqlDbType.DateTime).Value = now.ToString();
                    asd3.ExecuteReader();
                    lblwritemsg.Visible = true;
                    lblwritemsg.Text = "Message Sent";
                    connect.Close();

                    TextSelectUser.Text = null;
                    lbluserid.Text = null;
                    lblmessageboxid.Text = null;
                }
                else
                {
                    connect.Open();
                    string sorgu = "insert into T_USER_MESSAGE_BOX(BOX_NAME)values(@BOX_NAME)";
                    SqlCommand asd = new SqlCommand(sorgu, connect);
                    asd.Parameters.Add("@BOX_NAME", SqlDbType.VarChar).Value = ' ';
                    asd.ExecuteReader();
                    connect.Close();

                    getlastmessageboxid();


                    connect.Open();
                    string sorgu2 = "insert into T_USER_SENDER(MESSAGE_BOX_ID,USER_ID)values(@MESSAGE_BOX_ID,@USER_ID)";
                    SqlCommand asd2 = new SqlCommand(sorgu2, connect);
                    asd2.Parameters.Add("@MESSAGE_BOX_ID", SqlDbType.VarChar).Value = lblmessageboxid.Text;
                    asd2.Parameters.Add("@USER_ID", SqlDbType.VarChar).Value = lblid.Text;
                    asd2.ExecuteReader();
                    connect.Close();


                    connect.Open();
                    string sorgu3 = "insert into T_USER_SENDER(MESSAGE_BOX_ID,USER_ID)values(@MESSAGE_BOX_ID,@USER_ID)";
                    SqlCommand asd3 = new SqlCommand(sorgu3, connect);
                    asd3.Parameters.Add("@MESSAGE_BOX_ID", SqlDbType.VarChar).Value = lblmessageboxid.Text;
                    asd3.Parameters.Add("@USER_ID", SqlDbType.VarChar).Value = lbluserid.Text;
                    asd3.ExecuteReader();
                    connect.Close();

                    //getmessageid2();

                    connect.Open();
                    string sorgu4 = "insert into T_USER_MESSAGE(MESSAGE_BOX_ID,SENDER_ID,MESSAGE,MESSAGE_DATE)values(@MESSAGE_BOX_ID,@SENDER_ID,@MESSAGE,@MESSAGE_DATE)";
                    SqlCommand asd4 = new SqlCommand(sorgu4, connect);
                    asd4.Parameters.Add("@MESSAGE_BOX_ID", SqlDbType.VarChar).Value = lblmessageboxid.Text;
                    asd4.Parameters.Add("@SENDER_ID", SqlDbType.VarChar).Value = lblid.Text;
                    asd4.Parameters.Add("@MESSAGE", SqlDbType.VarChar).Value = TextMessageBox.Text;
                    asd4.Parameters.Add("@MESSAGE_DATE", SqlDbType.DateTime).Value = now.ToString();
                    asd4.ExecuteReader();
                    lblwritemsg.Visible = true;
                    lblwritemsg.Text = "Message Sent";
                    connect.Close();

                    TextSelectUser.Text = null;
                    lbluserid.Text = null;
                    lblmessageboxid.Text = null;
                }
            }
            MultiView1.ActiveViewIndex = 1;
            BtnWriteMessage.Visible = true;
        }
        protected void BtnAnswerBack_Click(object sender, EventArgs e)
        {
            lstDuyuru.Visible = true;
            BtnBack.Visible = true;
            BtnAnswer.Visible = true;
            BtnDelete.Visible = true;
            BtnAnswerBack.Visible = false;
            labelto.Visible = false;
            labeltoname.Visible = false;
            labeltosurname.Visible = false;
            TextMessage.Visible = false;
            BtnSend.Visible = false;
            lblanswermsg.Visible = false;
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            PnlSeeMessage.Visible = false;
            lblanswermsg.Visible = false;
            GridView1.Visible = true;
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            connect.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter komut = new SqlDataAdapter("delete from T_USER_MESSAGE where MESSAGE_BOX_ID='" + Textmessageboxid.Text + "' ", connect);
            komut.Fill(dt);
            connect.Close();

            connect.Open();
            DataTable dt2 = new DataTable();
            SqlDataAdapter komut2 = new SqlDataAdapter("delete from T_USER_MESSAGE_BOX where MESSAGE_BOX_ID='" + Textmessageboxid.Text + "' ", connect);
            komut2.Fill(dt);
            connect.Close();

            connect.Open();
            DataTable dt3 = new DataTable();
            SqlDataAdapter komut3 = new SqlDataAdapter("delete from T_USER_SENDER where MESSAGE_BOX_ID='" + Textmessageboxid.Text + "' ", connect);
            komut3.Fill(dt);
            connect.Close();

            doldur();
            PnlSeeMessage.Visible = false;
            GridView1.Visible = true;
        }
        protected void BtnSignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        protected void BtnWhatsapp_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            doldur();
            lblanswermsg.Visible = false;
            PnlSeeMessage.Visible = false;
            GridView1.Visible = true;
        }
    }
}