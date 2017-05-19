using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{
    public class PhongBanValidation
    {
        [Required(ErrorMessage="Nhập mã phòng ban")]
        [RegularExpression(@"[A-Za-z0-9]*$", ErrorMessage = "Mã chứa kí tự đặc biệt")]
        [MaxLength(30, ErrorMessage = "vượt quá số kí tự 30")]
        
        public string MaPhongBan { get; set; }

        [Required(ErrorMessage = "Nhập tên phòng ban")]
        [MaxLength(50, ErrorMessage = "vượt quá số kí tự 50")]
        public string TenPhongBan { get; set; }
        public string DiaChi { get; set; }

        [MaxLength(11,ErrorMessage="sdt tối đa 11 số")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "chỉ được nhập số")]
        public string sdt_PhongBan { get; set; }
    }
}