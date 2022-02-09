namespace CNW_2.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TacGia")]
    public partial class TacGia
    {
        [Key]
        public int MaTG { get; set; }

        [StringLength(100)]
        public string TenTG { get; set; }
    }
}
