using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SingleDotNetCoreWebApp.Models
{
    public class Address
    {
        [Key]
        public long Id { get; set; }
        [Column(TypeName = "bigint")] 
        public long CompanyId { get; set; }
        [Column(TypeName = "nvarchar(150)")] 
        public string StreetName { get; set; }
        [Column(TypeName = "nvarchar(150)")] 
        public string StreetAddress { get; set; }
        [Column(TypeName = "nvarchar(50)")] 
        public string City { get; set; }
        [Column(TypeName = "nvarchar(50)")] 
        public string Country { get; set; }

    }
}
