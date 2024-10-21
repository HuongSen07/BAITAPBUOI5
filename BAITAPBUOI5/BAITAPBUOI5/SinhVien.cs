namespace BAITAPBUOI5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [Key]
        [StringLength(10)]
        public string MSSV { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(50)]
        public string Khoa { get; set; }

        public double? Diem { get; set; }
    }
}
