<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmpPage.aspx.cs" Inherits="EmpForm.EmpPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="container">
  

    <div class="row">
        <div class="col-md-6">
            <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="EmpNumber" HeaderText="Employee Number" />
                    <asp:BoundField DataField="EmpName" HeaderText="Employee Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:BoundField DataField="Date_of_birth" HeaderText="Date of Birth" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />
                    <asp:BoundField DataField="Position" HeaderText="Position" />
                    <asp:BoundField DataField="Salary" HeaderText="Salary" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-md-6">
            EmployeeId: <asp:TextBox ID="txtId" runat="server" ></asp:TextBox><br />
            EmployeeName: <asp:TextBox ID="txtEmpName" runat="server" ></asp:TextBox><br />
            EmployeeNumber: <asp:TextBox ID="txtEmpNumber" runat="server" ></asp:TextBox><br />
            Gender: <asp:DropDownList ID="ddlGender" runat="server">
                <asp:ListItem Text="Male" Value="Male" />
                <asp:ListItem Text="Female" Value="Female" />
            </asp:DropDownList><br />
            Date of Birth: <asp:TextBox ID="txtDateOfBirth" runat="server" Placeholder="YYYY-MM-DD" /><br />
            Salary: <asp:TextBox ID="textSalary" runat="server" ></asp:TextBox><br />
            Position: <asp:TextBox ID="TextPosition" runat="server" ></asp:TextBox><br />
            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-secondary" OnClick="btnSearch_Click" />
            <asp:Button ID="btnAdd" runat="server" Text="Add Employee" OnClick="btnAdd_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update Employee" OnClick="btnUpdate_Click" CssClass="btn btn-success" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete Employee" OnClick="btnDelete_Click" CssClass="btn btn-warning" />

               <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-success" Visible="false" ></asp:Label>
        </div>
    </div>
       
</div>
    


</asp:Content>
