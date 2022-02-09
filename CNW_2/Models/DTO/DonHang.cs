namespace CNW_2.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [Key]
        public int MaDonHang { get; set; }

        public DateTime? NgayDat { get; set; }

        public DateTime? NgayNhan { get; set; }

        public int? DaThanhToan { get; set; }

        [StringLength(100)]
        public string TinhTrangGiaoHang { get; set; }

        public int? MaKH { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
