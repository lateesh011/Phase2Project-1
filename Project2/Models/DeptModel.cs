using DalLib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Project2.Models
{
    public class DeptModel
    {

        [Key]
        [Required]
        public int DeptCode { get; set; }

        [MaxLength(20, ErrorMessage = "Not allowed above 20 chars")]
        [MinLength(2, ErrorMessage = "Not allowed below 2 chars")]
        public string DeptName { get; set; }

        public virtual ICollection<EmpProfile> GetEmpProfile { get; set; }
    }
}