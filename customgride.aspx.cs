using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;

public partial class customgride : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["empid"] != null)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string query = "delete from Tbl_Employee where empid='" + Request.QueryString["empid"] + "'";
            SqlCommand sqlcmd = new SqlCommand(query, con);
            int n = sqlcmd.ExecuteNonQuery();
        }
        GetRecord();
    }
    void GetRecord()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string query = "Select * from Tbl_Employee";
            SqlDataAdapter sqldata = new SqlDataAdapter(query, con);//select
            DataTable dt = new DataTable();
            sqldata.Fill(dt);
            con.Close();
            StringBuilder sb = new StringBuilder();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    sb.Append("<table border='1' width='95%'>");
                    sb.Append("<tr><th>Sr.No.</th>");
                    sb.Append("<th>Name</th>");
                    sb.Append("<th>Gender</th>");
                    sb.Append("<th>Mobile</th>");
                    sb.Append("<th>Email</th>");
                    sb.Append("<th>Address</th>");
                    sb.Append("<th>Department</th>");
                    sb.Append("<th>Salary</th>");
                    sb.Append("<th>Reg.Date</th>");
                    sb.Append("<th>Profile pic</th>");
                    sb.Append("<th>Edit</th>");
                    sb.Append("<th>Delete</th>");
                    sb.Append("</tr>");

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>"+(i+1)+"</td>");
                      
                        sb.Append("<td>" + dt.Rows[i]["Name"] + "</td>");
                        sb.Append("<td>" + dt.Rows[i]["Gender"] + "</td>");
                        sb.Append("<td>" + dt.Rows[i]["mobileno"] + "</td>");
                        sb.Append("<td>" + dt.Rows[i]["address"] + "</td>");
                        sb.Append("<td>" + dt.Rows[i]["department"] + "</td>");
                        sb.Append("<td>" + dt.Rows[i]["salary"] + "</td>");
                        sb.Append("<td>" + dt.Rows[i]["regdate"] + "</td>");
                        sb.Append("<td><img src='../upload/"+dt.Rows[i]["filename"]+"' height='50px' width='50px'/></td>");
                        
                        sb.Append("<td><a href='edit.aspx?empid="+dt.Rows[i]["empid"]+"'>Edit</a></td>");
                        sb.Append("<td><a href='#'onclick='del(this)'>Delete</a><span style='display:none;'>"+dt.Rows[i]["empid"]+"</span></td>");
                        sb.Append("</tr>");
                    }
                    sb.Append("</table>");
                    DataView.Text = sb + "";
                }
            }
        }
        catch 
        { 
        
        }
    }
}