using DalLib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project2.Models
{
    public class EmpModel
    {
        [Key]
        [Required]
        public int EmpCode { get; set; }

        public DateTime DateOfBirth { get; set; }

        [MaxLength(20, ErrorMessage = "Not allowed above 20 chars")]
        [MinLength(2, ErrorMessage = "Not allowed below 2 chars")]
        public string EmpName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int DeptCode { get; set; }

        [ForeignKey("DeptCode")]
        public virtual DeptMaster Departments { get; set; }

        public virtual ICollection<DeptMaster> virtual_DeptMaster { get; set; }
    }
}