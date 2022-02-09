namespace CNW_2.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DonHang = new HashSet<DonHang>();
            TaiKhoan = new HashSet<TaiKhoan>();
        }

        [Key]
        public int MaKH { get; set; }

        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(15)]
        public string DienThoai { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiKhoan> TaiKhoan { get; set; }
    }
}
