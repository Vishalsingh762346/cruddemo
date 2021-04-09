using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_register_Click(object sender, EventArgs e)
    {
        try
        {
            if (Txt_password.Text == Txt_RePassword.Text)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string filename = FU_Profile.FileName;
                string str = DateTime.Now.GetHashCode().ToString();
                filename = str + filename;

                string path = Server.MapPath("~/upload/" + filename);
                FU_Profile.SaveAs(path);
                string gender = (Rbtn_Male.Checked == true) ? "male" : (Rbtn_Female.Checked == true) ? "Female" : "";
                string query = "insert into Tbl_Employee(name,gender,mobileno,email,department,address,salary,filename,regdate,password) values('" + Txt_Empname.Text.Trim() + "','" + gender + "','" + Txt_Mobileno.Text.Trim() + "','" + Txt_Email.Text.Trim() + "','" + DDLDepartment.SelectedItem.Text + "','" + TxtAddress.Text.Trim() + "','" + Txt_Salary.Text.Trim() + "','"+filename+"','"+DateTime.Now.ToString("dd/MM/yyyy")+"','"+Txt_password.Text.Trim()+"')";
                SqlCommand sqlcmd = new SqlCommand(query, con);
                int n = sqlcmd.ExecuteNonQuery();
                if (n > 0)
                {
                    LblMsg.Text = "Registration Successfully Done";
                    LblMsg.Style.Add("color", "green");
                }
                else
                {
                    LblMsg.Text = "Registration is not successfully Done";
                }
            }

                
            else
            {
                LblMsg.Text = "Entered Password is not matched";
            }
        }
        catch (Exception ex)
        {
            LblMsg.Text = "Server Error," + ex.Message;
        }
        finally 
        {
            con.Close();
        }
    }
}