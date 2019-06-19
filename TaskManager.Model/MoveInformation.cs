using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Model
{
    public class MoveInformation
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string PathFrom { get; set; }
        public string PathTo { get; set; }
        public DateTime Data { get; set; }
        public string Time { get; set; }
    }
}
