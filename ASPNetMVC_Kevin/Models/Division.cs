using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPNetMVC_Kevin.Models
{
    [Table("Tb_M_Divisi")]
    public class Division
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DepartmentId { get; set; }
        public Department DepartmentIDNav { get; set; }
    }
}