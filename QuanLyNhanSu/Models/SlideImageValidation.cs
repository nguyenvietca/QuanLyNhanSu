using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{
    public class SlideImageValidation
    {
        public int id { get; set; }
        //[Required(ErrorMessage = "Phải chọn hình ảnh ")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg)*$", ErrorMessage = "File không hợp lệ(png, jpg)")]
        public string src { get; set; }
        public string alt { get; set; }
        public string title { get; set; }
        public Nullable<System.DateTime> create_date { get; set; } = DateTime.Now;//by C# v6
        public Nullable<System.DateTime> update_date { get; set; } = DateTime.Now;//by C# v6
        public string displayFlg { get; set; }
    }
}