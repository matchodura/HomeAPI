using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Models
{
    public class BulbHistory
    {
        [Key]
        public int Id { get; set; }
        public int? LampId { get; set; }
        public string MethodName { get; set; }
        public string MethodValue{ get; set; }
        public DateTime DateSent { get; set; }
        public string Response { get; set; }
       
    }
}
