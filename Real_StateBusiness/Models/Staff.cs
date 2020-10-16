using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Real_StateBusiness.Models
{
    [Table("Staff_tbl")]
    public class Staff
    {
        [Key]
        public String StaffNo { get; set; }
        public String FName { get; set; }
        public String LName { get; set; }
        public String Position { get; set; }
        public DateTime DOB{ get; set; }
        public double Salary { get; set; }
        [ForeignKey("Branch")]
        public String BranchRef { get; set; }
        public Branch Branch { get; set; }
    }
}