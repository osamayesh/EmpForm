using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpForm.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmpName { get; set; }  
        
        public int EmpNumber { get; set; }

        public string Gender { get; set; }

        public DateTime Date_of_birth { get; set; }

        public string Position { get; set; }

        public  decimal Salary { get;  set; }




    }
}