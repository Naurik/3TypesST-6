using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Model
{
    public class DownLoadInformation
    {
        [Key]
        public int Id { get; set; }
        public string UrlAddress { get; set; }
        public string FileName { get; set; }
        public DateTime Data { get; set; }
        public string Time { get; set; }
    }
}
