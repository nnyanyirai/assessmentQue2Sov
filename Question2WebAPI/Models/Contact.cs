using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SingleDotNetCoreWebApp.Models
{
    public class Contact
    {
        [Key]
        public long Id { get; set; }
        [Column(TypeName = "bigint")] 
        public long CompanyId { get; set; }
        [Column(TypeName = "nvarchar(50)")] 
        public int ContactType { get; set; }
        [Column(TypeName = "nvarchar(50)")] 
        public string ContactValue { get; set; }
    }
}
