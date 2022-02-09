namespace CNW_2.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [Key]
        public int MaSach { get; set; }

        [StringLength(100)]
        public string TenSach { get; set; }

        public decimal? GiaBan { get; set; }

        public string MoTa { get; set; }

        [StringLength(100)]
        public string AnhBia { get; set; }

        public int? SoLuongTon { get; set; }

        public int? MaNXB { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }
    }
}
