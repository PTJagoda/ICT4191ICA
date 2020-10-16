using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Real_StateBusiness.Models
{
    [Table("Owner_tbl")]
    public class Owner
    {
        [Key ]
        public String OwnerNo { get; set; }
        public String FName { get; set; }
        public String LName { get; set; }
        public String Address { get; set; }
        public String TellNo { get; set; }

        public List<Rent> Rents { get; set; }
    }
}