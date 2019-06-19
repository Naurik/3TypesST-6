using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Model
{
    public class SendEmailInformation
    {
        [Key]
        public int Id { get; set; }
        public string NameFrom { get; set; }
        public string NameTo { get; set; }
        public string Text { get; set; }
        public DateTime Data { get; set; }
        public string Time { get; set; }
    }
}
