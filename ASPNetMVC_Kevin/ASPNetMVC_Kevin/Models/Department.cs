using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPNetMVC_Kevin.Models
{
    [Table("Tb_M_Department")]
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}