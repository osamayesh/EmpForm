using EmpForm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpForm
{
    public partial class EmpPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                BindView();
            }


        }

        private void BindView()
        {
            EmployeeDAL empDAL = new EmployeeDAL();

            List<Employee> employees = empDAL.GetEmployees();     
            GridViewEmployees.DataSource=employees;
            GridViewEmployees.DataBind();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
            Employee employee = new Employee
            {
                EmpNumber = int.Parse(txtEmpNumber.Text),
                EmpName = txtEmpName.Text,
                Gender = ddlGender.SelectedValue,
              Date_of_birth = DateTime.Parse(txtDateOfBirth.Text),
                Position = TextPosition.Text,
                Salary = decimal.Parse(textSalary.Text)
            };
            EmployeeDAL empDAL = new EmployeeDAL();                                   
            employeeDAL.AddEmp(employee);
            BindView();
            ShowMessage("Employee successfully added.");

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int empId = int.Parse(txtId.Text);

            Employee employee = new Employee
            {
                Id = empId,
                EmpNumber = int.Parse(txtEmpNumber.Text),
                EmpName = txtEmpName.Text,
                Gender = ddlGender.SelectedValue,
                Date_of_birth = DateTime.Parse(txtDateOfBirth.Text),
                Position = TextPosition.Text,
                Salary = decimal.Parse(textSalary.Text)
            };
            EmployeeDAL empDAL = new EmployeeDAL();
            empDAL.UpdateEmp(employee);
            ShowMessage("Employee successfully Up.");

            BindView();
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int empId = int.Parse(txtId.Text);

            EmployeeDAL employeeDAL = new EmployeeDAL();
            employeeDAL.DeleteEmp(empId);
            BindView();
                        ShowMessage("Employee successfully deleted.");

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();

            string empName = txtEmpName.Text.Trim();
            int? empNumber = string.IsNullOrEmpty(txtEmpNumber.Text) ? (int?)null : Convert.ToInt32(txtEmpNumber.Text);
            int? empId = string.IsNullOrEmpty(txtId.Text) ? (int?)null : Convert.ToInt32(txtId.Text);
            decimal? salary = string.IsNullOrEmpty(textSalary.Text) ? (decimal?)null : Convert.ToDecimal(textSalary.Text);

            // Execute the search
            List<Employee> employees = employeeDAL.SearchEmployees(empName, empNumber, empId, salary);

            // Bind the result to the GridView
            GridViewEmployees.DataSource = employees;
            GridViewEmployees.DataBind();
        }

        private void ShowMessage(string message)
        {
            lblMessage.Text = message;
            lblMessage.Visible = true;
        }




    }
}