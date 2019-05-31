namespace MVC.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        [Key]
        public int EmpId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int? PhoneNumber { get; set; }

        public int DeptId { get; set; }

        public virtual Department Department { get; set; }
    }
}
