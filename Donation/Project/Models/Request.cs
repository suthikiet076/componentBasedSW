using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Request
    {
        public int ID { get; set; }
        [Display(Name = "ชื่อสิ่งของ")]
        public string Item { get; set; }
        [Required(ErrorMessage = "กรุณาใส่ชื่อต้นของคุณ")]
        [DataType(DataType.Text)]
        [Display(Name = "ชื่อผู้รับ")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "กรุณาใส่นามสกุลของคุณ")]
        [DataType(DataType.Text)]
        [Display(Name = "นามสกุล")]
        public string Lname { get; set; }
    }
}