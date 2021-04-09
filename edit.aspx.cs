using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class edit : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["empid"] != null)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string id =Request.QueryString["empid"].ToString();
                string query = "select * from Tbl_Employee where empid='"+id+"'";
                SqlDataAdapter sqldata =new SqlDataAdapter(query,con);
                DataTable dt=new DataTable();
                sqldata.Fill(dt);
                if(dt !=null)
                {
                if(dt.Rows.Count>0)
                    {
                    hid.Value=id;
                    Txt_Empname.Text = dt.Rows[0]["name"]+"";//.ToString();
                    if(dt.Rows[0]["gender"]+""=="Male")
                    {
                      Rbtn_Male.Checked=true;
                    }
                    else if(dt.Rows[0]["gender"]+""=="Female")
                    {
                      Rbtn_Female.Checked=true;
                    }
                    Txt_Mobileno.Text=dt.Rows[0]["mobileno"]+"";
                    Txt_Email.Text=dt.Rows[0]["Email"]+"";
                    DDLDepartment.Items.FindByText(dt.Rows[0]["department"]+"").Selected=true;
                    TxtAddress.Text=dt.Rows[0]["address"]+"";
                    Txt_Salary.Text=dt.Rows[0]["salary"]+"";
                    }
                }
            }
        }
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Closed)
            con.Open();
        string gender=(Rbtn_Male.Checked==true)?"Male":(Rbtn_Female.Checked==true)?"Female":"";
        string qurey = "update Tbl_Employee set name='"+Txt_Empname.Text+"',gender='"+gender+"',mobileno='"+Txt_Mobileno.Text+"',email='"+Txt_Email.Text+"',department='"+DDLDepartment.SelectedItem.Text+"',address='"+TxtAddress.Text+"',salary='"+Txt_Salary.Text+"'";
            SqlCommand sqlcmd=new SqlCommand(qurey,con);
        sqlcmd.ExecuteNonQuery();
        Response.Redirect("~/customgride.aspx");
    }
}