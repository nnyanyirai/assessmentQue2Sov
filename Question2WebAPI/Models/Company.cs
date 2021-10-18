using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SingleDotNetCoreWebApp.Models
{
    public class Company
    {
        [Key]
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(50)")] 
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(50)")] 
        public string BusinessType { get; set; }
    }
}
