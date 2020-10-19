using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Real_StateBusiness.Models
{
    [Table("Rent_tbl")]
    public class Rent
    {
        [Key]
        public String PropertyNo { get; set; }
        public String Street { get; set; }
        public String City { get; set; }
        public String Ptype { get; set; }
        public String Rooms { get; set; }

        [ForeignKey("Owner")]
        public String OwnerRef { get; set; }
        public Owner Owner { get; set; }

        [ForeignKey("Staff")]
        public String StaffRef { get; set; }
        public Staff Staff { get; set; }

        [ForeignKey("Branch")]
        public String BranchRef { get; set; }
        public Branch Branch { get; set; }
    }
}