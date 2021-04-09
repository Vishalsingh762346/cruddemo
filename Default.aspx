<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>Employee Registration Form</h2>
        <br/>
        <h3><a href="Display.aspx">Display Record</a></h3>
        <br/>
        <h3><a href="customgride.aspx">Display Custom Veiw</a></h3>
        <asp:Label runat="server" ID="LblMsg" style="color:red;"/>
        <br/>
        <br/>
        Enter Employee Name:
        <asp:TextBox runat="server" ID="Txt_Empname" required=""/>
        <br/>
        <br/>
        <br/>
        <br/>
        Select Gender:
        <asp:RadioButton runat="server" ID="Rbtn_Male" Text="Male" GroupName="gender" required=""/>
        <asp:RadioButton runat="server" ID="Rbtn_Female" Text="Female" GroupName="gender" required=""/>
        <br/>
        <br/>
        <br/>
        Enter Mobile No.:
        
        <asp:TextBox runat="server" ID="Txt_Mobileno" placeholder="Enter Mobile no" required=""/>
        <br/>
        <br/>
        <br/>
        Enter Email id:
       
        <asp:TextBox runat="server" ID="Txt_Email" required=""/>
        <br/>
        <br/>
        <br/>
        Select Department :
        <asp:DropDownList runat="server" ID="DDLDepartment" required="">
            <asp:ListItem Value="">Select Department</asp:ListItem>
            <asp:ListItem Value="HR">HR</asp:ListItem>
            <asp:ListItem Value="Testing">Testing</asp:ListItem>
            <asp:ListItem Value="Account">Account</asp:ListItem>
          </asp:DropDownList>
        <br/>
        <br/>
        <br/>
        <br/>
        Enter Address:
       
        <asp:TextBox runat="server" ID="TxtAddress"  required=""/>
        <br/>
        <br/>
        <br/>
        <br/>
        Salary:
       
        <asp:TextBox runat="server" ID="Txt_Salary" TextMode="Number" required=""/>
        <br/>
        <br/>
        <br/>
        Upload Profile Pic:
        
        <asp:FileUpload runat="server" ID="FU_Profile" required=""/>
        <br/>
        <br/>
        <br/>
        Enter Password:
        
        <asp:TextBox runat="server" ID="Txt_password" TextMode="Password" required=""/>
        <br/>
        <br/>
        <br/>
        Re-Enter Password :
        
        <asp:TextBox runat="server" ID="Txt_RePassword" TextMode="Password" required=""/>
        <br/>
        <br/>
        <br/>
        <asp:Button runat="server" ID="btn_register" Text="Submit" OnClick="btn_register_Click"/>
    </div>
    </form>
</body>
</html>
