using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalLib
{
    public class DeptMaster
    {
        [Key]
        [Required]
        public int DeptCode { get; set; }

        [MaxLength(20, ErrorMessage = "Not allowed above 20 chars")]
        [MinLength(2, ErrorMessage = "Not allowed below 2 chars")]
        public string DeptName { get; set; }

        public virtual ICollection<EmpProfile> GetEmpProfile { get; set; }
    }

    public class EmpProfile
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

    public class MyContext : DbContext
    {
        public MyContext() : base("MyContext")
        {
            //createdatabase if not exists
            //drop create always
            //drop create if model changes

            Database.SetInitializer<MyContext>(new CreateDatabaseIfNotExists<MyContext>());
        }

        public virtual DbSet<DeptMaster> DeptTable { get; set; }
        public virtual DbSet<EmpProfile> EmpTable { get; set; }


    }

}