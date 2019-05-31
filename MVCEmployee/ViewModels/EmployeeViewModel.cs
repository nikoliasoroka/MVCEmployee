using MVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEmployee.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? PhoneNumber { get; set; }
        public int SelectedDepartmentId { get; set; }
        public virtual List<LookupItem> Departments { get; set; }
    }
}