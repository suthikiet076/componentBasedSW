using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Donation
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "กรุณาใส่ชื่อสิ่งของที่จะบริจาค")]
        [DataType(DataType.Text)]
        [Display(Name = "ชื่อสิ่งของ")]
        public string Title { get; set; }
        [Required(ErrorMessage = "กรุณาใส่ประเภทสิ่งของที่จะบริจาค")]
        [DataType(DataType.Text)]
        [Display(Name = "ประเภทสิ่งของ")]
        public string Type { get; set; }

        [Required(ErrorMessage = "กรุณาใส่จำนวนสิ่งของ")]
        [Range(0, 1000)]
        [Display(Name = "จำนวน")]
        public decimal Number { get; set; }

        [Required(ErrorMessage = "กรุณาใส่วันที่จะบริจาค")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "วันที่")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "กรุณาใส่ชื่อผู้บริจาค")]
        [DataType(DataType.Text)]
        [Display(Name = "ชื่อหลัก")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "กรุณาใส่นามสกุลผู้บริจาค")]
        [DataType(DataType.Text)]
        [Display(Name = "นามสกุล")]
        public string Lname { get; set; }

        [Required(ErrorMessage = "กรุณาใส่เบอร์โทรศัพท์ติดต่อ")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "เบอร์โทรศัพท์ติดต่อ")]
        public string Phone { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "เฟซบุ๊ค")]
        public string Facebook { get; set; }

    }
    
}